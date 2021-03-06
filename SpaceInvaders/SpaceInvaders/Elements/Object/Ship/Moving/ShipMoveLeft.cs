using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShipMoveLeft : ShipMoveState
    {
        public override void Handle(Ship ship)
        {
            ship.SetMoveState(ShipManager.MoveState.MoveBoth);
        }

        public override void MoveRight(Ship ship)
        {

        }
        public override void MoveLeft(Ship ship)
        {
            ship.x -= ship.shipSpeed;
            this.Handle(ship);
        }

    }
}