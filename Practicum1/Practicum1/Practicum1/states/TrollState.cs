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
    class TrollState : State
    {
        Ball[] ballarray = new Ball[100];
        public Paddle player1, player2;
        public List<Paddle> paddleList = new List<Paddle>();
        public TrollState(ContentManager Content)
        {
            player1 = new Paddle(Content.Load<Texture2D>("rodeSpeler"), Content.Load<Texture2D>("balRood"), new Vector2(0, 300), 350, Keys.W, Keys.S, true, "Player 1");
            player2 = new Paddle(Content.Load<Texture2D>("blauweSpeler"), Content.Load<Texture2D>("balBlauw"), new Vector2(Practicum1.Screen.X - 15, 300), 350, Keys.Up, Keys.Down, true, "Player 2");
            paddleList.Add(player1);
            paddleList.Add(player2);
            for (int i = 0; i < 100; ++i)
            {
                ballarray[i] = new Ball(Content.Load<Texture2D>("bal"), new Vector2(Practicum1.Screen.X / 2 + 5 * i, Practicum1.Screen.Y / 2 + 5 * i), 275, paddleList, "Ball" + i);
                this.Add(ballarray[i]);
            }
            this.Add(player1);
            this.Add(player2);
        }
        public override void Update(GameTime gameTime)
        {
            /*
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
            */
            base.Update(gameTime);
        }
        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
        }
    }
}