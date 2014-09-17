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
        public Ball ball;
        public Paddle player1, player2;
        public List<Paddle> paddleList = new List<Paddle>();
        public TwoPlayerState(ContentManager Content)
        {
            player1 = new Paddle(Content.Load<Texture2D>("rodeSpeler"), Content.Load<Texture2D>("balRood"), new Vector2(0, 300), 350, Keys.W, Keys.S, "Player 1");
            player2 = new Paddle(Content.Load<Texture2D>("blauweSpeler"), Content.Load<Texture2D>("balBlauw"), new Vector2(Practicum1.Screen.X - 15, 300), 350, Keys.Up, Keys.Down, "Player 2");
            paddleList.Add(player1);
            paddleList.Add(player2);
            ball = new Ball(Content.Load<Texture2D>("bal"), new Vector2(Practicum1.Screen.X / 2, Practicum1.Screen.Y / 2), 275, paddleList, "Ball");
            this.Add(player1);
            this.Add(player2);
            this.Add(ball);  
        }

        public override void Update(GameTime gameTime)
        {
            if (player1.Lives <= 0)
            {
                Practicum1.WinPaddle = player2;
                Practicum1.GameStateManager.SwitchTo("gameOverState");
            }
            if (player2.Lives <= 0)
            {
                Practicum1.WinPaddle = player1;
                Practicum1.GameStateManager.SwitchTo("gameOverState");
            }
            base.Update(gameTime);
        }
    }
}
