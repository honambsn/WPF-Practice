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

        public static Move ParsAlgebraicNotation(string notation, GameState state)
        {
            if (string.IsNullOrWhiteSpace(notation))
                return null;

            notation = notation.Trim();

            // special cases for castling
            if (notation == "O-O" || notation == "O-O+")
                return GetCastleMove(state, kingside: true);
            
            if (notation == "O-O-O" || notation == "O-O-O+")
                return GetCastleMove(state, kingside: false);

            // detect check or checkmate symbols
            notation = notation.Replace("+", "").Replace("#", "");

            var legalMoves = state.GetAllLegalMoves();

            // pawn promotions
            if (notation.Contains("="))
            {
                var parts = notation.Split("=");
                var promoPieceChar = parts[1].ToUpper()[0];
                var target = parts[0].Substring(parts[0].Length - 2); // e8=Q => e8

                foreach (var move in legalMoves.OfType<PawnPromotion>())
                {
                    if (move.ToPos.ToString() == target &&
                        PieceToChar(move.PromotedPiece) == promoPieceChar)
                        return move;
                }

                return null;
            }

            // captures
            bool isCapture = notation.Contains('x');
            notation = notation.Replace("x", "");


            // destination square
            string destination = notation.Substring(notation.Length - 2);
            var toSquare = BoardPosition.FromAlgebraic(destination);

            char firstChar = notation[0];
            PieceType pieceType;
            int startIdx = 1;

            if (char.IsUpper(firstChar) && "RNBQK".Contains(firstChar))
            {
                pieceType = CharToPiece(firstChar);
            }
            else
            {
                pieceType = PieceType.Pawn;
                startIdx = 0;
            }

            // disambiguation (file or rank)
            string disambiguation = notation.Substring(startIdx, notation.Length - 2 - startIdx);

            foreach (var move in legalMoves)
            {
                if (move.ToPos != toSquare) continue;

                var piece = state.Board.GetPieceAt(move.FromPos);

                if (piece == null || piece.Type != pieceType || piece.Color != state.CurrentPlayer) continue;

                if (!string.IsNullOrEmpty(disambiguation))
                {
                    if (disambiguation.Length == 1)
                    {
                        if (char.IsDigit(disambiguation[0]))
                        {
                            // rank
                            if (move.FromPos.Rank != disambiguation[0] - '1')
                                continue;
                        }
                        else
                        {
                            // file
                            if (move.FromPos.File != disambiguation[0] - 'a') continue;
                        }
                    }
                    else if (disambiguation.Length == 2)
                    {
                        var pos = BoardPosition.FromAlgebraic(disambiguation);
                        if (move.FromPos != pos)
                            continue;
                    }
                }

                return move;
            }

            return null;

        }

        private static PieceType CharToPiece(char c)
        {
            return c switch
            {
                'N' => PieceType.Knight,
                'B' => PieceType.Bishop,
                'R' => PieceType.Rook,
                'Q' => PieceType.Queen,
                'K' => PieceType.King,
                _ => PieceType.Pawn
            };
        }

        private static char PieceToChar(Piece piece)
        {
            return piece.Type switch
            {
                PieceType.Queen => 'Q',
                PieceType.Rook => 'R',
                PieceType.Bishop => 'B',
                PieceType.Knight => 'N',
                PieceType.King => 'K',
                _ => ' '
            };
        }

        private static Move GetCastleMove(GameState state, bool kingside)
        {
            var moves = state.GetAllLegalMoves().OfType<Castle>();
            
            foreach (var move in moves)
            {
                if (move.IsKingside == kingside)
                    return move;
            }

            return null;
        }
    }
}
