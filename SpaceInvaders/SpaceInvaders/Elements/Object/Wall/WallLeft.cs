using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class WallLeft : WallCategory
    {
        public WallLeft(GameObject.Name name, Sprite.Name spriteName, float posX, float posY, float width, float height)
            : base(name, spriteName, posX, posY, Type.Left)
        {
            this.collison_object.collision_rect.Set(posX, posY, width, height);

            this.x = posX;
            this.y = posY;


            this.collison_object.CollisionSpriteBox.SetColor(1, 1, 0);
        }

        ~WallLeft()
        {

        }

        public override void Accept(CollisionVisitor other)
        {
            // Important: at this point we have an Alien
            // Call collision reaction            
            other.VisitWallLeft(this);
        }

        public override void Move()
        {
        }

        public override void Update()
        {
            // Go to first child
            base.Update();
        }

        public override void VisitGrid(AlienGrid alien_grid)
        {
            // AlienGroup vs WallLeft
            Debug.WriteLine("\nCollide: {0} with {1}", this, alien_grid);
            Debug.WriteLine("FINISHED!");

            CollisionPair collision_pair = CollisionPairManager.GetActiveColPair();
            Debug.Assert(collision_pair != null);

            collision_pair.SetCollision(alien_grid, this);
            collision_pair.NotifyListeners();
        }
    }
}