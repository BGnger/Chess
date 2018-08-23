using File_IO.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChessDisplay
{
    /// <summary>
    /// Interaction logic for ChessBoardControl.xaml
    /// </summary>
    public partial class ChessBoardControl : UserControl
    {
        private Board board;

        public Board Board {
            get { return board; }
            set { board = value;
                SetUpBoard();
            }
        }

        public ChessBoardControl()
        {
            InitializeComponent();
        }

        private void SetUpBoard()
        {
            ChessSquare chessSquare;
            bool grey = false;
            for (int column = 0; column < 8; column++)
            {
                for (int row = 0; row < 8; row++)
                {
                    chessSquare = new ChessSquare(grey);
                    chessSquare.SetValue(Grid.ColumnProperty, column);
                    chessSquare.SetValue(Grid.RowProperty, row);


                    chessSquare.SetPicture(board[row, column]?.BitmapImage);

                    BoardDisplay.Children.Add(chessSquare);
                    grey = !grey;
                }
                grey = !grey;
            }
        }
    }
}
