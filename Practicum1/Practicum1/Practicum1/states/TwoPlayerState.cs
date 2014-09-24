using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Practicum1.gameobjects;

namespace Practicum1.states
{
    class TwoPlayerState : State
    {
        protected Ball ball;
        protected Paddle player1, player2;
        protected List<Paddle> paddleList = new List<Paddle>();
        protected PowerUp powerUp1, powerUp2;
        protected bool paused;
        protected TextObject pausedText;
        
        public TwoPlayerState(ContentManager Content)
        {
            paused = false;
            player1 = new Paddle(Content.Load<Texture2D>("rodeSpeler"), Content.Load<Texture2D>("balRood"), new Vector2(0, 300), 350, Keys.W, Keys.S, true, "Player 1");
            player2 = new Paddle(Content.Load<Texture2D>("blauweSpeler"), Content.Load<Texture2D>("balBlauw"), new Vector2(Practicum1.Screen.X - 16, 300), 350, Keys.Up, Keys.Down, true, "Player 2");
            paddleList.Add(player1);
            paddleList.Add(player2);
            ball = new Ball(Content.Load<Texture2D>("bal"), new Vector2(Practicum1.Screen.X / 2, Practicum1.Screen.Y / 2), 275, paddleList, "Ball");
            this.Add(player1);
            this.Add(player2);
            this.Add(ball);

            powerUp1 = new PowerUp(null, new Vector2(0, 0), Content, "Powerup 1");
            powerUp2 = new PowerUp(null, new Vector2(0, 0), Content, "Powerup 2");
            
            this.Add(powerUp1);
            this.Add(powerUp2);
            powerUpList.Add(powerUp1);
            powerUpList.Add(powerUp2);

            pausedText = new TextObject("Game paused.", new Vector2(Practicum1.Screen.X / 2 - 80, Practicum1.Screen.Y / 2), Color.Black, null, "Pause Text");
            pausedText.Visible = false;
            this.Add(pausedText);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            if (inputHelper.IsKeyPressed(Keys.P))
            {
                paused = !paused;
                pausedText.Visible = paused;
            }
            base.HandleInput(inputHelper);
        }

        public override void Update(GameTime gameTime)
        {
            if(!paused)
            {
                if (player1.Lives <= 0)
                {
                    Practicum1.WinPaddle = player2;
                    Practicum1.GameStateManager.Reset();
                    Practicum1.GameStateManager.SwitchTo("gameOverState");
                }
                if (player2.Lives <= 0)
                {
                    Practicum1.WinPaddle = player1;
                    Practicum1.GameStateManager.Reset();
                    Practicum1.GameStateManager.SwitchTo("gameOverState");
                }
                base.Update(gameTime);
            }
        }
    }
}
