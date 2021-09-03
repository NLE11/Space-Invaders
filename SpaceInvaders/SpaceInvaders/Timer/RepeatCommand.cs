using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class RepeatCommand : Command
    {
        private String String;
        private float repeatDelta;

        public RepeatCommand(String text, float deltaRepeatDuration)
        {
            this.String = text;
            this.repeatDelta = deltaRepeatDuration;
        }
        public override void Execute(float deltaTime)
        {
            Debug.WriteLine("{0} time: {1}", this.String, TimerEventManager.GetCurrentTime());
            TimerEventManager.AddToIndex(TimerEvent.Name.RepeatSample, this, this.repeatDelta);
        }
    }
}
