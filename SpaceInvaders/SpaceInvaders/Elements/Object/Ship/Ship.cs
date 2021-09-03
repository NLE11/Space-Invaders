using System;
using System.Diagnostics;


namespace SpaceInvaders
{
    public class Ship : ShipCategory
    {
        public float shipSpeed;
        private ShipMoveState moving_state;
        private ShipMissileState missile_state;

        public Ship(GameObject.Name name, Sprite.Name spriteName, float positionX, float positionY)
         : base(name, spriteName, positionX, positionY, ShipCategory.Type.Ship)
        {
            this.x = positionX;
            this.y = positionY;

            this.shipSpeed = 3.0f;
            //this.moving_state = null;
            this.missile_state = null;
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Accept(CollisionVisitor other)
        {
            // A bomb may visit this ship
            other.VisitShip(this);
        }

        public void MoveRight()
        {
            this.moving_state.MoveRight(this);
        }

        public void MoveLeft()
        {
            this.moving_state.MoveLeft(this);
        }

        public void SetMoveState(ShipManager.MoveState inState)
        {
            this.moving_state = ShipManager.GetMoveState(inState);
        }

        public void ShootMissile()
        {
            this.missile_state.ShootMissile(this);
           
        }

        public void SetMissileState(ShipManager.MissileState inState)
        {
            this.missile_state = ShipManager.GetMissileState(inState);
        }

        public override void Move()
        {
        }

        public override void Remove()
        {
            // Keenan(delete.E)
            // Since the Root object is being drawn
            // 1st set its size to zero
            this.collison_object.collision_rect.Set(0, 0, 0, 0);
            base.Update();

            // Update the parent (missile root)
            GameObject parent = (GameObject)this.parent;
            parent.Update();

            // Now remove it
            base.Remove();
        }
    }
}