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
     class Player
    {
        public static Game1 ChessGame  // connects player with the game
        { get; set; }
        public static bool WhitePlayerTurn  // logical turn 
        { get; set; }
        public bool Checkmate 
        { get; set; }
        public  bool IsWhitePlayer
        { get; set; }
        public bool Selection  // highlight selection tiles 
        { get; set; }
        private Tile selectionTile;  // first tile to be pressed
        public Player() 
        {
            Selection = false;
            selectionTile = null;
            Checkmate = false;
        }
        public Player(bool IsWhitePlayer)
        {
          Selection = false;
          this.IsWhitePlayer = IsWhitePlayer;
          selectionTile = null;
          Checkmate = false;
        }
        public void clicksOnPiece(MouseState click,ref ChessBoard chess)  // assign selection tile
        {
            if (click.LeftButton == ButtonState.Pressed)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (chess.Tiles[i, j].getBorder().Contains(new Point(click.X, click.Y)) && chess.Tiles[i, j].PieceInside != null)
                        {
                            if (chess.Tiles[i, j].PieceInside.IsWhite == WhitePlayerTurn)
                            {
                                Selection = true;
                                selectionTile = chess.Tiles[i, j];
                                break;
                            }
                        }
                    }
                }
            }
        }
        public  void attemptsToMove(MouseState click,ref ChessBoard chess) // move logic for each player
        {
            if (selectionTile == null)
                return;
            King checkedBlackKing = (King)chess.Pieces[20];
            King checkedWhiteKing = (King)chess.Pieces[21];
            if (click.LeftButton == ButtonState.Pressed)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (chess.Tiles[i, j].getBorder().Contains(new Point(click.X, click.Y))&&selectionTile.PieceInside!=null)
                        {
                            if (WhitePlayerTurn && selectionTile.PieceInside.IsWhite)
                            {
                                if (selectionTile.PieceInside.move(ref selectionTile, ref chess.Tiles[i, j], chess))
                                {
                                    //winning condition
                                    chess.resetAttackedTiles();
                                    chess.promotePawn(ChessGame.Content);
                                    for (int k = 0; k <32; k++)
                                    {
                                        if (chess.Pieces[k] != null)
                                            chess.Pieces[k].attackTile(ref chess);

                                    }
                                    checkedBlackKing.clearKing();
                                    
                                    if (checkedBlackKing.checkPath(ref chess))
                                    {
                                        chess.resetAttackedTiles();
                                        for (int k = 0; k < 32; k++)
                                        {
                                            if (chess.Pieces[k] != null)
                                            {
                                                if ((chess.Pieces[k] is Pawn && !chess.Pieces[k].IsWhite)||k==20)
                                                    continue;
                                                chess.Pieces[k].attackTile(ref chess);
                                            }

                                        }
                                    }
                                    checkedBlackKing.checkmate(ChessGame.player1,ChessGame.player2,ref chess);
                                    WhitePlayerTurn = !WhitePlayerTurn;
                                    return;
                                }
                            }
                            else if (!(WhitePlayerTurn) && !(selectionTile.PieceInside.IsWhite))
                            {
                                if (selectionTile.PieceInside.move(ref selectionTile, ref chess.Tiles[i, j], chess))
                                {
                                    chess.resetAttackedTiles();
                                    chess.promotePawn(ChessGame.Content);
                                    for (int k =0; k < 32; k++)
                                    {
                                        if (chess.Pieces[k] != null)
                                            chess.Pieces[k].attackTile(ref chess);
                                    }
                                    checkedWhiteKing.clearKing();
                                    if (checkedWhiteKing.checkPath(ref chess))
                                    {
                                        chess.resetAttackedTiles();
                                        for (int k = 0; k < 32; k++)
                                        {
                                            if (chess.Pieces[k] != null)
                                            {
                                                if ((chess.Pieces[k] is Pawn && chess.Pieces[k].IsWhite) || k == 21)
                                                    continue;
                                                chess.Pieces[k].attackTile(ref chess);
                                            }

                                        }
                                    }
                                    checkedWhiteKing.checkmate(ChessGame.player1,ChessGame.player2,ref chess);
                                    WhitePlayerTurn = !WhitePlayerTurn;
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }
       
        public void selectionUpdate(ref SpriteBatch s,ref GraphicsDeviceManager g, ref ChessBoard chess) // update user clicks and colors tiles
        {
            if (Selection)
            {
                if (selectionTile == null)
                    return;
                chess.Tiles[selectionTile.RowInBoard, selectionTile.ColumnInBoard].colorSelection(ref s, ref g, Color.LightGreen);
            }
        }
        public static void showAttackedTiles(ref SpriteBatch s, ref GraphicsDeviceManager g, ref ChessBoard chess) // show attack tiles for debugging 
        {
            
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (chess.Tiles[i, j].UnderWhiteAttack && chess.Tiles[i, j].UnderBlackAttack)
                        chess.Tiles[i, j].colorSelection(ref s, ref g, Color.Purple);
                    else if (chess.Tiles[i, j].UnderWhiteAttack)
                        chess.Tiles[i, j].colorSelection(ref s, ref g, Color.Blue);
                    else if (chess.Tiles[i, j].UnderBlackAttack)
                        chess.Tiles[i, j].colorSelection(ref s, ref g, Color.Red);

                }
            }
        }
        public static void checkColor(ref SpriteBatch s, ref GraphicsDeviceManager g, ref ChessBoard chess)  // highlighte king when checked
        {
            if (chess.Pieces[21].Position.UnderBlackAttack)
                chess.Pieces[21].Position.colorSelection(ref s, ref g, Color.Red);
            else if (chess.Pieces[20].Position.UnderWhiteAttack)
                chess.Pieces[20].Position.colorSelection(ref s, ref g, Color.Red);

        }
    }
}
