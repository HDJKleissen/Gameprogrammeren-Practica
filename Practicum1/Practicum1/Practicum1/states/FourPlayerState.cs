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
    class FourPlayerState : State
    {
        protected Ball ball;
        protected Paddle player1, player2, player3, player4;
        protected List<Paddle> paddleList = new List<Paddle>();
        protected PowerUp powerUp1, powerUp2;
        protected TextObject pausedText;
        protected bool paused;

        public FourPlayerState(ContentManager Content)
        {
            player1 = new Paddle(Content.Load<Texture2D>("rodeSpeler"), Content.Load<Texture2D>("balRood"), new Vector2(0, 400), 350, Keys.W, Keys.S, true, "Player 1");
            player2 = new Paddle(Content.Load<Texture2D>("blauweSpeler"), Content.Load<Texture2D>("balBlauw"), new Vector2(Practicum1.Screen.X - 16, 400), 350, Keys.Up, Keys.Down, true, "Player 2");
            player3 = new Paddle(Content.Load<Texture2D>("geleSpeler"), Content.Load<Texture2D>("balGeel"), new Vector2(400, 0), 350, Keys.U, Keys.I, false, "Player 3");
            player4 = new Paddle(Content.Load<Texture2D>("groeneSpeler"), Content.Load<Texture2D>("balGroen"), new Vector2(400, Practicum1.Screen.Y - 16), 350, Keys.V, Keys.B, false, "Player 4");
            
            paddleList.Add(player1);
            paddleList.Add(player2);
            paddleList.Add(player3);
            paddleList.Add(player4);

            ball = new Ball(Content.Load<Texture2D>("bal"), new Vector2(Practicum1.Screen.X / 2, Practicum1.Screen.Y / 2), 275, paddleList, "Ball");
            
            powerUp1 = new PowerUp(null, new Vector2(0, 0), Content, "Powerup 1");
            powerUp2 = new PowerUp(null, new Vector2(0, 0), Content, "Powerup 2");
            
            powerUpList.Add(powerUp1);
            powerUpList.Add(powerUp2);

            pausedText = new TextObject("Game paused.", new Vector2(Practicum1.Screen.X / 2 - 80, Practicum1.Screen.Y / 2), Color.Black, null, "Pause Text");
            pausedText.Visible = false;

            
            this.Add(player1);
            this.Add(player2);
            this.Add(player3);
            this.Add(player4);
            this.Add(ball);
            this.Add(powerUp1);
            this.Add(powerUp2);
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
            if (!paused)
            {
                base.Update(gameTime);
                int paddlesAlive = 0, i = 0;
                bool[] isAlive = new bool[4];
                foreach (Paddle paddle in paddleList)
                {
                    if (paddle.Lives > 0)
                    {
                        isAlive[i] = true;
                        paddlesAlive++;
                    }
                    else
                    {
                        isAlive[i] = false;
                    }
                    i++;
                }
                if (paddlesAlive == 1)
                {
                    for (int j = 0; j < isAlive.Length; j++)
                    {
                        if (isAlive[j])
                        {
                            switch (j)
                            {
                                case 0:
                                    Practicum1.WinPaddle = player1;
                                    break;
                                case 1:
                                    Practicum1.WinPaddle = player2;
                                    break;
                                case 2:
                                    Practicum1.WinPaddle = player3;
                                    break;
                                case 3:
                                    Practicum1.WinPaddle = player4;
                                    break;
                            }
                            Practicum1.GameStateManager.Reset();
                            Practicum1.GameStateManager.SwitchTo("gameOverState");
                            return;
                        }
                    }
                }
            }
        }
    }
}
