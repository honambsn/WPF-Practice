using ChessLogic;
using ChessInterfaces;
using System;
using System.Collections.Generic;

namespace ChessAI.Evaluation
{
	public class BoardEvaluator
	{
		private readonly Dictionary<PieceType, int> pieceValues = new Dictionary<PieceType, int>()
		{
			{ PieceType.Pawn, 100 },
			{ PieceType.Knight, 320 },
			{ PieceType.Bishop, 330 },
			{ PieceType.Rook, 500 },
			{ PieceType.Queen, 900 },
			{ PieceType.King, 20000 }
		};

		public int Evaluate(IGameState state)
		{
			// Ensure we're dealing with GameState specifically
			if (state is GameState gameState)
			{
				// First, check if the game is over using the Result from ChessLogic
				if (gameState.IsGameOver())
				{
					if (gameState.Result.Winner == Player.White) return int.MaxValue;
					if (gameState.Result.Winner == Player.Black) return int.MinValue;
					return 0; // Draw or stalemate
				}

				int score = 0;

				// Iterate through all positions on the board
				foreach (var pos in gameState.Board.PiecePositions())
				{
					Piece piece = gameState.Board[pos];
					if (piece == null) continue;

					int value = pieceValues[piece.Type];

					// Add or subtract piece value depending on the player's color
					if (piece.Color == Player.White)
					{
						score += value;
					}
					else
					{
						score -= value;
					}
				}

				return score;
			}

			// If the state is not of type GameState, throw an error or handle differently
			throw new InvalidOperationException("The provided IGameState is not a GameState.");
		}
	}
}
