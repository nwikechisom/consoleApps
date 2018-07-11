using System;
using static System.Math;

namespace Teleprompter
{
    internal class TelePrompterConfig
    {
        private object lockHandle = new Object();
        public int DelayinMilliseconds { get; private set; } = 300;

        public void UpdateDelay(int increment)
        {
            var newDelay = Min(DelayinMilliseconds + increment, 1000);
            newDelay = Max(newDelay, 20);
            lock (lockHandle)
            {
                DelayinMilliseconds = newDelay;
            }
        }

        public bool Done { get; private set; }

        public void Setdone()
        {
            Done = true;
        }
    }
}