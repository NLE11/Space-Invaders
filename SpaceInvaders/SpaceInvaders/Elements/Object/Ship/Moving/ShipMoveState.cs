using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class ShipMoveState
    {
        public abstract void Handle(Ship ship);
        public abstract void MoveRight(Ship ship);
        public abstract void MoveLeft(Ship ship);
    }
}