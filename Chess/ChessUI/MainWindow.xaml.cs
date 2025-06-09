using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using ChessLogic;
using Color = System.Windows.Media.Color;
using Point = System.Windows.Point;
using Rectangle = System.Windows.Shapes.Rectangle;
using ChessAI;
using System.Windows.Threading;
using ChessUI.ViewModels;
using static ChessUI.ViewModels.BotMenuViewModel;
using ChessUI.Views.Menus;
using System.Collections.ObjectModel;

namespace ChessUI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly Image[,] pieceImages = new Image[8, 8];
		private readonly Rectangle[,] highlights = new Rectangle[8, 8];
		private readonly Dictionary<Position, Move> moveCache = new Dictionary<Position, Move>();
		private BotDifficulty selectedDifficulty;

		private GameState gameState;
		private Position selectedPos = null;

		private bool playingWithBot = false;

		private ObservableCollection<string> moveHistory = new ObservableCollection<string>();
        private MoveHistoryWindow historyWidow;

        public MainWindow()
		{
            InitializeComponent();
			//ShowStep1();

			InitializeBoard();

			gameState = new GameState(Player.White, Board.Initial());
			//gameState = new GameState(Player.Black, Board.Initial());
			DrawBoard(gameState.Board);
			SetCursor(gameState.CurrentPlayer);

            this.Loaded += (s, e) => ShowHistoryWindow();
        }

		private void InitializeBoard()
		{
			for (int r = 0; r < 8; r++)
			{
				for (int c = 0; c < 8; c++)
				{
					Image image = new Image();
					pieceImages[r, c] = image;
					PieceGrid.Children.Add(image);

					Rectangle highlight = new Rectangle();
					highlights[r, c] = highlight;
					HighlightGrid.Children.Add(highlight);
				}
			}
		}

		private void DrawBoard(Board board)
		{
			//clear all highlights
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    highlights[r, c].Fill = Brushes.Transparent;
                    highlights[r, c].Stroke = null;
                }
            }

			Player currentPlayer = gameState.CurrentPlayer;
            // highlight the checked if any
            Position? checkedKingPos = board.GetCheckedKingPosition(currentPlayer);
			if (checkedKingPos != null)
			{
				int r = checkedKingPos.Row;
                int c = checkedKingPos.Column;
                highlights[r, c].Fill = new SolidColorBrush(Color.FromArgb(128, 255, 0, 0));
            }

			//highlight last move
			if (gameState.LastMove != null)
			{
				var fromPos = gameState.LastMove.FromPos;
				var toPos = gameState.LastMove.ToPos;

				highlights[fromPos.Row, fromPos.Column].Fill = new SolidColorBrush(Color.FromArgb(128, 72, 118, 255));
				highlights[toPos.Row, toPos.Column].Fill = new SolidColorBrush(Color.FromArgb(128, 72, 118, 255));
			}

			// draw pieces
			for (int r = 0; r < 8; r++)
			{
				for (int c = 0; c < 8; c++)
				{
					Piece piece = board[r, c];
					pieceImages[r, c].Source = Images.GetImage(piece);
                }
			}
        }

		private void BoardGrid_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (IsMenuOnScreen())
			{
				return;
			}

			Point point = e.GetPosition(BoardGrid);
			Position pos = ToSquarePosition(point);

			if (selectedPos == null)
			{
				OnFromPositionSelected(pos);
			}
			else
			{
				OnToPositionSelected(pos);
			}
		}

		private Position ToSquarePosition(Point point)
		{
			double squareSize = BoardGrid.ActualWidth / 8;
			int row = (int)(point.Y / squareSize);
			int col = (int)(point.X / squareSize);
			return new Position(row, col);
		}

		private void OnFromPositionSelected(Position pos)
		{
			IEnumerable<Move> moves = gameState.LegalMovesForPiece(pos);

			if (moves.Any())
			{
				selectedPos = pos;
				CacheMoves(moves);
				ShowHighlights();
			}
		}

		private void OnToPositionSelected(Position pos)
		{
			selectedPos = null;
			HideHighlights();

			if (moveCache.TryGetValue(pos, out Move move))
			{
				if (move.Type == MoveType.PawnPromotion)
				{
					HandlePromotion(move.FromPos, move.ToPos);
				}
				else
				{
					HandleMove(move);
				}
			}
		}

		private void HandlePromotion(Position from, Position to)
		{
			pieceImages[to.Row, to.Column].Source = Images.GetImage(gameState.CurrentPlayer, PieceType.Pawn);
			pieceImages[from.Row, from.Column].Source = null;

			PromotionMenu promMenu = new PromotionMenu(gameState.CurrentPlayer);
			MenuContent.Content = promMenu;

			promMenu.PieceSelected += type =>
			{
				MenuContent.Content = null;
				Move promMove = new PawnPromotion(from, to, type);
				HandleMove(promMove);
			};
		}

		private void HandleMove(Move move)
		{
            gameState.MakeMove(move);

			string moveString = move.ToString();
			moveHistory.Add(moveString);

            DrawBoard(gameState.Board);
			SetCursor(gameState.CurrentPlayer);

			if (gameState.IsGameOver())
			{
				ShowGameOver();
			}

			if (playingWithBot && gameState.CurrentPlayer == Player.Black)
			{
				Dispatcher.InvokeAsync(() => PlayBotTurn(), System.Windows.Threading.DispatcherPriority.Background);
			}
		}


        private void CacheMoves(IEnumerable<Move> moves)
		{
			moveCache.Clear();

			foreach (Move move in moves)
			{
				moveCache[move.ToPos] = move;
			}
		}

		private void ShowHighlights()
		{
			//Color color = Color.FromArgb(150, 125, 255, 125);

			//foreach (Position to in moveCache.Keys)
			//{
			//	highlights[to.Row, to.Column].Fill = new SolidColorBrush(color);
			//}

			Color moveColor = Color.FromArgb(150, 125, 255, 125);
			Color captureColor = Color.FromArgb(180, 255, 100, 100);
			Color selectedColor = Color.FromArgb(180, 255, 255, 0);

            foreach (var kvp in moveCache)
			{
				Position to = kvp.Key;
                Move move = kvp.Value;

				Piece targetPiece = gameState.Board[to];
				if (targetPiece != null && targetPiece.Color != gameState.CurrentPlayer)
				{
					highlights[to.Row, to.Column].Fill = new SolidColorBrush(captureColor);
                }
				else
				{
					highlights[to.Row, to.Column].Fill = new SolidColorBrush(moveColor);
                }
            }
            if (selectedPos != null)
				highlights[selectedPos.Row, selectedPos.Column].Fill = new SolidColorBrush(selectedColor);
            
        }

		private void HideHighlights()
		{
			foreach (Position to in moveCache.Keys)
			{
				highlights[to.Row, to.Column].Fill = Brushes.Transparent;
			}
		}

		private void SetCursor(Player player)
		{
			if (player == Player.White)
			{
				Cursor = ChessCursors.WhiteCursor;
			}
			else
			{
				Cursor = ChessCursors.BlackCursor;
			}
		}

		private bool IsMenuOnScreen()
		{
			return MenuContent.Content != null;
		}

		private void ShowGameOver()
		{
			GameOverMenu gameOverMenu = new GameOverMenu(gameState);
			MenuContent.Content = gameOverMenu;

			gameOverMenu.OptionSelected += option =>
			{
				if (option == Option.Restart)
				{
					MenuContent.Content = null;
					RestartGame();
				}

				else
				{
					Application.Current.Shutdown();
				}
			};
		}

		private void RestartGame()
		{
			selectedPos = null;
			HideHighlights();
			moveCache.Clear();
			playingWithBot = false;
			gameState = new GameState(Player.White, Board.Initial());
			DrawBoard(gameState.Board);
			SetCursor(gameState.CurrentPlayer);
		}

		private void Window_KeyDown(object sender, KeyEventArgs e)
		{
			if (!IsMenuOnScreen() && e.Key == Key.Escape)
			{
				ShowPauseMenu();
			}
			else if (!IsMenuOnScreen() && e.Key == Key.A)
			{
				//play vs bot
				ShowBot();
			}
		}

		private void ShowPauseMenu()
		{
			PauseMenu pauseMenu = new PauseMenu();
			MenuContent.Content = pauseMenu;

			pauseMenu.OptionSelected += option =>
			{
				MenuContent.Content = null;
				if (option == Option.Restart)
				{
					RestartGame();
				}
			};
		}

		private void ShowBot()
		{
			var botMenu = BotMenuViewModelHelper.CreateBotMenu((option, difficulty) =>
			{
				MenuContent.Content = null;

				if (option == BotOptions.Exit)
				{
					Application.Current.Shutdown();
				}
				else if (option == BotOptions.Play)
				{
					selectedDifficulty = difficulty;
					Console.WriteLine($"Selected Difficulty: {selectedDifficulty}");
					ShowPopUp();
					BotPlay();
				}
			});

			MenuContent.Content = botMenu;
		}

		private Bot currentBot;
		private void BotPlay()
		{
			playingWithBot = true;
			selectedPos = null;
			HideHighlights();
			moveCache.Clear();
			gameState = new GameState(Player.White, Board.Initial());
			DrawBoard(gameState.Board);
			SetCursor(gameState.CurrentPlayer);

			currentBot = new Bot(selectedDifficulty);

			if (gameState.CurrentPlayer == Player.Black)
			{
				Dispatcher.InvokeAsync(() => PlayBotTurn(), DispatcherPriority.Background);
			}
		}



		private async void PlayBotTurn()
		{
			if (IsMenuOnScreen() || gameState.IsGameOver())
			{
				return;
			}

			if (gameState.CurrentPlayer == Player.Black)
			{
				//Bot bot = new Bot(BotDifficulty.Medium);
				//Move bestMove = bot.GetBestMove(gameState);
				//if (bestMove != null)
				//{
				//	HandleMove(bestMove);
				//}
				if (currentBot == null) return;

				//Move bestMove = currentBot.GetBestMove(gameState);
				//if (bestMove != null)
				//{
				//	HandleMove(bestMove);
				//}
				// update for run on thread pool
				Move bestMove = await Task.Run(() => currentBot.GetBestMove(gameState));
				if (bestMove != null)
				{
					HandleMove(bestMove);
				}
			}
		}

		private void ShowPopUp()
		{
			PopupPanel.Visibility = Visibility.Visible; // Hiện PopUp
			PlayPopup.StartCountdown(10); // Bắt đầu đếm ngược trong PopUp
		}

        //-------------------------  test menu
        //# region multistep menu
        //	private void ShowStep1()
        //	{
        //		MenuContent.Content = new PlayExitMenu(OnPlayClicked, OnExitClicked);
        //	}

        //	private void ShowStep2()
        //	{
        //		MenuContent.Content = new ModeSelectMenu(OnPvpClicked, OnBotClicked);
        //	}

        //	private void ShowStep3()
        //	{
        //		MenuContent.Content = new DifficultySelectMenu(OnDifficultySelected);
        //	}

        //	private void OnPlayClicked()
        //	{
        //		ShowStep2();
        //	}

        //	private void OnExitClicked()
        //	{
        //		Application.Current.Shutdown();
        //	}

        //	private void OnPvpClicked()
        //	{
        //		MessageBox.Show("Starting Player vs Player game...");
        //		// TODO: Call function StartPvPGame();
        //		MenuContent.Visibility = Visibility.Collapsed; // Ẩn menu

        //		InitializeComponent();

        //		InitializeBoard();

        //		gameState = new GameState(Player.White, Board.Initial());
        //		//gameState = new GameState(Player.Black, Board.Initial());
        //		DrawBoard(gameState.Board);
        //		SetCursor(gameState.CurrentPlayer);

        //	}

        //	private void OnBotClicked()
        //	{
        //		ShowStep3();
        //	}

        //	private void OnDifficultySelected(BotDifficulty difficulty)
        //	{
        //		MessageBox.Show($"Starting game vs Bot - Difficulty: {difficulty}");
        //		// TODO: StartBotGame(difficulty);
        //	}

        //}
        //#endregion

        private void ShowHistoryWindow()
        {
            if (historyWidow == null || !historyWidow.IsVisible)
            {
                historyWidow = new MoveHistoryWindow(moveHistory);
                historyWidow.Owner = this; // Set the owner to ensure it stays on top of the main window
                historyWidow.Left = this.Left + this.Width + 10; // Position it to the right of the main window
                historyWidow.Top = this.Top; // Align it vertically with the main window
                historyWidow.Show();
            }
            else
            {
                historyWidow.Focus(); // Bring the existing window to the front
            }
        }
    }


}