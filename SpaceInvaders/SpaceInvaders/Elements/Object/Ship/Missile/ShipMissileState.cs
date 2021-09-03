using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class ShipMissileState
    {
        // Transitions to correct state
        public abstract void Handle(Ship ship);

        public abstract void ShootMissile(Ship ship);
    }
}