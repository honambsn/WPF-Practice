using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Go.UI.Board
{
    public class BoardInteractionController
    {
        private readonly Canvas canvas;
        private readonly Canvas stoneCanvas;
        private readonly int boardSize;
        private readonly Func<double> getCellSize;
        private readonly Action<int, int> onClick;

        private readonly Func<Brush> getCurrentBrush;
        private readonly Func<int, int, bool> canPlace;

        private Ellipse previewStone;

        public BoardInteractionController(
            Canvas canvas,
            Canvas stoneCanvas,
            int boardSize,
            Func<double> getCellSize,
            Func<Brush> getCurrentBrush,
            Func<int, int, bool> canPlace,
            Action<int, int> onClick)
        {
            this.canvas = canvas;
            this.stoneCanvas = stoneCanvas;
            this.boardSize = boardSize;
            this.getCellSize = getCellSize;
            this.getCurrentBrush = getCurrentBrush;
            this.canPlace = canPlace;
            this.onClick = onClick;
        }

        public void Initialize()
        {
            canvas.Children.Clear();
            stoneCanvas.Children.Clear();

            double cellSize = getCellSize();
            double offset = cellSize;

            // preview
            previewStone = new Ellipse()
            {
                Width = cellSize * 0.8,
                Height = cellSize * 0.8,
                Opacity = 0.5,
                Visibility = System.Windows.Visibility.Hidden,
                IsHitTestVisible = false,
            };

            //stoneCanvas.Children.Clear();
            stoneCanvas.Children.Add(previewStone);
            Panel.SetZIndex(previewStone, 999);

            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    var border = new Border
                    {
                        Width = cellSize * 0.9,
                        Height = cellSize * 0.9,
                        Background = Brushes.Transparent,
                        Cursor = Cursors.Hand,
                        Tag = (row, col)
                    };

                    border.MouseEnter += Hover;
                    border.MouseLeave += Leave;

                    border.MouseLeftButtonDown += Click;

                    double centerX = offset + col * cellSize;
                    double centerY = offset + row * cellSize;

                    Canvas.SetLeft(border, centerX - cellSize / 2);
                    Canvas.SetTop(border, centerY - cellSize / 2);

                    canvas.Children.Add(border);
                }
            }
        }

        private void Click(object sender, MouseButtonEventArgs e)
        {
            //var border = sender as Border;
            //var (row, col) = ((int, int))border.Tag;
            if (sender is not Border border || border.Tag is not ValueTuple<int, int> pos) return;
            var (row, col) = pos;

            if (!canPlace(row, col)) return;

            HidePreview();
            onClick(row, col);
        }

        private void Hover(object sender, MouseEventArgs e)
        {
            //var border = sender as Border;
            //var (row, col) = ((int, int))border.Tag;
            if (sender is not Border border || border.Tag is not ValueTuple<int, int> pos) return;
            var (row, col) = pos;

            if (!canPlace(row, col))
            {
                HidePreview();
                return;
            }
            
            ShowPreview(row, col);
        }

        private void Leave(object sender, MouseEventArgs e)
        {
            HidePreview();
        }

        private void ShowPreview(int row, int col)
        {
            double cellSize = getCellSize();
            double offset = cellSize;

            double stoneSize = cellSize * 0.8;

            previewStone.Width = stoneSize;
            previewStone.Height = stoneSize;

            previewStone.Fill = getCurrentBrush();

            double centerX = offset + col * cellSize;
            double centerY = offset + row * cellSize;

            Canvas.SetLeft(previewStone, centerX - stoneSize / 2);
            Canvas.SetTop(previewStone, centerY - stoneSize / 2);

            previewStone.Visibility = System.Windows.Visibility.Visible;
        }

        private void HidePreview()
        {
            if (previewStone != null)
            {
                previewStone.Visibility = System.Windows.Visibility.Hidden;
            }
        }
    }
}
