using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SampleCommand : Command
    {
        private String String;
        public SampleCommand(String text)
        {
            // string only for testing
            this.String = text;
        }

        public override void Execute(float deltaTime)
        {
            Debug.WriteLine(" {0} time:{1} ", this.String, TimerEventManager.GetCurrentTime());
        }

    }
}

