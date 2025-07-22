using ChessAI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessLogic.Helper;
using ChessLogic;


namespace ChessLogic.OpeningBook
{
    public static class OpeningBook 
    {
        public static OpeningBook BuildFromPGN(string pgnPath)
        {
            var games = PGNReader.ReadPGN(pgnPath);
            var book = new OpeningBook();

            foreach (var moves in games)
            {
                var state = new GameState();

                foreach (var move in moves)
                {
                    string stateString = new StateString(state.CurrentPlayer, state.Board).ToString();
                    string algebraic = AlgebraicNotationHelper.ToAlgebraicNotation(move, state);
                    book.Add(stateString, algebraic);
                    state.MakeMove(move);
                }
            }

            return book;
        }
    }
}
