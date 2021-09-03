using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class AlienMoveRight : AlienMoveState
    {
        public override void Handle(AlienRoot alien_root)
        {
            alien_root.SetMoveState(AlienManager.MoveState.MoveRight);
        }

        public override void MoveUp(AlienRoot alien_root)
        {

        }
        public override void MoveDown(AlienRoot alien_root)
        {

        }

        public override void MoveLeft(AlienRoot alien_root)
        {

        }

        public override void MoveRight(AlienRoot alien_root)
        {

        }
    }
}