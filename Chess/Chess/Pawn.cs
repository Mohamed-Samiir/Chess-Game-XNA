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
    class Pawn:Piece
    {
        

        public bool HasMoved // check if pawn has moved before
        { get; set; }
        public bool JustMovedTwoSteps
        { get; set; }
        public Pawn()
        {
            HasMoved = false;
            JustMovedTwoSteps = false;
        }
        public Pawn(bool IsWhite, Tile Position): base(IsWhite, Position)
        {
            HasMoved = false;
            JustMovedTwoSteps = false;
        }

        // part of pawn move function
        private bool pawnMovements( ref Tile startingTile, ref Tile destinationTile, ref ChessBoard chess,bool white)
        {
            int mult;
            King blackKing = (King)chess.Pieces[20];
            King whiteKing = (King)chess.Pieces[21];
            if (white)
                mult = 1;
            else
                mult = -1;
            if (!HasMoved && (Position.RowInBoard - destinationTile.RowInBoard == 2 * mult) && destinationTile.ColumnInBoard == Position.ColumnInBoard && allowMove(ref chess, ref destinationTile))
                {
                    if (white)
                    {
                        if (!whiteKing.canMoveBeforeKing(ref chess, ref destinationTile, this))
                            return false;
                    }
                    else
                    {
                        if (!blackKing.canMoveBeforeKing(ref chess, ref destinationTile, this))
                            return false;
                    }
                    if (destinationTile.PieceInside != null)
                        return false;
                    changeTileForPiece(ref startingTile, ref destinationTile, ref chess);
                    HasMoved = true;
                    JustMovedTwoSteps = true;
                    return true;
                }
            if ((Position.RowInBoard - destinationTile.RowInBoard == 1 * mult) && destinationTile.ColumnInBoard == Position.ColumnInBoard && allowMove(ref chess, ref destinationTile))
                {
                    if (white)
                    {
                        if(!whiteKing.canMoveBeforeKing(ref chess,ref destinationTile,this))
                            return false;
                    }
                    else
                    {
                        if(!blackKing.canMoveBeforeKing(ref chess,ref destinationTile,this))
                            return false;
                    }
                    if (destinationTile.PieceInside != null)
                        return false;
                    changeTileForPiece(ref startingTile, ref destinationTile,ref chess);
                    JustMovedTwoSteps = false;
                    return true;
                }
            else if ((Position.RowInBoard - destinationTile.RowInBoard == 1 * mult) && Position.ColumnInBoard - destinationTile.ColumnInBoard == 1 && destinationTile.PieceInside != null && allowMove(ref chess, ref destinationTile))
                {
                    if (white)
                    {
                        if (!whiteKing.canMoveBeforeKing(ref chess, ref destinationTile, this))
                            return false;
                    }
                    else
                    {
                        if (!blackKing.canMoveBeforeKing(ref chess, ref destinationTile, this))
                            return false;
                    }
                    if (destinationTile.PieceInside.IsWhite!=white)
                    {
                        changeTileForPiece(ref startingTile, ref destinationTile,ref chess);
                        JustMovedTwoSteps = false;
                        return true;
                    }
                }
            else if ((Position.RowInBoard - destinationTile.RowInBoard == 1 * mult) && Position.ColumnInBoard - destinationTile.ColumnInBoard == -1 && destinationTile.PieceInside != null && allowMove(ref chess, ref destinationTile))
                {
                    if (white)
                    {
                        if (!whiteKing.canMoveBeforeKing(ref chess, ref destinationTile, this))
                            return false;
                    }
                    else
                    {
                        if (!blackKing.canMoveBeforeKing(ref chess, ref destinationTile, this))
                            return false;
                    }
                    if (destinationTile.PieceInside.IsWhite!=white)
                    {
                        changeTileForPiece(ref startingTile, ref destinationTile, ref chess);
                        JustMovedTwoSteps = false;
                        return true;
                    }
                }
                return false;
            
        }
        public override bool  move(ref Tile startingTile,ref Tile destinationTile, ChessBoard chess)
        {
            if (IsWhite)
            {
                return pawnMovements(ref startingTile, ref destinationTile, ref chess, IsWhite);
            }
            else
            {
                return pawnMovements(ref startingTile, ref destinationTile, ref chess, IsWhite);
            }
        }
        public override void attackTile(ref ChessBoard chess)
        {
            if (IsWhite)
            {
                try
                {
                    chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard + 1].UnderWhiteAttack = true;
                }
                catch (IndexOutOfRangeException)
                { }
                try
                {
                    chess.Tiles[Position.RowInBoard - 1, Position.ColumnInBoard - 1].UnderWhiteAttack = true;
                }
                catch (IndexOutOfRangeException)
                { }
                try
                {
                }
                catch (IndexOutOfRangeException)
                { }
                
            }
            else
            {
                try
                {
                    chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard + 1].UnderBlackAttack = true;
                }
                catch (IndexOutOfRangeException)
                { }
                    
                try
                {
                    chess.Tiles[Position.RowInBoard + 1, Position.ColumnInBoard - 1].UnderBlackAttack = true;
                }
                catch (IndexOutOfRangeException)
                { }
                    
                
            }
        }
        public override void loadTexture(ContentManager c)
        {
            if (IsWhite)
                PieceTexture = c.Load<Texture2D>(@"white pawn");
            else
                PieceTexture = c.Load<Texture2D>(@"black pawn");
        }
       
    }
}
