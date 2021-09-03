using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShipMoveBoth : ShipMoveState
    {
        public override void Handle(Ship ship)
        {
            Debug.WriteLine("Move Both");
        }

        public override void MoveRight(Ship ship)
        {
            ship.x += ship.shipSpeed;
        }

        public override void MoveLeft(Ship ship)
        {
            ship.x -= ship.shipSpeed;
        }

    }
}