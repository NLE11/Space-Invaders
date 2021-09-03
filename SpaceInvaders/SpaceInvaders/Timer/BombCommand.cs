using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class BombCommand : Command
    {

        public BombCommand()
        {
        }

        public override void Execute(float deltaTime)
        {
            BombRoot bomb_root = (BombRoot)GameObjectNodeManager.Find(GameObject.Name.BombRoot);
            bomb_root.MoveRoot();


            TimerEventManager.AddToIndex(TimerEvent.Name.ObjectMovement, this, deltaTime);
        }
    }
}
