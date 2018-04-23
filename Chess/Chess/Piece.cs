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
    abstract class Piece
    {
        public Texture2D PieceTexture  // piece image
        { get; set; }
        public bool IsWhite  
        { get; set; }
        public Tile Position
        { get; set; }
        public Piece()
        { }
        public Piece(bool IsWhite, Tile Position)
        {
            this.IsWhite = IsWhite;
            this.Position = Position;
        }
        public abstract bool move(ref Tile startingTile,ref  Tile destinationTile,  ChessBoard chess); // checks if the move is valid and moves if valid
        public abstract void attackTile(ref ChessBoard chess); // assigns logical attack on tiles
        public abstract void loadTexture(ContentManager c); 
        protected bool allowMove(ref ChessBoard chess , ref Tile destinationTile ) // allows only blocking move when checked
        {
            if (IsWhite)
            {
                King whiteKing = (King)chess.Pieces[21];
                if (whiteKing.ReachTiles.Contains(destinationTile) || whiteKing.ReachTiles.Count == 0)
                    return true;
            }
            else
            {
                King blackKing = (King)chess.Pieces[20];
                if (blackKing.ReachTiles.Contains(destinationTile) || blackKing.ReachTiles.Count == 0)
                    return true;
            }
            return false;
        }
        
        public void draw(ref SpriteBatch s)
        {
            s.Draw(PieceTexture, Position.getCenter(), Color.White);
        }
        protected  void changeTileForPiece(ref Tile startingTile, ref Tile destinationTile,ref ChessBoard chess) // moves pieces ignoring conditions
        {
            if (destinationTile.PieceInside != null)
            {
                for (int i = 0; i < 32; i++)
                {
                    if (chess.Pieces[i] != null)
                    {
                        if (chess.Pieces[i].Position == destinationTile)
                        {
                            chess.Pieces[i] = null;
                            break;
                        }
                    }
                }
            }
            for (int i = 0; i < 32; i++)
            {
                if (chess.Pieces[i] != null)
                {
                    if (chess.Pieces[i].Position == startingTile)
                    {
                        Position.PieceInside = null;
                        chess.Pieces[i].Position = destinationTile;
                        chess.Pieces[i].Position.PieceInside = chess.Pieces[i];
                        if (chess.Pieces[i] is Pawn)   // pawns' first movement
                        {
                            Pawn p = (Pawn)chess.Pieces[i];
                            p.HasMoved = true;
                        }
                        startingTile = null;
                        return;
                    }
                }
            }   
        }
    }
}
