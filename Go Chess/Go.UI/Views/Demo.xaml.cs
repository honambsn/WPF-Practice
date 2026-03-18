using Go.Application.Game;
using Go.Domain.Enums;
using Go.UI.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Go.UI
{
    /// <summary>
    /// Interaction logic for Demo.xaml
    /// </summary>
    public partial class Demo : Window
    {
        private const int BoardSize = 19;

        private readonly GameManager game = new();
        private readonly BoardRenderer boardRenderer = new();
        private readonly StoneRenderer stoneRenderer;

        private BoardInteractionController input;

        private Ellipse _previewStone;

        public Demo()
        {
            InitializeComponent();
            stoneRenderer = new StoneRenderer();

            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            InitBoard();
        }

        private void InitBoard()
        {
            boardRenderer.Draw(BoardCanvas, BoardSize);

            input = new BoardInteractionController(
                IntersectionGrid,
                StoneCanvas,
                BoardSize,
                () => boardRenderer.CellSize,
                () => game.CurrentTurn == StoneColor.Black
                        ? Brushes.Black
                        : Brushes.White,
                (r, c) => game.Board.GetStone(r, c) == null,
                Intersection_Click);

            input.Initialize();
        }

        private void Intersection_Click(int row, int col)
        {
            if (!game.PlayMove(row, col, out var color))
                return;

            var brush = color == StoneColor.Black
                ? Brushes.Black
                : Brushes.White;

            stoneRenderer.DrawStone(
                StoneCanvas,
                row,
                col,
                boardRenderer.CellSize,
                brush);

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            // Phím R để reset board
            if (e.Key == Key.R)
            {
                game.Reset();
                StoneCanvas.Children.Clear();
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (!IsLoaded) return;

            InitBoard();
            RedrawStones();
        }

        private void RedrawStones()
        {
            StoneCanvas.Children.Clear();

            for (int r = 0; r < BoardSize; r++)
                for (int c = 0; c < BoardSize; c++)
                {
                    var stone = game.Board.GetStone(r, c);
                    if (stone == null)
                        continue;

                    var brush = stone == StoneColor.Black
                        ? Brushes.Black
                        : Brushes.White;

                    stoneRenderer.DrawStone(
                        StoneCanvas,
                        r,
                        c,
                        boardRenderer.CellSize,
                        brush);
                }
        }
    }
}