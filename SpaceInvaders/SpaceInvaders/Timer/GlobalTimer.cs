using System.Diagnostics;

namespace SpaceInvaders
{
    class GlobalTimer
    {
        // Data
        private static GlobalTimer Instance = null;
        protected float CurrentTime;
      
        private GlobalTimer()
        {
            this.CurrentTime = 0.0f;
        }

        public static void Update(float time)
        {
            GlobalTimer Timer = GlobalTimer.GetInstance();
            Timer.CurrentTime = time;
        }

        public static float GetTime()
        {
            GlobalTimer Timer = GlobalTimer.GetInstance();
            return Timer.CurrentTime;
        }

        //----------------------------------------------------------------------
        // Private methods
        //----------------------------------------------------------------------
        private static GlobalTimer GetInstance()
        {
            // Safety - this forces users to call Create() first before using class
            // Do the initialization
            if (Instance == null)
            {
                Instance = new GlobalTimer();
            }

            return Instance;
        }
    }
}