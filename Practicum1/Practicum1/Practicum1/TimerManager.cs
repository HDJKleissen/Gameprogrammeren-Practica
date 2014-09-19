using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Practicum1
{
    class TimerManager
    {
        Dictionary<string, Timer> timers;
        public TimerManager()
        {
            timers = new Dictionary<string, Timer>();
        }

        public void addTimer(string name, Timer timer)
        {
            timers[name] = timer;
        }

        public void removeTimer(string name)
        {
            if(timers[name] != null)
            {
                timers.Remove(name);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach(var timer in timers.Keys)
            {
                timers[timer].Update(gameTime);
                if(timers[timer].timerDone())
                {
                    removeTimer(timer);
                }
            }
        }
    }
}
