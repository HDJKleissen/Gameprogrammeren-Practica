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
        public static List<PowerUp> powerUpList = new List<PowerUp>();
        public bool powerUpsOn;
        public PowerUp powerUp1, powerUp2;
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

            Array powerUpsArray = Enum.GetValues(typeof(PowerUpType));
            PowerUpType chosenType1 = (PowerUpType)powerUpsArray.GetValue(Practicum1.Random.Next(powerUpsArray.Length));
            Texture2D pwrupSprite1 = TextureFromPowerUpType(chosenType1, Content);
            PowerUpType chosenType2 = (PowerUpType)powerUpsArray.GetValue(Practicum1.Random.Next(powerUpsArray.Length));
            Texture2D pwrupSprite2 = TextureFromPowerUpType(chosenType2, Content);


            powerUp1 = new PowerUp(chosenType1, pwrupSprite1, new Vector2(100, 100), "Powerup 1");
            powerUp2 = new PowerUp(chosenType2, pwrupSprite2, new Vector2(200, 200), "Powerup 2");
            this.Add(powerUp1);
            this.Add(powerUp2);
        }

        public override void Update(GameTime gameTime)
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

        public bool PowerUpsOn
        {
            get { return powerUpsOn; }
            set { powerUpsOn = value; }
        }

        public Texture2D TextureFromPowerUpType(PowerUpType chosenType, ContentManager Content)
        {
            switch (chosenType)
            {
                case PowerUpType.OPSmaller:
                    return Content.Load<Texture2D>("pwrupOPSmaller");
                case PowerUpType.OPSlower:
                    return Content.Load<Texture2D>("pwrupOPSlower");
                case PowerUpType.TPBigger:
                    return Content.Load<Texture2D>("pwrupTPBigger");
                case PowerUpType.TPFaster:
                    return Content.Load<Texture2D>("pwrupTPFaster");
                default:
                    return Content.Load<Texture2D>("");
            }
        }

        public static List<PowerUp> PowerUpList
        {
            get { return powerUpList; }
        }
    }
}
