using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
namespace Chess
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public enum GameState  // switch between start menu and Game
    {StartMenu,Game }
     class Game1 : Microsoft.Xna.Framework.Game
    {
        public GameState state;  
         //let the game read the promotion form
        public static PromotionForm pf;  // poromotion form object ,, connect the game with the form 
        GraphicsDeviceManager graphics; 
        SpriteBatch spriteBatch;
        double delayTime;  // time to delay the message box of winning
        ChessBoard chess;  // connect the game with the chessboard
        public Player player1,player2;  // connect players with the game
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 900;
            Content.RootDirectory = "Content";
            state = GameState.StartMenu;
            delayTime = 0;
            Player.ChessGame = this;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            IsMouseVisible = true;
            chess = new ChessBoard();
            chess.Origin = new Vector2(250, 20);
            chess.setBorders();
            player1 = new Player(true);
            player2 = new Player(false);
            Player.WhitePlayerTurn = true;
            Mouse.WindowHandle = Window.Handle; 
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            chess.loadTexture(Content);
            chess.setPieces(Content);
            StartMenu.loadStartMenu();
            chess.loadTurnInformation();

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            switch (state)
            {
                case GameState.StartMenu:
                    StartMenu.clickOnStartGame(Mouse.GetState());
                    StartMenu.clickOnExitGame(Mouse.GetState());
                    break;
                case GameState.Game:
                    player1.attemptsToMove(Mouse.GetState(), ref chess);
                    player2.attemptsToMove(Mouse.GetState(), ref chess);
                    player1.clicksOnPiece(Mouse.GetState(), ref chess);
                    player2.clicksOnPiece(Mouse.GetState(), ref chess);
                    if (player1.Checkmate)
                    {
                        delayTime += gameTime.ElapsedGameTime.TotalSeconds;
                        if (delayTime  >= 0.5)
                        {
                            System.Windows.Forms.MessageBox.Show("Black player wins by checkmate");
                            this.Exit();
                        }
                    }
                    else if (player2.Checkmate)
                    {
                        delayTime += gameTime.ElapsedGameTime.TotalSeconds;
                        if (delayTime  >= 0.5)
                        {
                            System.Windows.Forms.MessageBox.Show("White player wins by checkmate");
                            this.Exit();
                        }
                    }
                    break;
            }
            // TODO: Add your update logic here
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            switch (state)
            {
                case GameState.Game:
                    GraphicsDevice.Clear(Color.CornflowerBlue);
                    // TODO: Add your drawing code here
                    spriteBatch.Begin();
                    chess.draw(ref spriteBatch);
                    Player.checkColor(ref spriteBatch, ref graphics, ref chess);
                    player1.selectionUpdate(ref spriteBatch, ref graphics, ref chess);
                    player2.selectionUpdate(ref spriteBatch, ref graphics, ref chess);
                    //Player.showAttackedTiles(ref spriteBatch, ref graphics, ref chess);
                    chess.drawPieces(ref spriteBatch);
                    chess.drawTurnInformation(ref spriteBatch);
                    spriteBatch.End();
                    break;
                case GameState.StartMenu:
                    GraphicsDevice.Clear(Color.White);
                    spriteBatch.Begin();
                    StartMenu.drawStartMenu(ref spriteBatch, ref graphics);
                    spriteBatch.End();
                    break;
            }
            base.Draw(gameTime);
        }
    }
}
