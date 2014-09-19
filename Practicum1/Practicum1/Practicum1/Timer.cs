using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Practicum1
{
    public class Timer
    {
        float timer;
        public Timer(float timer)
        {
            this.timer = timer;
        }

        public void Update(GameTime gameTime)
        {
            float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            timer -= elapsedTime;
        }

        public bool timerDone()
        {
            return timer < 0;
        }
    }
}
