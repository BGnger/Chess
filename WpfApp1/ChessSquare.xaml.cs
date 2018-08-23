using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ChessDisplay
{
    /// <summary>
    /// Interaction logic for ChessSquare.xaml
    /// </summary>
    public partial class ChessSquare : UserControl
    {
        public ChessSquare(bool grey)
        {
            InitializeComponent();

            if (grey)
                Square.Background = new SolidColorBrush(Colors.Gray);
            else
                Square.Background = new SolidColorBrush(Colors.White);
        }

        public void SetPicture(BitmapImage image)
        {
            ChessPieceImage.Source = image;
        }
    }
}
