using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class UFOCommand : Command
    {

        public UFOCommand()
        {
        }

        public override void Execute(float deltaTime)
        {
            UFORoot UFO_Root = (UFORoot)GameObjectNodeManager.Find(GameObject.Name.UFORoot);
            UFO_Root.MoveRoot();
            


            TimerEventManager.AddToIndex(TimerEvent.Name.ObjectMovement, this, deltaTime);
        }
    }
}
