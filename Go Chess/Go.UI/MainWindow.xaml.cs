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
        public partial class MainWindow : Window
        {

            private readonly Ellipse[,] stones = new Ellipse[19, 19];
            private const int _BoardSize = 19;
            private double cellSize;
            private bool isBlackTurn = true;

            public MainWindow()
            {
                InitializeComponent();
                Loaded += MainWindow_Loaded;
            }

            private void MainWindow_Loaded(object sender, RoutedEventArgs e)
            {
                DrawBoard();
                InitializeIntersections();
            }

            private List<(int row, int col)> GetStarPoints(int size)
            {
                var points = new List<(int, int)>();

                if (size == 9) // ignore
                {
                    int offset = 2;
                    int center = size / 2;

                    points.Add((offset, center));
                    points.Add((offset, size - 1 - offset));
                    points.Add((size - 1 - offset, offset));
                    points.Add((size - 1 - offset, size - 1 - offset));
                    points.Add((center, center));
                }
                else if (size == 13 || size == 19)
                {
                    int offset = 3;
                    int center = size / 2;

                    int[] coords = { offset, center, size - 1 - offset };

                    foreach (int r in coords)
                        foreach (int c in coords)
                            points.Add((r, c));
                }
                return points;
            }

            private void DrawBoard()
            {
                BoardCanvas.Children.Clear();

                // Tính cellSize dựa trên kích thước canvas
                cellSize = Math.Min(BoardCanvas.ActualWidth, BoardCanvas.ActualHeight) / (_BoardSize + 1);
                double offset = cellSize; // Margin xung quanh board

                // Vẽ các đường kẻ
                for (int i = 0; i < _BoardSize; i++)
                {
                    double pos = offset + i * cellSize;

                    // Đường ngang
                    var hLine = new Line
                    {
                        X1 = offset,
                        Y1 = pos,
                        X2 = offset + (_BoardSize - 1) * cellSize,
                        Y2 = pos,
                        Stroke = Brushes.Black,
                        StrokeThickness = 1.5
                    };
                    BoardCanvas.Children.Add(hLine);

                    // Đường dọc
                    var vLine = new Line
                    {
                        X1 = pos,
                        Y1 = offset,
                        X2 = pos,
                        Y2 = offset + (_BoardSize - 1) * cellSize,
                        Stroke = Brushes.Black,
                        StrokeThickness = 1.5
                    };
                    BoardCanvas.Children.Add(vLine);
                }

                // Vẽ star points (các điểm đặc biệt trên bàn cờ Go)
                //int[] starPoints = { 3, 6, 9 }; // Cho bàn 13x13

                var starPoints = GetStarPoints(_BoardSize);

                foreach (var (row, col) in starPoints)
                {
                    double starSize = cellSize * 0.2;

                    var starPoint = new Ellipse
                    {
                        Width = starSize,
                        Height = starSize,
                        Fill = Brushes.Black
                    };

                    Canvas.SetLeft(starPoint, offset + col * cellSize - 2);
                    Canvas.SetTop(starPoint, offset + row * cellSize - 2);

                    BoardCanvas.Children.Add(starPoint);
                }
            }

            private void InitializeIntersections()
            {
                IntersectionGrid.Children.Clear();

                double offset = cellSize;

                for (int row = 0; row < _BoardSize; row++)
                {
                    for (int col = 0; col < _BoardSize; col++)
                    {
                        // Tạo vùng click cho mỗi giao điểm
                        var intersection = new Border
                        {
                            Width = cellSize * 0.9,
                            Height = cellSize * 0.9,
                            Background = Brushes.Transparent,
                            Tag = (row, col),
                            Cursor = Cursors.Hand
                        };

                        // Highlight khi hover
                        var highlight = new Ellipse
                        {
                            Fill = new SolidColorBrush(Color.FromArgb(50, 100, 100, 100)),
                            Visibility = Visibility.Collapsed
                        };
                        intersection.Child = highlight;

                        intersection.MouseEnter += (s, e) =>
                        {
                            var border = s as Border;
                            var (r, c) = ((int, int))border.Tag;
                            if (stones[r, c] == null)
                            {
                                (border.Child as Ellipse).Visibility = Visibility.Visible;
                            }
                        };

                        intersection.MouseLeave += (s, e) =>
                        {
                            ((s as Border).Child as Ellipse).Visibility = Visibility.Collapsed;
                        };

                        intersection.MouseLeftButtonDown += Intersection_Click;

                        Canvas.SetLeft(intersection, offset + col * cellSize - cellSize * 0.45);
                        Canvas.SetTop(intersection, offset + row * cellSize - cellSize * 0.45);

                        IntersectionGrid.Children.Add(intersection);
                    }
                }
            }

            private void Intersection_Click(object sender, MouseButtonEventArgs e)
            {
                var intersection = sender as Border;
                var (row, col) = ((int, int))intersection.Tag;

                // Kiểm tra đã có quân cờ chưa
                if (stones[row, col] != null)
                    return;

                PlaceStone(row, col, isBlackTurn ? Brushes.Black : Brushes.White);
                isBlackTurn = !isBlackTurn;
            }

            private void PlaceStone(int row, int col, Brush color)
            {
                double offset = cellSize;
                double stoneSize = cellSize * 0.85;

                var stone = new Ellipse
                {
                    Width = stoneSize,
                    Height = stoneSize,
                    Fill = color,
                    Stroke = Brushes.Gray,
                    StrokeThickness = 1
                };

                // Thêm shadow effect
                stone.Effect = new System.Windows.Media.Effects.DropShadowEffect
                {
                    BlurRadius = 5,
                    ShadowDepth = 2,
                    Opacity = 0.5
                };

                Canvas.SetLeft(stone, offset + col * cellSize - stoneSize / 2);
                Canvas.SetTop(stone, offset + row * cellSize - stoneSize / 2);

                StoneCanvas.Children.Add(stone);
                stones[row, col] = stone;
            }

            private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
            {
                // Khi window resize, vẽ lại board
                if (IsLoaded)
                {
                    DrawBoard();
                    InitializeIntersections();
                    RedrawStones();
                }
            }

            private void RedrawStones()
            {
                StoneCanvas.Children.Clear();

                for (int row = 0; row < _BoardSize; row++)
                {
                    for (int col = 0; col < _BoardSize; col++)
                    {
                        if (stones[row, col] != null)
                        {
                            var originalStone = stones[row, col];
                            stones[row, col] = null;
                            PlaceStone(row, col, originalStone.Fill);
                        }
                    }
                }
            }

            private void Window_KeyDownn(object sender, KeyEventArgs e)
            {
                // Phím R để reset board
                if (e.Key == Key.R)
                {
                    ResetBoard();
                }
            }

            private void ResetBoard()
            {
                StoneCanvas.Children.Clear();
                for (int row = 0; row < _BoardSize; row++)
                {
                    for (int col = 0; col < _BoardSize; col++)
                    {
                        stones[row, col] = null;
                    }
                }
                isBlackTurn = true;
            }
        }
    }