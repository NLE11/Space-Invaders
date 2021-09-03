using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class TimerEvent : DLink
    {
        public Name name;
        public Command Command;
        public float triggerTime;
        public float deltaTime;

        public enum Name
        {
            Sample1,
            Sample2,
            RepeatSample,

            SpriteAnimation,
            ObjectMovement,
            BombAction,
            BombUFOAction,
            UFOAction,

            TimedChar,
            Draw,

            Uninitialized
        }

        public TimerEvent()
        {
            this.name = TimerEvent.Name.Uninitialized;
            this.Command = null;
            this.triggerTime = 0.0f;
            this.deltaTime = 0.0f;
        }

        public void Set(TimerEvent.Name event_Name, Command command, float deltaTimeToTrigger)
        {
            Debug.Assert(command != null);

            this.name = event_Name;
            this.Command = command;
            this.deltaTime = deltaTimeToTrigger;

            //set trigger 
            this.triggerTime = TimerEventManager.GetCurrentTime() + deltaTimeToTrigger;
        }

        public void Process()
        {
            Debug.Assert(this.Command != null);

            this.Command.Execute(deltaTime);
        }

        public void Clear()
        {
            this.name = TimerEvent.Name.Uninitialized;
            this.Command = null;
            this.triggerTime = 0.0f;
            this.deltaTime = 0.0f;
        }

        public override void Wash()
        {
            this.Clear();
            base.Clear();
        }

        public override void Dump()
        {
            base.Dump();
            {
                Debug.WriteLine("Name of Event: {0} ({1})", this.name, this.GetHashCode());
                Debug.WriteLine("Command: {0}", this.Command);
                Debug.WriteLine("Trigger Time: {0}", this.triggerTime);
                Debug.WriteLine("Delta Time: {0}", this.deltaTime);

                base.Dump();
            }
        }

        public override bool Compare(NodeBase NodeToFind)
        {
            Debug.Assert(NodeToFind != null);
            TimerEvent node = (TimerEvent)NodeToFind;
            bool status = false;

            if (this.name == node.name)
            {
                status = true;
            }

            return status;
        }
    }
}
