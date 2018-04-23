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
    class Bishop : Piece
    {
        public Bishop()
        { }
        public Bishop(bool IsWhite, Tile Position)
            : base(IsWhite, Position)
        { }
        public override bool move(ref Tile startingTile, ref Tile destinationTile, ChessBoard chess)
        {
            if (destinationTile.PieceInside != null)
            {
                if (destinationTile.PieceInside.IsWhite == IsWhite)
                    return false;
            }
            King whiteKing = (King)chess.Pieces[21];
            King blackKing = (King)chess.Pieces[20];
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
            return false;
        }
        public override void attackTile(ref ChessBoard chess)
        {
            int c = Position.ColumnInBoard+1;
            for (int i = Position.RowInBoard + 1; i < 8 && c < 8; i++)
            {
                if (chess.Tiles[i,c].PieceInside == null)
                {
                    if (IsWhite)
                        chess.Tiles[i, c].UnderWhiteAttack = true;
                    else
                        chess.Tiles[i, c].UnderBlackAttack = true;
                }
                else
                {
                    if (IsWhite)
                        chess.Tiles[i, c].UnderWhiteAttack = true;
                    else
                        chess.Tiles[i, c].UnderBlackAttack = true;
                    break;
                }
                c++;
            }
            c = Position.ColumnInBoard+1;
            for (int i = Position.RowInBoard - 1; i >= 0 && c < 8; i--)
            {
                if (chess.Tiles[i, c].PieceInside == null)
                {
                    if (IsWhite)
                        chess.Tiles[i, c].UnderWhiteAttack = true;
                    else
                        chess.Tiles[i,c].UnderBlackAttack = true;
                }
                else
                {
                    if (IsWhite)
                        chess.Tiles[i, c].UnderWhiteAttack = true;
                    else
                        chess.Tiles[i, c].UnderBlackAttack = true;
                    break;
                }
                c++;
            }
            c = Position.ColumnInBoard-1;
            for (int i = Position.RowInBoard - 1; i >= 0 && c >=0; i--)
            {
                if (chess.Tiles[i,c].PieceInside == null)
                {
                    if (IsWhite)
                        chess.Tiles[i,c].UnderWhiteAttack = true;
                    else
                        chess.Tiles[i,c].UnderBlackAttack = true;
                }
                else
                {
                    if (IsWhite)
                        chess.Tiles[i,c].UnderWhiteAttack = true;
                    else
                        chess.Tiles[i,c].UnderBlackAttack = true;
                    break;
                }
                c--;
            }
            c = Position.ColumnInBoard-1;
            for (int i = Position.RowInBoard + 1; i < 8 && c >= 0; i++)
            {
                if (chess.Tiles[i, c].PieceInside == null)
                {
                    if (IsWhite)
                        chess.Tiles[i, c].UnderWhiteAttack = true;
                    else
                        chess.Tiles[i, c].UnderBlackAttack = true;
                }
                else
                {
                    if (IsWhite)
                        chess.Tiles[i,  c].UnderWhiteAttack = true;
                    else
                        chess.Tiles[i,  c].UnderBlackAttack = true;
                    break;
                }
                c--;
            }
        }




        public override void loadTexture(ContentManager c)
        {
            if (IsWhite)
                PieceTexture = c.Load<Texture2D>(@"white bishop");
            else
                PieceTexture = c.Load<Texture2D>(@"black bishop");
        }
    }
}

