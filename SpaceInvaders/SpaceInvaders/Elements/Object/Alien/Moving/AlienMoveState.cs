using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class AlienMoveState
    {
        public abstract void Handle(AlienRoot alien_root);
        public abstract void MoveUp(AlienRoot alien_root);
        public abstract void MoveDown(AlienRoot alien_root);
        public abstract void MoveLeft(AlienRoot alien_root);
        public abstract void MoveRight(AlienRoot alien_root);
    }
}