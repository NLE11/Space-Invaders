using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShipRoot : Composite
    {
        public ShipRoot(GameObject.Name name, Sprite.Name spriteName, SpriteBox.Name spriteboxName, float posX, float posY)
            : base(name, spriteName, spriteboxName)
        {
            this.x = posX;
            this.y = posY;

            this.collison_object.CollisionSpriteBox.SetColor(0, 0, 1);
        }

        ~ShipRoot()
        {
        }

        public override void Accept(CollisionVisitor other)
        {           
            other.VisitShipRoot(this);
        }

        public override void VisitBombRoot(BombRoot b)
        {
            // MissileRoot vs AlienRoot
            GameObject game_object = (GameObject)CompositeForwardIterator.GetChild(b);
            CollisionPair.Collide(game_object, this);
        }

        public override void VisitBomb(Bomb b)
        {
            // MissileGroup vs this leaf
            Debug.WriteLine("\nCollide: {0} with {1}", b, this);
            Debug.WriteLine("FINISHED!");


            CollisionPair collision_pair = CollisionPairManager.GetActiveColPair();
            Debug.Assert(collision_pair != null);

            collision_pair.SetCollision(b, this);
            collision_pair.NotifyListeners();
        }

        public override void Update()
        {
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }
        public override void VisitBumperRoot(BumperRoot b)
        {
            // Missile vs ShieldGrid
            GameObject game_object = (GameObject)CompositeForwardIterator.GetChild(b);
            CollisionPair.Collide(this, game_object);
        }
    }
}
