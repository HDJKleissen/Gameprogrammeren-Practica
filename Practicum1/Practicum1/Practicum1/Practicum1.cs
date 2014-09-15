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
namespace Practicum1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Practicum1 : Microsoft.Xna.Framework.Game
    {
        protected GraphicsDeviceManager graphics;
        protected SpriteBatch spriteBatch;
        public Ball ball;
        public Paddle player1, player2;
        public List<Paddle> paddleList = new List<Paddle>();

        protected static Point screen;
        protected static SpriteFont gameFont;
         static GameStateManager gameStateManager;

        public Practicum1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            gameStateManager = new GameStateManager();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            screen = new Point(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);

            player1 = new Paddle(Content.Load<Texture2D>("rodeSpeler"), Content.Load<Texture2D>("balRood"), new Vector2(0, 300), "Player 1");
            player2 = new Paddle(Content.Load<Texture2D>("blauweSpeler"), Content.Load<Texture2D>("balBlauw"), new Vector2(Practicum1.Screen.X - 15, 300), "Player 2");
            gameFont = Content.Load<SpriteFont>("GameFont");
            paddleList.Add(player1);
            paddleList.Add(player2);
            ball = new Ball(Content.Load<Texture2D>("bal"), new Vector2(Practicum1.Screen.X / 2, Practicum1.Screen.Y / 2), 275, paddleList, "Ball");
        }
        
        protected override void Update(GameTime gameTime)
        {
            /*if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            ball.Update(gameTime);
            player1.Update(gameTime);
            player2.Update(gameTime);
            player1.Move(Keys.W, Keys.S, 350);
            player2.Move(Keys.Up, Keys.Down, 350);
            player1.checkMaxRange();
            player2.checkMaxRange();

            if (player1.Lives <= 0)
                EndGame(player1);
            else if (player2.Lives <= 0)
                EndGame(player2);*/
            gameStateManager.Update(gameTime);
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
    }
}