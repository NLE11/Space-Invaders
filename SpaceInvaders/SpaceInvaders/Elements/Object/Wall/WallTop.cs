using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class WallTop : WallCategory
    {
        public WallTop(GameObject.Name name, Sprite.Name spriteName, float posX, float posY, float width, float height)
            : base(name, spriteName, posX, posY, Type.Top)
        {
            this.collison_object.collision_rect.Set(posX, posY, width, height);

            this.x = posX;
            this.y = posY;


            this.collison_object.CollisionSpriteBox.SetColor(1, 1, 0);
        }

        ~WallTop()
        {

        }

        public override void Accept(CollisionVisitor other)
        {
            // Important: at this point we have an Alien
            // Call collision reaction            
            other.VisitWallTop(this);
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

        }

        public override void VisitMissile(Missile m)
        {
            // Missile vs WallTop
            Debug.WriteLine(" ---> Hit the wall!");
            CollisionPair collision_pair = CollisionPairManager.GetActiveColPair();
            collision_pair.SetCollision(m, this);
            collision_pair.NotifyListeners();
        }
    }
}