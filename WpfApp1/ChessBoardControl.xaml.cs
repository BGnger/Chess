﻿using System;
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
        public ChessBoardControl()
        {
            InitializeComponent();
        }

        public void loadedChessBoard(Object sender, RoutedEventArgs e) {
            MakeBoardCheckered();
        }

        public void MakeBoardCheckered() {
            ColumnDefinition[] columnDefinitions = Board.ColumnDefinitions.ToArray();
            RowDefinition[] rowDefinitions = Board.RowDefinitions.ToArray();
            for (int column = 0; column < columnDefinitions.Length; column++)
            {
                int alternation = column % 2;
                for (int row = 0; row < rowDefinitions.Length; row++)
                {
                    if (row % 2 == alternation)
                    {
                        Board.Children.Add(AddBoardRectangle(row, column));
                    }
                }
            }
        }

        public Rectangle AddBoardRectangle(int row, int column) {
            Rectangle rect = new Rectangle();
            rect.Fill = new SolidColorBrush(Colors.DarkGray);
            rect.SetValue(Grid.RowProperty, row);
            rect.SetValue(Grid.ColumnProperty, column);
            return rect;
        }
    }
}
