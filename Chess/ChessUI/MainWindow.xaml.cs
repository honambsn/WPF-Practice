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
using ChessLogic.Helper.PGN;
using static ChessLogic.Helper.PGN.PGNReader;

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
			////var pgnReader = new readPGN();
			//string input_ = "D:\\Ba Nam\\Own project\\Practice\\c#\\WPF Practice\\Chess\\ChessAI\\Utilities\\file.pgn";
			////pgnReader.DisplayGameDetails();

			//string output = "D:\\Ba Nam\\Own project\\Practice\\c#\\WPF Practice\\Chess\\ChessAI\\Utilities\\output.pgn";
			////pgnReader.SaveToPGN(output);

			//var moves = PGNReader.ReadMovesFromPGN(input_);
			//foreach (var move in moves)
			//{
			//	Debug.WriteLine(move);
			//}

			//Debug.WriteLine("PGN moves read successfully.");


			//Debug.WriteLine("Multi PGN games.");

			//try
			//{
			//	string input_ = "D:\\Ba Nam\\Own project\\Practice\\c#\\WPF Practice\\Chess\\ChessAI\\Utilities\\master_games.pgn";

			//	Debug.WriteLine($"read files");
			//	var games = PGNReader.ReadGamesFromPGN(input_);

			//	int i = 1;
			//	foreach (var game in games)
			//	{
   //                 Debug.WriteLine($"Game {i++}:");
   //                 Debug.WriteLine(string.Join("\n", game));
			//		Debug.WriteLine("------");
			//	}

			//}
			//catch
			//{
			//	Debug.WriteLine("Error reading PGN file.");
			//}



			Debug.WriteLine("MainWindow constructor called");

			string filePath = "D:\\Ba Nam\\Own project\\Practice\\c#\\WPF Practice\\Chess\\ChessAI\\Utilities\\master_games.pgn";
			string pgnContent = System.IO.File.ReadAllText(filePath);

            // Parse the PGN content and extract the games with metadata and moves
            List<Game> games = PGN.ExtractGamesFromPGN(pgnContent);


            // Print the metadata and moves for each game
            foreach (var game in games)
            {
                Debug.WriteLine($"Event: {game.Event}");
                Debug.WriteLine($"Date: {game.Date}");
                Debug.WriteLine($"White: {game.White}");
                Debug.WriteLine($"Black: {game.Black}");
                Debug.WriteLine($"Result: {game.Result}");
                Debug.WriteLine("Moves:");
                Debug.WriteLine(game.Moves);
                Debug.WriteLine("\n");
            }



            //#region test readpgn
            //// Example 1: Get moves for a single game and display them in the console
            //string filePath = "D:\\Ba Nam\\Own project\\Practice\\c#\\WPF Practice\\Chess\\ChessAI\\Utilities\\ReadMovesFromPGN.pgn";
            //         List<string> singleGameMoves = GetSingleGameMoves(filePath);
            //         if (singleGameMoves != null)
            //         {
            //             Debug.WriteLine("Moves for a single game:");
            //             foreach (var move in singleGameMoves)
            //             {
            //                 Debug.WriteLine(move);
            //             }
            //         }

            //// Example 2: Get all games in the PGN and display them in the console
            //filePath = "D:\\Ba Nam\\Own project\\Practice\\c#\\WPF Practice\\Chess\\ChessAI\\Utilities\\ReadPGN.pgn";
            //         List<List<string>> allGames = GetAllGames(filePath);
            //         if (allGames != null)
            //         {
            //             Debug.WriteLine("Moves for all games:");
            //             foreach (var game in allGames)
            //             {
            //                 Debug.WriteLine("New game:");
            //                 Debug.WriteLine(string.Join(" ", game));
            //             }
            //         }

            //         // Example 3: Get all games with time annotations removed and display them in the console
            //filePath = "D:\\Ba Nam\\Own project\\Practice\\c#\\WPF Practice\\Chess\\ChessAI\\Utilities\\master_games.pgn";
            //         List<List<string>> gamesWithoutTime = GetGamesWithoutTime(filePath);
            //         if (gamesWithoutTime != null)
            //         {
            //             Debug.WriteLine("Moves for all games (without time annotations):");
            //	int i = 1;
            //             foreach (var game in gamesWithoutTime)
            //             {

            //		Debug.WriteLine($"Game {i++}:");
            //                 //Debug.WriteLine("New game:");
            //                 Debug.WriteLine(string.Join(" ", game));
            //             }
            //         }

            //         // Example 4: Get all moves for all games and display them in the console
            //         filePath = "D:\\Ba Nam\\Own project\\Practice\\c#\\WPF Practice\\Chess\\ChessAI\\Utilities\\ReadMovesPGN.pgn";
            //         List<List<string>> allGameMoves = GetAllGameMoves(filePath);
            //         if (allGameMoves != null)
            //         {
            //             Debug.WriteLine("Moves for all games:");
            //             foreach (var gameMoves in allGameMoves)
            //             {
            //                 Debug.WriteLine("New game:");
            //                 Debug.WriteLine(string.Join(" ", gameMoves));
            //             }
            //         }
            //         #endregion

            //SetUpGameMode();

        }

        #region test readpgn func
        // Function to read moves for a single game
        private List<string> GetSingleGameMoves(string filePath)
        {
            try
            {
                Debug.WriteLine($"Reading moves from PGN file: {filePath}");
                return PGNReader.ReadMovesFromPGN(filePath);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error reading moves from PGN: {ex.Message}");
                return null;
            }
        }

        // Function to read all games in the PGN file (with metadata)
        private List<List<string>> GetAllGames(string filePath)
        {
            try
            {
                Debug.WriteLine($"Reading all games from PGN file: {filePath}");
                return PGNReader.ReadPGN(filePath);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error reading games from PGN: {ex.Message}");
                return null;
            }
        }

        // Function to read all games and remove time annotations
        private List<List<string>> GetGamesWithoutTime(string filePath)
        {
            try
            {
                Debug.WriteLine($"Reading all games from PGN file (without time): {filePath}");
                return PGNReader.ReadGamesFromPGN(filePath);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error reading games from PGN (without time): {ex.Message}");
                return null;
            }
        }

        // Function to read all moves for all games
        private List<List<string>> GetAllGameMoves(string filePath)
        {
            try
            {
				Debug.WriteLine($"Reading all moves from PGN file: {filePath}");
                return PGNReader.ReadMovesPGN(filePath);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error reading moves for all games: {ex.Message}");
                return null;
            }
        }
        #endregion

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
			Debug.WriteLine("Drawing board debugginggggg..............");
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
                Color color = Color.FromRgb(255, 0, 0);
                highlights[r, c].Fill = RadialGradientBrush(color);
                //highlights[r, c].Fill = HighlightColors.Check;
                //Color color = Color.FromRgb(255, 0, 0);
                //highlights[r, c].Fill = new SolidColorBrush(color);
            }

			if (board.IsInCheck(Player.Black))
			{
				Debug.WriteLine("opponent King is in check");
			}
			else if (board.IsInCheck(Player.White))
			{
				Debug.WriteLine("ur King is in check");
			}
			else
			{
				Debug.WriteLine("No King is in check");
			}

			if (checkedKingPos != null)
			{
				Debug.WriteLine($"Checked King Position: {checkedKingPos}");
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
                Debug.WriteLine($"From Mainwindow xaml ");
                Debug.WriteLine($"Promotion Menu opened for {gameState.CurrentPlayer} at {from} to {to}");


                MenuContent.Content = null;
				Move promMove = new PawnPromotion(from, to, type);
				HandleMove(promMove);
				
				if (gameState.CheckedKingPosition != null)
                {
                    Debug.WriteLine($"From handle promotion xaml ");
                    Debug.WriteLine($"Checked King Position: {gameState.CheckedKingPosition}");
//					highlights[gameState.CheckedKingPosition.Row, gameState.CheckedKingPosition.Column].Fill = RadialGradientBrush(Color.FromRgb(255, 0, 0));
                }
                else
                {
                    Debug.WriteLine($"From handle promotion xaml ");
                    Debug.WriteLine($"No King is checked after promote");
                }
            };
        }

		private void HandleMove(Move move)
		{
            string formattedMove = FormatMove(move, moveHistory.Count);
            Debug.WriteLine($"Formatted Move: {formattedMove}");
            gameState.MakeMove(move);

			//string moveString = move.ToString();
			//moveHistory.Add(moveString);
			
            moveHistory.Add(formattedMove);


            Application.Current.Dispatcher.Invoke(() => DrawBoard(gameState.Board));

            SetCursor(gameState.CurrentPlayer);

			Debug.WriteLine($"the bot mode check flag:  {botModeFlag}");

			if (gameState.IsGameOver())
			{
				if (gameState.Result.Reason == EndReason.Checkmate)
				{
					bool playerWon = true;

					Debug.WriteLine($"playerWon: {playerWon}");

					if (gameState.Result.Winner == Player.White)
					{
						playerWon = true;
                        Debug.WriteLine($"Game Over: Checkmate, Winner: White");
						Debug.WriteLine($"Write: {playerWon}");
                    }
                    else if (gameState.Result.Winner == Player.Black)
					{
                        playerWon = false;
                        Debug.WriteLine($"Game Over: Checkmate, Winner: Black");
                        Debug.WriteLine($"Write: {playerWon}");
                    }

					if (botModeFlag == true)
					{
						int currElo = PlayerData.LoadElo();
						//
						Debug.WriteLine($"Current Bot: {currentBot.BotElo}");
						int newElo = PlayerData.UpdateEloAfterMatch(currElo, currentBot.botElo, playerWon);

						Debug.WriteLine($"Elo updated: {currElo} -> {newElo}");
						Debug.WriteLine($"Game Over: {gameState.Result.Reason}, Winner: {gameState.Result.Winner}");
						Debug.WriteLine($"Write: {playerWon}");
						//, currElo, newElo);
						Debug.WriteLine($"Write: {currElo}");
						Debug.WriteLine($"Write: {newElo}");
					}
					else
					{
						Debug.WriteLine($"Game Over: {gameState.Result.Reason}, Winner: {gameState.Result.Winner}, in Human Mode");
					}

                }
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
			//SetUpGameMode();
		}

		private void Window_KeyDown(object sender, KeyEventArgs e)
		{
			if (!IsMenuOnScreen() && e.Key == Key.Escape)
			{
				ShowPauseMenu();
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
			Debug.WriteLine($"Mainwindow - Player Elo: {playerElo}");
			//int playerElo = 4000;
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
			currentBot = new Bot(selectedDifficulty, playerElo);

			if (gameState.CurrentPlayer == Player.Black)
			{
				Dispatcher.InvokeAsync(() => PlayBotTurn(), DispatcherPriority.Background);
			}
			Debug.WriteLine($"Bot started with difficulty: {selectedDifficulty} and Elo: {playerElo}");

			Debug.WriteLine($"Bot currentBot: {currentBot.BotElo} - Difficulty: {currentBot.botElo} - Player Elo: {playerElo}");
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

			Piece piece = gameState.Board[move.FromPos];

            //string pieceType = StateHelper.GetPieceSymbol(piece);

			string notation = AlgebraicNotationHelper.ToAlgebraicNotation(move, gameState);


			// debug info
			Debug.WriteLine($"Algebraic Notation: {notation}");
            Debug.WriteLine($"FromPos: {move.FromPos}, Piece: {gameState.Board[move.FromPos]}");

            //Debug.WriteLine($"Piece Type:   {pieceType}");
            //return $"{player} {piece} {move.FromPos} → {move.ToPos}";
            //return $"{player}: {move.FromPos}  → {move.ToPos}";

            //return $"{player}: { notation}";
            return $"{player}: {notation} ({move.FromPos} → {move.ToPos})";

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
                botModeFlag = true;
                InitializeBoard();
				ShowBot();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error starting Bot mode: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);


			}
		}

		private bool botModeFlag = false;
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