using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShipReadyObserver : CollisionObserver
    {
        public override void Notify()
        {
            Ship ship = ShipManager.GetShip();
            ship.SetMissileState(ShipManager.MissileState.Ready);
        }
    }
}
