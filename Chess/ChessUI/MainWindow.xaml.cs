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
using System.ComponentModel;
using System.Windows.Media.Effects;
using System.Diagnostics;

namespace ChessUI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window, INotifyPropertyChanged
	{
		private readonly Image[,] pieceImages = new Image[8, 8];
		private readonly Rectangle[,] highlights = new Rectangle[8, 8];
		private readonly Dictionary<Position, Move> moveCache = new Dictionary<Position, Move>();
		private BotDifficulty selectedDifficulty;

		//private readonly Polygon[,] highlights = new Polygon[8, 8]; // Changed to Polygon for better visual effects

		private GameState gameState;
		private Position selectedPos = null;

		private bool playingWithBot = false;

		private ObservableCollection<string> moveHistory = new ObservableCollection<string>();
		private MoveHistoryWindow historyWidow;

		private bool IsOverlayActive = false;

		public static class HighlightColors
		{
			public static readonly SolidColorBrush LegalMove = new SolidColorBrush(Color.FromArgb(128, 125, 255, 125));    // Xanh lá nhạt
			public static readonly SolidColorBrush SelectedPiece = new SolidColorBrush(Color.FromArgb(180, 255, 255, 100)); // Vàng
			public static readonly SolidColorBrush Check = new SolidColorBrush(Color.FromArgb(128, 255, 0, 0));             // Đỏ
			public static readonly SolidColorBrush LastMove = new SolidColorBrush(Color.FromArgb(255, 72, 118, 255));       // Xanh dương nhạt
		}


		public MainWindow()
		{
			InitializeComponent();

			//ShowStep1();
			//SetupWelcomeScreen();

			//LoadWelcomeScreen();

			Debug.WriteLine("MainWindow constructor called");
			SetUpGameMode();

			//         InitializeBoard();

			//gameState = new GameState(Player.White, Board.Initial());
			////gameState = new GameState(Player.Black, Board.Initial());
			//DrawBoard(gameState.Board);
			//SetCursor(gameState.CurrentPlayer);

			//this.Loaded += (s, e) => ShowHistoryWindow();

			//SetUpGameMode();
			//HumanMode();
			//StartGame();
		}

		//      private void InitializeBoard()
		//{
		//	for (int r = 0; r < 8; r++)
		//	{
		//		for (int c = 0; c < 8; c++)
		//		{
		//			Image image = new Image();
		//			pieceImages[r, c] = image;
		//			PieceGrid.Children.Add(image);

		//			Rectangle highlight = new Rectangle();
		//			highlights[r, c] = highlight;
		//			HighlightGrid.Children.Add(highlight);
		//		}
		//	}
		//}


		//setup later
		private void InitializeBoard()
		{
			for (int r = 0; r < 8; r++)
			{
				for (int c = 0; c < 8; c++)
				{
					Image image = new Image();
					pieceImages[r, c] = image;
					PieceGrid.Children.Add(image);

					//var radialBrush = new RadialGradientBrush();
					//radialBrush.GradientOrigin = new Point(0.5, 0.5);
					//radialBrush.Center = new Point(0.5, 0.5);
					////radialBrush.RadiusX = 0.95;
					////radialBrush.RadiusY = 0.95;
					//radialBrush.RadiusX = 1;
					//radialBrush.RadiusY = 1;

					//radialBrush.GradientStops.Add(new GradientStop(Color.FromRgb(254, 0, 0), 0));       // Tâm sáng
					//radialBrush.GradientStops.Add(new GradientStop(Color.FromArgb(0, 254, 0, 0), 1));    // Viền trong suốt



					//               // 3. Tạo ngũ giác
					//               Polygon highlight = new Polygon
					//               {
					//                   Fill = radialBrush,
					//                   HorizontalAlignment = HorizontalAlignment.Center,
					//                   VerticalAlignment = VerticalAlignment.Center
					//               };

					//               // Tính toán kích thước và tọa độ đỉnh
					//               double cellWidth = BoardGrid.Width / 8;
					//               double cellHeight = BoardGrid.Height / 8;
					//               double radius = Math.Min(cellWidth, cellHeight) * 0.5; // ngũ giác nhỏ hơn ô

					//               double centerX = radius; // dùng làm gốc tọa độ trong ô
					//               double centerY = radius;

					//int sides = 8; // Số cạnh của ngũ giác
					//               double angleOffset = Math.PI / sides;

					//               PointCollection points = new PointCollection();
					//               for (int i = 0; i < sides; i++)
					//               {
					//                   double angle = 2 * Math.PI * i / sides + angleOffset;
					//                   double x = centerX + radius * Math.Cos(angle);
					//                   double y = centerY + radius * Math.Sin(angle);
					//                   points.Add(new Point(x, y));
					//               }

					//               highlight.Points = points;
					//               highlights[r, c] = highlight;

					//               // Cho phép vẽ ra ngoài grid nếu cần
					//               HighlightGrid.ClipToBounds = false;

					//               // Thêm vào lưới
					//               HighlightGrid.Children.Add(highlight);

					Rectangle highlight = new Rectangle()
					{
						//Width = 1 * (BoardGrid.Width / 9),  // 80% chiều rộng của 1 ô
						//Height = 1 * (BoardGrid.Height / 9), // 80% chiều cao của 1 ô
						Width = BoardGrid.Width / 9,
						Height = BoardGrid.Height / 9,
						//Fill = radialBrush,
						//RadiusX = 10, // bo góc nếu thích
						//RadiusY = 10,
						HorizontalAlignment = HorizontalAlignment.Center,
						VerticalAlignment = VerticalAlignment.Center,
						//Effect = new DropShadowEffect
						//{
						//	Color = Color.FromRgb(254, 235, 246),
						//	ShadowDepth = 0,
						//	BlurRadius = 30,
						//	Opacity = 10,
						//},
					};
					highlights[r, c] = highlight;
					HighlightGrid.ClipToBounds = false;

					HighlightGrid.Children.Add(highlight);
				}
			}
		}

		private RadialGradientBrush RadialGradientBrush(Color color)
		{
			//         var radialBrush = new RadialGradientBrush();
			//         radialBrush.GradientOrigin = new Point(0.5, 0.5);
			//         radialBrush.Center = new Point(0.5, 0.5);
			//         radialBrush.RadiusX = 0.5;
			//         radialBrush.RadiusY = 0.5;

			////radialBrush.GradientStops.Add(new GradientStop(Color.FromRgb(254, 235, 246), 0));       // Tâm sáng
			////radialBrush.GradientStops.Add(new GradientStop(Color.FromArgb(0, 254, 235, 246), 1));    // Viền trong suốt

			//radialBrush.GradientStops.Add(new GradientStop(color, 0));       // Tâm sáng
			//radialBrush.GradientStops.Add(new GradientStop(Color.FromArgb(0, color.R, color.G, color.B), 1));    // Viền trong suốt

			var radialBrush = new RadialGradientBrush();
			radialBrush.GradientOrigin = new Point(0.5, 0.5);
			radialBrush.Center = new Point(0.5, 0.5);
			radialBrush.RadiusX = 0.7;
			radialBrush.RadiusY = 0.7;

			radialBrush.GradientStops.Add(new GradientStop(color, 0));       // Tâm sáng
			radialBrush.GradientStops.Add(new GradientStop(Color.FromArgb(10, color.R, color.G, color.B), 1));    // Viền trong suốt

			return radialBrush;
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
				//highlights[r, c].Fill = new SolidColorBrush(Color.FromArgb(128, 255, 0, 0));
				//highlights[r, c].Fill = HighlightColors.Check;
				Color color = Color.FromRgb(255, 0, 0);
				highlights[r, c].Fill = RadialGradientBrush(color);
			}

			//highlight last move
			if (gameState.LastMove != null)
			{
				var fromPos = gameState.LastMove.FromPos;
				var toPos = gameState.LastMove.ToPos;

				//highlights[fromPos.Row, fromPos.Column].Fill = new SolidColorBrush(Color.FromArgb(128, 72, 118, 255));
				//highlights[fromPos.Row, fromPos.Column].Fill = HighlightColors.LastMove;
				highlights[fromPos.Row, fromPos.Column].Fill = RadialGradientBrush(HighlightColors.LastMove.Color);
				//highlights[toPos.Row, toPos.Column].Fill = new SolidColorBrush(Color.FromArgb(128, 72, 118, 255));
				//highlights[toPos.Row, toPos.Column].Fill = HighlightColors.LastMove;
				highlights[toPos.Row, toPos.Column].Fill = RadialGradientBrush(HighlightColors.LastMove.Color);
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
			if (IsOverlayActive)
			{
				e.Handled = true; return;
			}

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
			HideHighlights();
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

			//string moveString = move.ToString();
			//moveHistory.Add(moveString);
			string formattedMove = FormatMove(move, moveHistory.Count);
			moveHistory.Add(formattedMove);


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

			Color moveColor = Color.FromArgb(150, 255, 128, 255); //pink
			Color captureColor = Color.FromArgb(200, 255, 255, 0);
			Color selectedColor = Color.FromArgb(180, 255, 255, 0);
			Color selectPiece = Color.FromArgb(255, 255, 255, 255);


			foreach (var kvp in moveCache)
			{
				Position to = kvp.Key;
				Move move = kvp.Value;

				Piece targetPiece = gameState.Board[to];
				if (targetPiece != null && targetPiece.Color != gameState.CurrentPlayer)
				{
					//highlights[to.Row, to.Column].Fill = new SolidColorBrush(captureColor);
					highlights[to.Row, to.Column].Fill = RadialGradientBrush(captureColor);
				}
				else
				{
					//highlights[to.Row, to.Column].Fill = new SolidColorBrush(moveColor);
					highlights[to.Row, to.Column].Fill = RadialGradientBrush(moveColor);
				}
			}


			if (selectedPos != null)
				//highlights[selectedPos.Row, selectedPos.Column].Fill = new SolidColorBrush(selectedColor);
				//highlights[selectedPos.Row, selectedPos.Column].Fill = new SolidColorBrush(Color.FromArgb(255,255,255,255));

				highlights[selectedPos.Row, selectedPos.Column].Fill = RadialGradientBrush(selectPiece);


		}


		// set up later
		//private void ShowHighlights()
		//{
		//    //Color color = Color.FromArgb(150, 125, 255, 125);

		//    //foreach (Position to in moveCache.Keys)
		//    //{
		//    //	highlights[to.Row, to.Column].Fill = new SolidColorBrush(color);
		//    //}

		//    Color moveColor = Color.FromArgb(150, 125, 255, 125);
		//    Color captureColor = Color.FromArgb(180, 255, 100, 100);
		//    Color selectedColor = Color.FromArgb(180, 255, 255, 0);

		//    foreach (var kvp in moveCache)
		//    {
		//        Position to = kvp.Key;
		//        Move move = kvp.Value;

		//        Piece targetPiece = gameState.Board[to];
		//        if (targetPiece != null && targetPiece.Color != gameState.CurrentPlayer)
		//        {
		//            highlights[to.Row, to.Column].Fill = new SolidColorBrush(captureColor);
		//        }
		//        else
		//        {
		//            highlights[to.Row, to.Column].Fill = new SolidColorBrush(moveColor);
		//        }
		//    }
		//    if (selectedPos != null)
		//    //highlights[selectedPos.Row, selectedPos.Column].Fill = new SolidColorBrush(selectedColor);
		//    {
		//        highlights[selectedPos.Row, selectedPos.Column].Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
		//        highlights[selectedPos.Row, selectedPos.Column].Effect = new DropShadowEffect
		//        {
		//            Color = Colors.Red,
		//            BlurRadius = 50,
		//            ShadowDepth = 0,
		//            Opacity = 12,
		//        };

		//    }

		//}


		private void HideHighlights()
		{
			for (int r = 0; r < 8; r++)
			{
				for (int c = 0; c < 8; c++)
				{
					highlights[r, c].Fill = Brushes.Transparent;
					highlights[r, c].Stroke = null;
				}
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
			//IsOverlayActive = true;
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
			int playerElo = PlayerData.LoadElo();
			//var bot = new Bot(playerElo)
			//IsOverlayActive = false;
			playingWithBot = true;
			selectedPos = null;
			HideHighlights();
			moveCache.Clear();
			gameState = new GameState(Player.White, Board.Initial());
			DrawBoard(gameState.Board);
			SetCursor(gameState.CurrentPlayer);
			ShowHistoryWindow();
			//IsOverlayActive = false;
			currentBot = new Bot(selectedDifficulty, playerElo: playerElo);

			if (gameState.CurrentPlayer == Player.Black)
			{
				Dispatcher.InvokeAsync(() => PlayBotTurn(), DispatcherPriority.Background);
			}
			Debug.WriteLine($"Bot started with difficulty: {selectedDifficulty} and Elo: {playerElo}");
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
			IsOverlayActive = true;
			PopupPanel.Visibility = Visibility.Visible; // Hiện PopUp
			PlayPopup.StartCountdown(10); // Bắt đầu đếm ngược trong PopUp
			PlayPopup.CountdownFinished += (_, __) =>
			{
				IsOverlayActive = false;
			};
		}


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

		private string FormatMove(Move move, int moveCount)
		{
			string player = (moveCount % 2 == 0) ? "White" : "Black";
			return $"{player}: {move.FromPos}  → {move.ToPos}";
		}


		private object _currentScreen;
		private GameMode _welcomeScreen;


		public event PropertyChangedEventHandler PropertyChanged;


		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}


		public void BotMode()
		{
			CloseGameMode();
			try
			{
				InitializeBoard();
				ShowBot();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error starting Bot mode: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);


			}
		}

		public void HumanMode()
		{
			CloseGameMode();
			ShowPopUp();
			//GameModeContent.Content = null; // Clear the game mode content
			//MessageBox.Show("Starting Human vs Human game...", "Information", MessageBoxButton.OK);
			InitializeBoard();

			gameState = new GameState(Player.White, Board.Initial());
			//gameState = new GameState(Player.Black, Board.Initial());
			DrawBoard(gameState.Board);
			SetCursor(gameState.CurrentPlayer);

			ShowHistoryWindow();
		}

		private GameMode gameModeControl;
		private void SetUpGameMode()
		{

			gameModeControl = new GameMode();

			gameModeControl.BotModeRequested += (sender, e) => BotMode();
			gameModeControl.HumanModeRequested += (sender, e) => HumanMode();

			GameModeContent.Content = gameModeControl; // Add to the main content area
													   //ShowOverlay();
													   //GameModeContent.Visibility = Visibility.Visible;
			IsOverlayActive = true;
			GameModePanel.Visibility = Visibility.Visible;
		}

		public void CloseGameMode()
		{
			GameModeContent.Content = null;
			IsOverlayActive = false;
			GameModePanel.Visibility = Visibility.Hidden;
			//HideOverlay();
		}

		private void UpdateElo(bool playerWon)
		{
			int playerElo = PlayerData.LoadElo();
			int botElo = 1200;

			int k = 32;
			double expected = 1 / (1 + Math.Pow(10, (botElo - playerElo) / 400.0));
			int newElo = (int)(playerElo + k * ((playerWon ? 1 : 0) - expected));


			PlayerData.SaveElo(newElo);

			/// elo show - create ui for this later
			MessageBox.Show($"Your new Elo rating is: {newElo}", "Elo Update", MessageBoxButton.OK, MessageBoxImage.Information);
		}
	}
}