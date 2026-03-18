using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Go.UI.Board
{
    public class StoneRenderer
    {
        public void DrawStone(Canvas canvas,
                                int row,
                                int col,
                                double cellSize,
                                Brush color)
        {
            double stoneSize = cellSize * 0.85;
            double offset = cellSize;

            var stone = new Ellipse
            {
                Width = stoneSize,
                Height = stoneSize,
                Fill = color,
                Stroke = Brushes.Gray,
                StrokeThickness = 1,
            };

            Canvas.SetLeft(stone, offset + col * cellSize - stoneSize / 2);
            Canvas.SetTop(stone, offset + row * cellSize - stoneSize / 2);

            canvas.Children.Add(stone);
        }
    }
}
