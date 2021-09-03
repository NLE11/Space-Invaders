using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShipMoveObserver : CollisionObserver
    {
        public override void Notify()
        {
            Ship ship = ShipManager.GetShip();

            BumperCategory Bumper = (BumperCategory)this.Subject.Object_B;
            if (Bumper.GetCategoryType() == BumperCategory.Type.Left)
            {
                ship.SetMoveState(ShipManager.MoveState.MoveRight);
            }
            else if (Bumper.GetCategoryType() == BumperCategory.Type.Right)
            {
                ship.SetMoveState(ShipManager.MoveState.MoveLeft);
            }
        }
    }
}
