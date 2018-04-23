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
{//287X127
    abstract class StartMenu
    {
        private static bool startClicked=false;  // start game button click
        private static bool exitClicked = false; // exit game button click
        public static Texture2D BackgroundTexture
        {get;set;}
        public static Texture2D StartGameButtonTexture 
        { get; set; }
        public static Texture2D ExitButtonTexture
        { get; set; }
        private static Vector2 StartGameButtonPosition  // default position for drawing start button
        { get { return new Vector2(300, 250); } }
        private static Vector2 ExitButtonPosition //default position for drawing exit button
        { get { return new Vector2(300, 400); } }
        
        public static void loadStartMenu()
        {
            BackgroundTexture = Player.ChessGame.Content.Load<Texture2D>(@"Chess_Strategies");
            StartGameButtonTexture = Player.ChessGame.Content.Load<Texture2D>(@"Start Game (Neutral)");
            ExitButtonTexture = Player.ChessGame.Content.Load<Texture2D>(@"Exit (Neutral)");
        }
        public static void drawStartMenu(ref SpriteBatch s,ref GraphicsDeviceManager g)
        {
            s.Draw(BackgroundTexture, new Vector2(0, 0), Color.White);
            s.Draw(StartGameButtonTexture, StartGameButtonPosition, Color.White);
            s.Draw(ExitButtonTexture, ExitButtonPosition, Color.White);
        }
        public static void clickOnStartGame(MouseState click)
        {
             Rectangle startGameRect=new Rectangle((int)StartGameButtonPosition.X,(int)StartGameButtonPosition.Y,287,127);
             if (click.LeftButton == ButtonState.Pressed)
                 if (startGameRect.Contains(new Point(click.X, click.Y)))
                 {
                     StartGameButtonTexture = Player.ChessGame.Content.Load<Texture2D>(@"Start Game (Clicked)");
                     startClicked = true;
                 }
            if(startClicked)
            if(click.LeftButton==ButtonState.Released)
                if (startGameRect.Contains(new Point(click.X, click.Y)))
                    Player.ChessGame.state = GameState.Game;
                else
                {
                    StartGameButtonTexture = Player.ChessGame.Content.Load<Texture2D>(@"Start Game (Neutral)");
                    startClicked = false;
                }
        }
        public static void clickOnExitGame(MouseState click)
        {
            Rectangle exitRect = new Rectangle((int)ExitButtonPosition.X, (int)ExitButtonPosition.Y, 287, 127);
            if (click.LeftButton == ButtonState.Pressed)
                if (exitRect.Contains(new Point(click.X, click.Y)))
                {
                    ExitButtonTexture = Player.ChessGame.Content.Load<Texture2D>(@"Exit (Clicked)");
                    exitClicked = true;
                }
            if (exitClicked)
                if (click.LeftButton == ButtonState.Released)
                    if (exitRect.Contains(new Point(click.X, click.Y)))
                        Player.ChessGame.Exit();
                    else
                    {
                        ExitButtonTexture = Player.ChessGame.Content.Load<Texture2D>(@"Exit (Neutral)");
                        exitClicked = false;
                    }
        }
    }
}
