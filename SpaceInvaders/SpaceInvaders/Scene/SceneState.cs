using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class SceneState
    {
        public float TimeAtPause;
        public TimerEventManager TimerEventManager;

        public SceneState()
        {
            this.TimerEventManager = new TimerEventManager(3, 1);
            TimerEventManager.SetActive(this.TimerEventManager);
            this.TimeAtPause = TimerEventManager.GetCurrentTime();
        }
        public abstract void Handle();
        public abstract void Initialize();
        public abstract void Update(float systemTime);
        public abstract void Draw();
        public abstract void Entering();
        public abstract void Leaving();
    }
}