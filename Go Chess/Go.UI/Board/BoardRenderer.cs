using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Go.UI.Board
{
    public class BoardRenderer
    {
        public double CellSize { get; private set; }
        public void Draw(Canvas canvas, int boardSize)
        {
            canvas.Children.Clear();

            CellSize = Math.Min(canvas.ActualWidth, canvas.ActualHeight) / (boardSize + 1);
            double offset = CellSize;

            for (int i = 0; i < boardSize; i++)
            {
                double pos = offset + i * CellSize;

                var hLine = new Line
                {
                    X1 = offset,
                    Y1 = pos,
                    X2 = offset + (boardSize - 1) * CellSize,
                    Y2 = pos,
                    Stroke = Brushes.Black,
                    StrokeThickness = 1.5

                };

                canvas.Children.Add(hLine);

                var vLine = new Line
                {
                    X1 = pos,
                    Y1 = offset,
                    X2 = pos,
                    Y2 = offset + (boardSize - 1) * CellSize,
                    Stroke = Brushes.Black,
                    StrokeThickness = 1.5

                };

                canvas.Children.Add(vLine);
            }

            var starPoints = GetStarPoints(boardSize);

            foreach (var (row, col) in starPoints)
            {
                double starSize = CellSize * 0.2;

                var starPoint = new Ellipse
                {
                    Width = starSize,
                    Height = starSize,
                    Fill = Brushes.Black
                };

                Canvas.SetLeft(starPoint, offset + col * CellSize - 2);
                Canvas.SetTop(starPoint, offset + row * CellSize - 2);

                canvas.Children.Add(starPoint);
            }

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
    }
}
