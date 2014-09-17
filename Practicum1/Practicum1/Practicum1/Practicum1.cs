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
using Practicum1.states;

namespace Practicum1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Practicum1 : Microsoft.Xna.Framework.Game
    {
        protected GraphicsDeviceManager graphics;
        protected SpriteBatch spriteBatch;
        protected static Point screen;
        protected static SpriteFont gameFont;
        protected static GameStateManager gameStateManager;
        protected static InputHelper inputHelper;
        protected static Paddle winPaddle;

        public Practicum1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            gameStateManager = new GameStateManager();
            inputHelper = new InputHelper();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            screen = new Point(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            gameFont = Content.Load<SpriteFont>("GameFont");
            gameStateManager.AddGameState("mainMenuState", new MainMenuState());
            gameStateManager.AddGameState("gameOverState", new GameOverState());
            gameStateManager.AddGameState("twoPlayerState", new TwoPlayerState(Content));
            gameStateManager.SwitchTo("mainMenuState");
        }
        
        protected override void Update(GameTime gameTime)
        {
            inputHelper.Update();
            gameStateManager.Update(gameTime);
            gameStateManager.HandleInput(inputHelper);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            GraphicsDevice.Clear(Color.White);
            /*ball.Draw(gameTime, spriteBatch);
            player1.Draw(gameTime, spriteBatch);
            player2.Draw(gameTime, spriteBatch);*/
            gameStateManager.Draw(gameTime, spriteBatch);
            spriteBatch.End();
        }

        private void EndGame(Paddle winningPlayer)
        {
            
        }

        public static Point Screen
        {
            get { return screen; }
        }

        public static SpriteFont GameFont
        {
            get { return gameFont; }
        }

        public static GameStateManager GameStateManager
        {
            get { return gameStateManager; }
        }

        public static InputHelper InputHelper
        {
            get { return inputHelper; }
        }

        public static Paddle WinPaddle
        {
            get { return winPaddle; }
            set { winPaddle = value; }
        }
    }
}