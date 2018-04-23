
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
    class ChessBoard : Microsoft.Xna.Framework.Game
    {
        public Tile[,] Tiles // contains the 64 tiles of the board
        { get; set; }
        public Piece[] Pieces // contains 32 pieces of the game
        { get; set; }
        public Vector2 Origin  // top left of the board
        { get; set; }
        public Texture2D ChessTexture  // board image
        { get; set; }
        public Texture2D WhiteTurn  // white turn image
        { get; set; }
        public Texture2D BlackTurn  // black turn image
        { get; set; }

        public ChessBoard()  
        {
            Origin = new Vector2(250,20);
            Pieces = new Piece[32];
            
        }
        public ChessBoard(Vector2 Origin)
        {
            this.Origin = Origin;
            Tiles = new Tile[8,8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Tiles[i, j] = new Tile(new Rectangle((int)Origin.X+Tile.TileWidth*j, (int)Origin.Y+Tile.TileHeight*i, Tile.TileWidth, Tile.TileHeight));
                    Tiles[i, j].RowInBoard = i;
                    Tiles[i, j].ColumnInBoard = j;
                    Tiles[i, j].PieceInside = null;
                    if (i == 2)
                    {
                        Tiles[i, j].UnderBlackAttack = true;
                        Tiles[i, j].UnderWhiteAttack = false;
                    }
                    else if (i == 5)
                    {
                        Tiles[i, j].UnderWhiteAttack = true;
                        Tiles[i, j].UnderBlackAttack = false;
                    }
                    else
                    {
                        Tiles[i, j].UnderBlackAttack = false;
                        Tiles[i, j].UnderWhiteAttack = false;
                    }
                }
            }

            Pieces = new Piece[32];

        }

        public void resetAttackedTiles()  // makes all tiles not under attack
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Tiles[i, j].UnderWhiteAttack = false;
                    Tiles[i, j].UnderBlackAttack = false;
                }
            }
        }
        public void setBorders()  // sets boarders of each tile for click matters
        {
            Tiles = new Tile[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Tiles[i, j] = new Tile(new Rectangle((int)Origin.X + Tile.TileWidth * j, (int)Origin.Y + Tile.TileHeight * i, Tile.TileWidth, Tile.TileHeight));
                    Tiles[i, j].RowInBoard = i;
                    Tiles[i, j].ColumnInBoard = j;
                    Tiles[i, j].PieceInside = null;
                    if (i == 2)
                    {
                        Tiles[i, j].UnderBlackAttack = true;
                        Tiles[i, j].UnderWhiteAttack = false;
                    }
                    else if (i == 5)
                    {
                        Tiles[i, j].UnderWhiteAttack = true;
                        Tiles[i, j].UnderBlackAttack = false;
                    }
                    else
                    {
                        Tiles[i, j].UnderBlackAttack = false;
                        Tiles[i, j].UnderWhiteAttack = false;
                    }

                }
            }
        }
        public void setPieces(ContentManager c) // fill pieces array with initial poisitons
        {
            for (int i = 0; i < 8; i++)
            {
                Pieces[i]=Tiles[1, i].PieceInside = new Pawn();
                Pieces[i].IsWhite=false;
                Pieces[i].Position=Tiles[1,i];
                Pieces[i].loadTexture(c);
            }
            for (int i = 0; i < 8; i++)
            {
                Pieces[i+8]=Tiles[6, i].PieceInside = new Pawn();
                Pieces[i+8].IsWhite = true;
                Pieces[i+8].Position = Tiles[6, i];
                Pieces[i+8].loadTexture(c);
            }
            Pieces[16] = Tiles[7, 1].PieceInside = new Knight();
            Pieces[16].IsWhite = true;
            Pieces[16].Position = Tiles[7, 1];
            Pieces[16].loadTexture(c);
            Pieces[17] = Tiles[7, 6].PieceInside = new Knight();
            Pieces[17].IsWhite = true;
            Pieces[17].Position = Tiles[7, 6];
            Pieces[17].loadTexture(c);
            Pieces[18] = Tiles[0, 1].PieceInside = new Knight();
            Pieces[18].IsWhite = false;
            Pieces[18].Position = Tiles[0, 1];
            Pieces[18].loadTexture(c);
            Pieces[19] = Tiles[0, 6].PieceInside = new Knight();
            Pieces[19].IsWhite = false;
            Pieces[19].Position = Tiles[0, 6];
            Pieces[19].loadTexture(c);
            Pieces[20] = Tiles[0, 4].PieceInside = new King();
            Pieces[20].Position = Tiles[0, 4];
            Pieces[20].IsWhite = false;
            Pieces[20].loadTexture(c);
            Pieces[21] = Tiles[7, 4].PieceInside = new King();
            Pieces[21].Position = Tiles[7, 4];
            Pieces[21].IsWhite = true;
            Pieces[21].loadTexture(c);
            Pieces[22] = Tiles[0, 2].PieceInside = new Bishop();
            Pieces[22].Position = Tiles[0, 2];
            Pieces[22].IsWhite = false;
            Pieces[22].loadTexture(c);
            Pieces[23] = Tiles[0, 5].PieceInside = new Bishop();
            Pieces[23].Position = Tiles[0, 5];
            Pieces[23].IsWhite = false;
            Pieces[23].loadTexture(c);
            Pieces[24] = Tiles[7, 2].PieceInside = new Bishop();
            Pieces[24].Position = Tiles[7, 2];
            Pieces[24].IsWhite = true;
            Pieces[24].loadTexture(c);
            Pieces[25] = Tiles[7, 5].PieceInside = new Bishop();
            Pieces[25].Position = Tiles[7, 5];
            Pieces[25].IsWhite = true;
            Pieces[25].loadTexture(c);
            Pieces[26] = Tiles[0, 0].PieceInside = new Rook();
            Pieces[26].Position = Tiles[0, 0];
            Pieces[26].IsWhite = false;
            Pieces[26].loadTexture(c);
            Pieces[27] = Tiles[0, 7].PieceInside = new Rook();
            Pieces[27].Position = Tiles[0, 7];
            Pieces[27].IsWhite = false;
            Pieces[27].loadTexture(c);
            Pieces[28] = Tiles[7, 0].PieceInside = new Rook();
            Pieces[28].Position = Tiles[7, 0];
            Pieces[28].IsWhite = true;
            Pieces[28].loadTexture(c);
            Pieces[29] = Tiles[7, 7].PieceInside = new Rook();
            Pieces[29].Position = Tiles[7, 7];
            Pieces[29].IsWhite = true;
            Pieces[29].loadTexture(c);
            Pieces[30] = Tiles[0, 3].PieceInside = new Queen();
            Pieces[30].Position = Tiles[0, 3];
            Pieces[30].IsWhite = false;
            Pieces[30].loadTexture(c);
            Pieces[31] = Tiles[7, 3].PieceInside = new Queen();
            Pieces[31].Position = Tiles[7, 3];
            Pieces[31].IsWhite = true;
            Pieces[31].loadTexture(c);
        }
        public void loadTurnInformation() // load white and black turn image 
        {
            WhiteTurn = Player.ChessGame.Content.Load<Texture2D>(@"white turn");
            BlackTurn = Player.ChessGame.Content.Load<Texture2D>(@"black turn");
        }
        public void drawTurnInformation(ref SpriteBatch s)  // draw turn images
        {
            if(Player.WhitePlayerTurn)
                s.Draw(WhiteTurn,new Vector2(30),Color.White);
            else
                s.Draw(BlackTurn, new Vector2(30), Color.White);
        }
        private System.Drawing.Bitmap createBitmap(Texture2D texture) // turns textures to bitmap
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            texture.SaveAsPng(ms, texture.Width, texture.Height);
            return new System.Drawing.Bitmap(ms);
        }
        private void drawPiecesInForm(bool white)  // draw promotion pieces in pormotion form
        {
            if (white)
            {
                
                Game1.pf.Controls["queenbtn"].BackgroundImage = createBitmap(Player.ChessGame.Content.Load<Texture2D>(@"white queen"));
                Game1.pf.Controls["rookbtn"].BackgroundImage = createBitmap(Player.ChessGame.Content.Load<Texture2D>(@"white rook"));
                Game1.pf.Controls["bishopbtn"].BackgroundImage = createBitmap(Player.ChessGame.Content.Load<Texture2D>(@"white bishop"));
                Game1.pf.Controls["knightbtn"].BackgroundImage = createBitmap(Player.ChessGame.Content.Load<Texture2D>(@"white knight"));
            }
            else
            {
                Game1.pf.Controls["queenbtn"].BackgroundImage = createBitmap(Player.ChessGame.Content.Load<Texture2D>(@"black queen"));
                Game1.pf.Controls["rookbtn"].BackgroundImage = createBitmap(Player.ChessGame.Content.Load<Texture2D>(@"black rook"));
                Game1.pf.Controls["bishopbtn"].BackgroundImage = createBitmap(Player.ChessGame.Content.Load<Texture2D>(@"black bishop"));
                Game1.pf.Controls["knightbtn"].BackgroundImage = createBitmap(Player.ChessGame.Content.Load<Texture2D>(@"black knight"));
            }
        }
        public void drawPieces(ref SpriteBatch s) 
        {
            for (int i = 0; i < 32; i++)
            {
                if(Pieces[i]!=null)
                    Pieces[i].draw(ref s);
            }
            
        }
        public void promotePawn(ContentManager c)
        {
            for (int i = 0; i < 8; i++)
            {
                if(Pieces[i]!=null)
                    if (Pieces[i].Position.RowInBoard == 7&&Pieces[i] is Pawn)
                    {
                        PromotionForm p = new PromotionForm();
                        drawPiecesInForm(false);
                        Game1.pf.ShowDialog();
                        if (Game1.pf.isClicked)
                        {
                            switch (Game1.pf.choice)
                            {
                                case PromotionChoices.Queen:
                                    Game1.pf.Close();
                                    Pieces[i] = new Queen(false, Pieces[i].Position);
                                    Pieces[i].Position.PieceInside = Pieces[i];
                                    Pieces[i].loadTexture(c);
                                    break;
                                case PromotionChoices.Rook:
                                    Game1.pf.Close();
                                    Pieces[i] = new Rook(false, Pieces[i].Position);
                                    Pieces[i].Position.PieceInside = Pieces[i];
                                    Pieces[i].loadTexture(c);
                                    break;
                                case PromotionChoices.Bishop:
                                    Game1.pf.Close();
                                    Pieces[i] = new Bishop(false, Pieces[i].Position);
                                    Pieces[i].Position.PieceInside = Pieces[i];
                                    Pieces[i].loadTexture(c);
                                    break;
                                case PromotionChoices.Knight:
                                    Game1.pf.Close();
                                    Pieces[i] = new Knight(false, Pieces[i].Position);
                                    Pieces[i].Position.PieceInside = Pieces[i];
                                    Pieces[i].loadTexture(c);
                                    break;

                            }
                        }
                        /*Pieces[i] = new Queen(false, Pieces[i].Position);
                        Pieces[i].Position.PieceInside = Pieces[i];
                        Pieces[i].loadTexture(c);*/
                    }
                if(Pieces[i+8]!=null)
                    if (Pieces[ i + 8].Position.RowInBoard == 0&&Pieces[i+8] is Pawn)
                    {
                        PromotionForm p = new PromotionForm();
                        drawPiecesInForm(true);
                        Game1.pf.ShowDialog();
                        if (Game1.pf.isClicked)
                        {
                            switch (Game1.pf.choice)
                            {
                                case PromotionChoices.Queen:
                                    Game1.pf.Close();
                                    Pieces[i+8] = new Queen(true, Pieces[i+8].Position);
                                    Pieces[i+8].Position.PieceInside = Pieces[i+8];
                                    Pieces[i+8].loadTexture(c);
                                    break;
                                case PromotionChoices.Rook:
                                    Game1.pf.Close();
                                    Pieces[i+8] = new Rook(true, Pieces[i+8].Position);
                                    Pieces[i+8].Position.PieceInside = Pieces[i+8];
                                    Pieces[i+8].loadTexture(c);
                                    break;
                                case PromotionChoices.Bishop:
                                    Game1.pf.Close();
                                    Pieces[i+8] = new Bishop(true, Pieces[i+8].Position);
                                    Pieces[i+8].Position.PieceInside = Pieces[i+8];
                                    Pieces[i+8].loadTexture(c);
                                    break;
                                case PromotionChoices.Knight:
                                    Game1.pf.Close();
                                    Pieces[i+8] = new Knight(true, Pieces[i+8].Position);
                                    Pieces[i+8].Position.PieceInside = Pieces[i+8];
                                    Pieces[i+8].loadTexture(c);
                                    break;

                            }
                        }
                        /*Pieces[ i + 8] = new Queen(true, Pieces[ i + 8].Position);
                        Pieces[i + 8].Position.PieceInside = Pieces[i + 8];
                        Pieces[ i + 8].loadTexture(c);*/
                    }
            }
        }
        public void loadTexture(ContentManager c)
        {
            ChessTexture = c.Load<Texture2D>(@"board");
        }
        public void draw(ref SpriteBatch s)
        {   
            
            s.Draw(ChessTexture, Origin,Color.White);
        }
    }
}
