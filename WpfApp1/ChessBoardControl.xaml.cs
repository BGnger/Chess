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

        public bool SelectingMove { get; set; }

        public KeyValuePair<int, int> ChessSquarePair { get; set; }

        public ChessBoardControl()
        {
            InitializeComponent();
        }

        public void ToggleSelectingMove(ChessSquare square)
        {
            SelectingMove = !SelectingMove;
            SelectMoveView(square);
        }

        private void SelectMoveView(ChessSquare square) {
            int x = square.XPos;
            int y = square.YPos;
            DisplayAllPossibleMoves(x, y);
        }

        private void DisplayAllPossibleMoves(int x, int y) {
            List<int[]> ListOfMoves = Board.GetPossibleMoves(x, y);
            //ListOfMoves.ForEach(coordinates -> {
                
            //});
        }

        private void SetUpBoard()
        {
            ChessSquare chessSquare;
            bool grey = false;
            for (int column = 0; column < 8; column++)
            {
                for (int row = 0; row < 8; row++)
                {
                    chessSquare = new ChessSquare(grey, this);
                    chessSquare.SetValue(Grid.ColumnProperty, column);
                    chessSquare.SetValue(Grid.RowProperty, row);
                    //chessSquare.SetBinding(ChessSquare.IsSelectedProperty, ChessSquareBinding());

                    chessSquare.SetPicture(board[row, column]?.BitmapImage);

                    BoardDisplay.Children.Add(chessSquare);
                    grey = !grey;
                }
                grey = !grey;
            }
        }

       // private Binding ChessSquareBinding() {
            //toggle the SelectingMove
            //prevent selecting multiple spaces
            //display all possible moves
            //if possiblemove isSelected
                //execute movePiece logic
                //update board's View
           //else
                //display pop-up saying 'invalid move'
       // }
    }
}
