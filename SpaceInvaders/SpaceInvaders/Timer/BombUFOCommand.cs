using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class BombUFOCommand : Command
    {

        public BombUFOCommand()
        {
        }

        public override void Execute(float deltaTime)
        {
            BombRoot bomb_root_UFO = (BombRoot)GameObjectNodeManager.Find(GameObject.Name.BombRootUFO);
            bomb_root_UFO.MoveRoot();


            TimerEventManager.AddToIndex(TimerEvent.Name.ObjectMovement, this, deltaTime);
        }
    }
}
