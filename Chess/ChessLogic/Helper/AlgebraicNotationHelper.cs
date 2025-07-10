using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic.Helper
{
    public class AlgebraicNotationHelper
    {
        public static string ToAlgebraicNotation(Move move, GameState state)
        {
            var piece = state.Board[move.FromPos];

            if (piece == null) return "null piece";

            string notation = "";

            //castle
            if (move is Castle)
            {
                if (move.ToPos.Column > move.FromPos.Column)
                {
                    return "0-0"; // kingside castle
                }
                else
                {
                    return "0-0-0"; // queenside castle
                }
            }

            string pieceChar = piece.Type switch
            {
                PieceType.Pawn => "",
                PieceType.Knight => "N",
                PieceType.Bishop => "B",
                PieceType.Rook => "R",
                PieceType.Queen => "Q",
                PieceType.King => "K",
                _ => throw new ArgumentException("Unknown piece type")
            };

            // check for capture
            bool isCapture = state.Board[move.ToPos] != null || move is EnPassant;

            // or pawn moves, we use the column letter
            if (piece.Type == PieceType.Pawn)
            {
                if (isCapture)
                {
                    notation += (char)('a' + move.FromPos.Column);
                    notation += "x";
                }

            }
            else
            {
                notation += pieceChar;

                if (isCapture)
                {
                    notation += "x"; // capture notation
                }
            }

                //notation += pieceChar;

            //if (isCapture)
            //{
            //    notation += "x"; // capture notation
            //}

            notation += ToSquareName(move.ToPos);

            // check for promotion to Queen
            if (move is PawnPromotion promo)
            {
                notation += "=" + (promo.PromotedPiece switch
                {
                    PieceType.Queen => "Q",
                    PieceType.Rook => "R",
                    PieceType.Bishop => "B",
                    PieceType.Knight => "N",
                    _ => throw new ArgumentException("Unknown promoted piece type")
                });
            }


            // check for check or checkmate
            var copy = state.Copy();
            copy.ApplyMove(move);

            if (copy.IsGameOver() && copy.Result.Reason == EndReason.Checkmate)
            {
                notation += "#"; // checkmate
            }
            else if (copy.IsGameOver() && copy.Result.Reason == EndReason.Stalemate)
            {
                notation += "="; // stalemate
            }
            else if (copy.Board.IsInCheck(copy.CurrentPlayer))
            {
                notation += "+"; // check
            }
            
            return notation;
        }

        private static string ToSquareName(Position toPos)
        {
            return $"{(char)('a' + toPos.Column)}{8 - toPos.Row}";
        }
    }
}
