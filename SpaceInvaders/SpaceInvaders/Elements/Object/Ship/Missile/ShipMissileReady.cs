using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShipMissileReady : ShipMissileState
    {
        public override void Handle(Ship ship)
        {
            ship.SetMissileState(ShipManager.MissileState.MissileFlying);
            Debug.WriteLine("Change to State: Missile FLying");
        }

        public override void ShootMissile(Ship ship)
        {
            Missile missile = ShipManager.ActivateMissile();
            missile.SetPosition(ship.x, ship.y + 20); // Shoot from the Ship

            this.Handle(ship);
        }

    }
}