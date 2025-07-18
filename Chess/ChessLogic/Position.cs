﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
	public class Position
	{
		public int Row { get; }
		public int Column { get; }

		public Position(int row, int column)
		{
			Row = row;
			Column = column;
		}

		//public Player SquareColor()
		//{
		//	if ((Row + Column) % 2 == 0)
		//	{
		//		return Player.White;
		//	}

		//	return Player.Black;
		//}

		public SquareColor GetSquareColor()
		{
			return (Row + Column) % 2 == 0 ? SquareColor.Light : SquareColor.Dark;
		}

		public Position Move(int row, int column)
		{
			return new Position(Row + row, Column + column);
		}

		public override bool Equals(object obj)
		{
			return obj is Position position &&
				   Row == position.Row &&
				   Column == position.Column;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Row, Column);
		}

		public static bool operator ==(Position left, Position right)
		{
			return EqualityComparer<Position>.Default.Equals(left, right);
		}

		public static bool operator !=(Position left, Position right)
		{
			return !(left == right);
		}

		public static Position operator +(Position position, Direction direction)
		{
			return new Position(position.Row + direction.RowDelta, position.Column + direction.ColumnDelta);
		}

        public override string ToString()
        {
			char file = (char)('a' + Column);
			int rank = 8 - Row;

			return $"{file}{rank}";
        }
    }
}
