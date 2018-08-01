﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_IO.Models {
    class Board {
        private ChessPiece[][] board;

        public Board() {
            board = new ChessPiece[8][];
            for (int i = 0; i < board.Length; i++) {
                board[i] = new ChessPiece[8];
            }
        }

        public override string ToString() {
            StringBuilder output = new StringBuilder();
            foreach (ChessPiece[] row in board) {
                foreach (ChessPiece piece in row) {
                    if (piece == null) {
                        output.Append("-");
                    } else {
                        output.Append(piece.ToString());
                    }
                }
                if (row != board.Last()) {
                    output.Append("\n");
                }
            }
            return output.ToString();
        }
    }
}
