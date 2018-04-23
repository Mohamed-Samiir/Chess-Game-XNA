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
    class Knight:Piece
    {
        public Knight()
        { }
        public Knight(bool IsWhite, Tile Position)
            : base(IsWhite, Position)
        { }
        public override bool move(ref Tile startingTile, ref  Tile destinationTile, ChessBoard chess)
        {
           
          
            if (destinationTile.PieceInside != null)
            {
                if (destinationTile.PieceInside.IsWhite == IsWhite)
                    return false;
            }
            King blackKing=(King)chess.Pieces[20];
            King whiteKing=(King)chess.Pieces[21];
            if (((Math.Abs(Position.RowInBoard - destinationTile.RowInBoard) == 2 && Math.Abs(Position.ColumnInBoard - destinationTile.ColumnInBoard) == 1) || (Math.Abs(Position.RowInBoard - destinationTile.RowInBoard) == 1 && Math.Abs(Position.ColumnInBoard - destinationTile.ColumnInBoard) == 2))&&allowMove(ref chess , ref destinationTile))
            {
                if (IsWhite)
                {
                    if (!whiteKing.canMoveBeforeKing(ref chess, ref destinationTile, this))
                        return false;
                }
                else
                {
                    if (!blackKing.canMoveBeforeKing(ref chess, ref destinationTile, this))
                        return false;
                }
                changeTileForPiece(ref startingTile, ref destinationTile, ref chess);
                return true;
            }
            return false;
        }
        public override void attackTile(ref ChessBoard chess)
        {
            if (IsWhite)
            {
                try
                {
                    chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard + 2].UnderWhiteAttack = true;

                }
                catch (IndexOutOfRangeException)
                { }
                try
                {
                    chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard + 2].UnderWhiteAttack = true;

                }
                catch (IndexOutOfRangeException)
                { }
                try
                {
                    chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard - 2].UnderWhiteAttack = true;

                }
                catch (IndexOutOfRangeException)
                { }
                try
                {
                    chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard - 2].UnderWhiteAttack = true;

                }
                catch (IndexOutOfRangeException)
                { }
                try
                {
                    chess.Tiles[Position.RowInBoard + 2, Position.ColumnInBoard + 1].UnderWhiteAttack = true;

                }
                catch (IndexOutOfRangeException)
                { }
                try
                {
                    chess.Tiles[Position.RowInBoard - 2, Position.ColumnInBoard + 1].UnderWhiteAttack = true;

                }
                catch (IndexOutOfRangeException)
                { }
                try
                {
                    chess.Tiles[Position.RowInBoard + 2, Position.ColumnInBoard - 1].UnderWhiteAttack = true;

                }
                catch (IndexOutOfRangeException)
                { }
                try
                {
                    chess.Tiles[Position.RowInBoard - 2, Position.ColumnInBoard - 1].UnderWhiteAttack = true;

                }
                catch (IndexOutOfRangeException)
                { }
                
                
            }
            else
            {

                try
                {
                    chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard + 2].UnderBlackAttack = true;

                }
                catch (IndexOutOfRangeException)
                { }
                try
                {
                    chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard + 2].UnderBlackAttack = true;

                }
                catch (IndexOutOfRangeException)
                { }
                try
                {
                    chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard - 2].UnderBlackAttack = true;

                }
                catch (IndexOutOfRangeException)
                { }
                try
                {
                    chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard - 2].UnderBlackAttack = true;

                }
                catch (IndexOutOfRangeException)
                { }
                try
                {
                    chess.Tiles[Position.RowInBoard + 2, Position.ColumnInBoard + 1].UnderBlackAttack = true;

                }
                catch (IndexOutOfRangeException)
                { }
                try
                {
                    chess.Tiles[Position.RowInBoard - 2, Position.ColumnInBoard + 1].UnderBlackAttack = true;

                }
                catch (IndexOutOfRangeException)
                { }
                try
                {
                    chess.Tiles[Position.RowInBoard + 2, Position.ColumnInBoard - 1].UnderBlackAttack = true;

                }
                catch (IndexOutOfRangeException)
                { }
                try
                {
                    chess.Tiles[Position.RowInBoard - 2, Position.ColumnInBoard - 1].UnderBlackAttack = true;

                }
                catch (IndexOutOfRangeException)
                { }
            }

        }
        public override void loadTexture(ContentManager c)
        {
            if (IsWhite)
                PieceTexture = c.Load<Texture2D>(@"white knight");
            else
                PieceTexture = c.Load<Texture2D>(@"black knight");
        }
    }
}
