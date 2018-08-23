using File_IO.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using WpfApp1;

namespace ChessDisplay
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Board board;

        public MainWindow()
        {
            InitializeComponent();
            board = new Board();
            ChessBoard.Board = board;
        }
    }
}
