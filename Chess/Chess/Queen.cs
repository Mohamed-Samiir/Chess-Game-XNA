using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
namespace Chess
{
    class Queen:Piece
    {
        public Queen()
        { }
        public Queen(bool IsWhite, Tile Position)
            : base(IsWhite, Position)
        { }
        public override bool move(ref Tile startingTile, ref Tile destinationTile, ChessBoard chess)
        {
            if (destinationTile.PieceInside != null)
            {
                if (destinationTile.PieceInside.IsWhite == IsWhite)
                    return false;
            }
            King blackKing = (King)chess.Pieces[20];
            King whiteKing = (King)chess.Pieces[21];
            bool isClear = true;
            if (destinationTile.RowInBoard > Position.RowInBoard && destinationTile.ColumnInBoard > Position.ColumnInBoard && Math.Abs(Position.RowInBoard - destinationTile.RowInBoard) == Math.Abs(Position.ColumnInBoard - destinationTile.ColumnInBoard))
            {
                for (int i = 1; i < Math.Abs(Position.ColumnInBoard - destinationTile.ColumnInBoard); i++)
                {
                    if (chess.Tiles[Position.RowInBoard + i, Position.ColumnInBoard + i].PieceInside != null)
                    {
                        isClear = false;
                        break;
                    }
                }
                if (IsWhite)
                {
                    if (isClear && allowMove(ref chess, ref destinationTile) && whiteKing.canMoveBeforeKing(ref chess, ref destinationTile, this) && IsWhite)
                    {
                        changeTileForPiece(ref startingTile, ref destinationTile, ref chess);
                        return true;
                    }
                }
                else
                {
                    if (isClear && allowMove(ref chess, ref destinationTile) && blackKing.canMoveBeforeKing(ref chess, ref destinationTile, this) && !IsWhite)
                    {
                        changeTileForPiece(ref startingTile, ref destinationTile, ref chess);
                        return true;
                    }
                }
                isClear = true;
            }
            if (destinationTile.RowInBoard > Position.RowInBoard && destinationTile.ColumnInBoard < Position.ColumnInBoard && Math.Abs(Position.RowInBoard - destinationTile.RowInBoard) == Math.Abs(Position.ColumnInBoard - destinationTile.ColumnInBoard))
            {
                for (int i = 1; i < Math.Abs(Position.ColumnInBoard - destinationTile.ColumnInBoard); i++)
                {
                    if (chess.Tiles[Position.RowInBoard + i, Position.ColumnInBoard - i].PieceInside != null)
                    {
                        isClear = false;
                        break;
                    }
                }
                if (IsWhite)
                {
                    if (isClear && allowMove(ref chess, ref destinationTile) && whiteKing.canMoveBeforeKing(ref chess, ref destinationTile, this) && IsWhite)
                    {
                        changeTileForPiece(ref startingTile, ref destinationTile, ref chess);
                        return true;
                    }
                }
                else
                {
                    if (isClear && allowMove(ref chess, ref destinationTile) && blackKing.canMoveBeforeKing(ref chess, ref destinationTile, this) && !IsWhite)
                    {
                        changeTileForPiece(ref startingTile, ref destinationTile, ref chess);
                        return true;
                    }
                }
                isClear = true;
            }
            if (destinationTile.RowInBoard < Position.RowInBoard && destinationTile.ColumnInBoard < Position.ColumnInBoard && Math.Abs(Position.RowInBoard - destinationTile.RowInBoard) == Math.Abs(Position.ColumnInBoard - destinationTile.ColumnInBoard))
            {
                for (int i = 1; i < Math.Abs(Position.ColumnInBoard - destinationTile.ColumnInBoard); i++)
                {
                    if (chess.Tiles[Position.RowInBoard - i, Position.ColumnInBoard - i].PieceInside != null)
                    {
                        isClear = false;
                        break;
                    }
                }
                if (IsWhite)
                {
                    if (isClear && allowMove(ref chess, ref destinationTile) && whiteKing.canMoveBeforeKing(ref chess, ref destinationTile, this) && IsWhite)
                    {
                        changeTileForPiece(ref startingTile, ref destinationTile, ref chess);
                        return true;
                    }
                }
                else
                {
                    if (isClear && allowMove(ref chess, ref destinationTile) && blackKing.canMoveBeforeKing(ref chess, ref destinationTile, this) && !IsWhite)
                    {
                        changeTileForPiece(ref startingTile, ref destinationTile, ref chess);
                        return true;
                    }
                }
                isClear = true;
            }
            if (destinationTile.RowInBoard < Position.RowInBoard && destinationTile.ColumnInBoard > Position.ColumnInBoard && Math.Abs(Position.RowInBoard - destinationTile.RowInBoard) == Math.Abs(Position.ColumnInBoard - destinationTile.ColumnInBoard))
            {
                for (int i = 1; i < Math.Abs(Position.ColumnInBoard - destinationTile.ColumnInBoard); i++)
                {
                    if (chess.Tiles[Position.RowInBoard - i, Position.ColumnInBoard + i].PieceInside != null)
                    {
                        isClear = false;
                        break;
                    }
                }
                if (IsWhite)
                {
                    if (isClear && allowMove(ref chess, ref destinationTile) && whiteKing.canMoveBeforeKing(ref chess, ref destinationTile, this) && IsWhite)
                    {
                        changeTileForPiece(ref startingTile, ref destinationTile, ref chess);
                        return true;
                    }
                }
                else
                {
                    if (isClear && allowMove(ref chess, ref destinationTile) && blackKing.canMoveBeforeKing(ref chess, ref destinationTile, this) && !IsWhite)
                    {
                        changeTileForPiece(ref startingTile, ref destinationTile, ref chess);
                        return true;
                    }
                } 
                isClear = true;
            }
            int minPosition;
            if (destinationTile.ColumnInBoard == Position.ColumnInBoard)
            {
                minPosition = Math.Min(Position.RowInBoard, destinationTile.RowInBoard);
                for (int i = 1; i < Math.Abs(Position.RowInBoard - destinationTile.RowInBoard); i++)
                {
                    if (chess.Tiles[minPosition + i, Position.ColumnInBoard].PieceInside != null)
                    {
                        isClear = false;
                        break;
                    }
                }
                if (IsWhite)
                {
                    if (isClear && allowMove(ref chess, ref destinationTile) && whiteKing.canMoveBeforeKing(ref chess, ref destinationTile, this) && IsWhite)
                    {
                        changeTileForPiece(ref startingTile, ref destinationTile, ref chess);
                        return true;
                    }
                }
                else
                {
                    if (isClear && allowMove(ref chess, ref destinationTile) && blackKing.canMoveBeforeKing(ref chess, ref destinationTile, this) && !IsWhite)
                    {
                        changeTileForPiece(ref startingTile, ref destinationTile, ref chess);
                        return true;
                    }
                }
                isClear = true;
            }
            if (destinationTile.RowInBoard == Position.RowInBoard)
            {
                minPosition = Math.Min(Position.ColumnInBoard, destinationTile.ColumnInBoard);
                for (int i = 1; i < Math.Abs(Position.ColumnInBoard - destinationTile.ColumnInBoard); i++)
                {
                    if (chess.Tiles[Position.RowInBoard, minPosition + i].PieceInside != null)
                    {
                        isClear = false;
                        break;
                    }
                }
                if (IsWhite)
                {
                    if (isClear && allowMove(ref chess, ref destinationTile) && whiteKing.canMoveBeforeKing(ref chess, ref destinationTile, this) && IsWhite)
                    {
                        changeTileForPiece(ref startingTile, ref destinationTile, ref chess);
                        return true;
                    }
                }
                else
                {
                    if (isClear && allowMove(ref chess, ref destinationTile) && blackKing.canMoveBeforeKing(ref chess, ref destinationTile, this) && !IsWhite)
                    {
                        changeTileForPiece(ref startingTile, ref destinationTile, ref chess);
                        return true;
                    }
                }
                isClear = true;
            }
            return false;
        }
        public override void attackTile(ref ChessBoard chess)
        {
            if (IsWhite)
            {
                Rook whiteRook = new Rook();
                whiteRook.IsWhite = true;
                whiteRook.Position = Position;
                whiteRook.attackTile(ref chess);
                Bishop whiteBishop = new Bishop();
                whiteBishop.IsWhite = true;
                whiteBishop.Position = Position;
                whiteBishop.attackTile(ref chess);
            }
            else
            {
                Rook whiteRook = new Rook();
                whiteRook.IsWhite = false;
                whiteRook.Position = Position;
                whiteRook.attackTile(ref chess);
                Bishop whiteBishop = new Bishop();
                whiteBishop.IsWhite = false;
                whiteBishop.Position = Position;
                whiteBishop.attackTile(ref chess);
            }
            
        }
        public override void loadTexture(ContentManager c)
        {
            if (IsWhite)
                PieceTexture = c.Load<Texture2D>(@"white queen");
            else
                PieceTexture = c.Load<Texture2D>(@"black queen");
        }
    }
}
