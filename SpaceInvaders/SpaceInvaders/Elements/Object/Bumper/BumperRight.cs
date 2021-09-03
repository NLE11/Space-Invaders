using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class BumperRight : BumperCategory
    {
        public BumperRight(GameObject.Name name, Sprite.Name spriteName, float positionX, float positionY, float width, float height)
            : base(name, spriteName, positionX, positionY, BumperCategory.Type.Right)
        {
            this.collison_object.collision_rect.Set(positionX, positionY, width, height);

            this.x = positionX;
            this.y = positionY;

            this.collison_object.CollisionSpriteBox.SetColor(1, 1, 0);
        }

        ~BumperRight()
        {
        }
        public override void Accept(CollisionVisitor other)
        {
            // A ship may visit this           
            other.VisitBumperRight(this);
        }

        public override void Move()
        {
        }

        public override void Update()
        {
            // Go to first child
            base.Update();
        }

        public override void VisitShipRoot(ShipRoot s)
        {
            // MissileGroup vs this leaf
            //Debug.WriteLine("\nCollide: {0} with {1}", s, this);
            //Debug.WriteLine("FINISHED!");

            CollisionPair collision_pair = CollisionPairManager.GetActiveColPair();
            Debug.Assert(collision_pair != null);

            collision_pair.SetCollision(s, this);
            collision_pair.NotifyListeners();
        }

        public override void VisitUFORoot(UFORoot u)
        {
            Debug.WriteLine("\nCollide: {0} with {1}", u, this);
            Debug.WriteLine("FINISHED!");

            CollisionPair collision_pair = CollisionPairManager.GetActiveColPair();
            Debug.Assert(collision_pair != null);

            collision_pair.SetCollision(u, this);
            collision_pair.NotifyListeners();
        }
    }
}
