using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ChessDisplay
{
    /// <summary>
    /// Interaction logic for ChessSquare.xaml
    /// </summary>
    public partial class ChessSquare : UserControl
    {
        public readonly SolidColorBrush DefaultBackground;

        private bool IsSelected = false;

        public ChessSquare(bool grey)
        {
            InitializeComponent();
            DefaultBackground = new SolidColorBrush(grey ? Colors.Gray : Colors.White);
            Square.Background = DefaultBackground;
            this.MouseEnter += Square_Enter;
            this.MouseLeave += Square_Leave;

        }

        public void ToggleIsSelected() {
            IsSelected = !IsSelected;
        }

        public void SetPicture(BitmapImage image)
        {
            ChessPieceImage.Source = image;
        }

        private void Square_Enter(object sender, MouseEventArgs e) {
            Square.Background = new SolidColorBrush(Colors.Blue);
        }

        private void Square_Leave(object sender, MouseEventArgs e) {
            //return to default value
            Square.Background = DefaultBackground;
        }

    }
}
