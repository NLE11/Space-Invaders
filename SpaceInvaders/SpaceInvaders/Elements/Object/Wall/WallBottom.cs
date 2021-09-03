using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class WallBottom : WallCategory
    {
        public WallBottom(GameObject.Name name, Sprite.Name spriteName, float posX, float posY, float width, float height)
            : base(name, spriteName, posX, posY, Type.Bottom)
        {
            this.collison_object.collision_rect.Set(posX, posY, width, height);

            this.x = posX;
            this.y = posY;


            this.collison_object.CollisionSpriteBox.SetColor(1, 1, 0);
        }

        ~WallBottom()
        {

        }

        public override void Accept(CollisionVisitor other)
        {
            // Important: at this point we have an Alien
            // Call collision reaction            
            other.VisitWallBottom(this);
        }

        public override void Move()
        {
        }

        public override void Update()
        {
            // Go to first child
            base.Update();
        }

        public override void VisitBombRoot(BombRoot b)
        {
            // BombRoot vs WallBottom
            GameObject game_object = (GameObject)CompositeForwardIterator.GetChild(b);
            CollisionPair.Collide(game_object, this);
        }

        public override void VisitBomb(Bomb b)
        {
            // Bomb v Wall
            Debug.WriteLine("\nCollide: {0} with {1}", b, this);
            Debug.WriteLine("FINISHED!");


            CollisionPair collision_pair = CollisionPairManager.GetActiveColPair();
            Debug.Assert(collision_pair != null);

            collision_pair.SetCollision(b, this);
            collision_pair.NotifyListeners();
        }

    }
}