using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShipMissileFlying : ShipMissileState
    {
        public override void Handle(Ship ship)
        {
            Debug.WriteLine("State: Missile Flying");
        }

        public override void ShootMissile(Ship ship)
        {
            this.Handle(ship);
        }
    }
}