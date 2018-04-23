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
    class Rook:Piece
    {
        public Rook()
        { }
        public Rook(bool IsWhite, Tile Position): base(IsWhite, Position)
        {}
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
                } isClear = true;
            }
            if (destinationTile.RowInBoard == Position.RowInBoard)
            {
                minPosition = Math.Min(Position.ColumnInBoard, destinationTile.ColumnInBoard);
                for (int i = 1; i < Math.Abs(Position.ColumnInBoard - destinationTile.ColumnInBoard); i++)
                {
                    if (chess.Tiles[Position.RowInBoard,minPosition+i].PieceInside != null)
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
        public override void attackTile( ref ChessBoard chess)
        {
            for (int i = Position.RowInBoard+1; i < 8; i++)
            {
                if (chess.Tiles[i, Position.ColumnInBoard].PieceInside == null)
                {
                    if (IsWhite)
                        chess.Tiles[i, Position.ColumnInBoard].UnderWhiteAttack = true;
                    else
                        chess.Tiles[i, Position.ColumnInBoard].UnderBlackAttack = true;
                }
                else
                {
                    if (IsWhite)
                        chess.Tiles[i, Position.ColumnInBoard].UnderWhiteAttack = true;
                    else
                        chess.Tiles[i, Position.ColumnInBoard].UnderBlackAttack = true;
                    break;
                }
            }
            for (int i = Position.RowInBoard - 1; i >=0; i--)
            {
                if (chess.Tiles[i, Position.ColumnInBoard].PieceInside == null)
                {
                    if (IsWhite)
                        chess.Tiles[i, Position.ColumnInBoard].UnderWhiteAttack = true;
                    else
                        chess.Tiles[i, Position.ColumnInBoard].UnderBlackAttack = true;
                }
                else
                {
                    if (IsWhite)
                        chess.Tiles[i, Position.ColumnInBoard].UnderWhiteAttack = true;
                    else
                        chess.Tiles[i, Position.ColumnInBoard].UnderBlackAttack = true;
                    break;
                }
            }
            for (int i = Position.ColumnInBoard + 1; i < 8; i++)
            {
                if (chess.Tiles[Position.RowInBoard, i].PieceInside == null)
                {
                    if (IsWhite)
                        chess.Tiles[Position.RowInBoard, i].UnderWhiteAttack = true;
                    else
                        chess.Tiles[Position.RowInBoard, i].UnderBlackAttack = true;
                }
                else
                {
                    if (IsWhite)
                        chess.Tiles[Position.RowInBoard, i].UnderWhiteAttack = true;
                    else
                        chess.Tiles[Position.RowInBoard, i].UnderBlackAttack = true;
                    break;
                }
            }
            for (int i = Position.ColumnInBoard - 1; i >= 0; i--)
            {
                if (chess.Tiles[Position.RowInBoard, i].PieceInside == null)
                {
                    if (IsWhite)
                        chess.Tiles[Position.RowInBoard, i].UnderWhiteAttack = true;
                    else
                        chess.Tiles[Position.RowInBoard, i].UnderBlackAttack = true;
                }
                else
                {
                    if (IsWhite)
                        chess.Tiles[Position.RowInBoard, i].UnderWhiteAttack = true;
                    else
                        chess.Tiles[Position.RowInBoard, i].UnderBlackAttack = true;
                    break;
                }
            }
        }
        public override void loadTexture(ContentManager c)
        {
            if (IsWhite)
                PieceTexture = c.Load<Texture2D>(@"white rook");
            else
                PieceTexture = c.Load<Texture2D>(@"black rook");
        }
    }
}
