using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Practicum1
{
    public class TimerManager
    {
        Dictionary<string, float> timers;
        public TimerManager()
        {
            timers = new Dictionary<string, float>();
        }

        public void setTimer(string name, float time)
        {
            timers[name] = time;
        }

        public void removeTimer(string name)
        {
            timers.Remove(name);   
        }

        public float getTimeLeft(string name)
        {
            return timers[name];
        }
        public void Update(GameTime gameTime)
        {
            foreach(string key in new List<string>(timers.Keys))
            {
                if (timers[key] >= 0)
                {
                    float tempTime = timers[key];
                    float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
                    tempTime -= elapsedTime;
                    timers[key] = tempTime;
                }
            }
        }

        public bool TimerDone(string name)
        {
            return timers[name] < 0;
        }
    }
}
