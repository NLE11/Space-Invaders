using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class AlienGrid : Composite
    {
        public AlienGrid(GameObject.Name name, Sprite.Name spriteName, SpriteBox.Name spriteboxName, float posX, float posY)
            : base(name, spriteName, spriteboxName)
        {
            //Debug.WriteLine("Grid proxy sprite: {0}", this.pSpriteProxy.GetHashCode());
            //Debug.WriteLine("Grid col   sprite: {0}",this.poColObj.pColSprite.GetHashCode());
            this.x = posX;
            this.y = posY;

            this.SetCollisionColor(0.0f, 0.0f, 1.0f);
        }

        public void Resurrect(float posX, float posY)
        {
            this.x = posX;
            this.y = posY;

            this.SetCollisionColor(0.0f, 0.0f, 1.0f);

            base.Resurrect();
        }
        ~AlienGrid()
        {
        }

        public override void Accept(CollisionVisitor other)
        {
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction            
            other.VisitGrid(this);
        }

        public override void VisitMissileGroup(MissileGroup m)
        {
            // Missile vs ShieldGrid
            GameObject game_object = (GameObject)CompositeForwardIterator.GetChild(m);
            CollisionPair.Collide(game_object, this );
        }

        public override void VisitMissile(Missile m)
        {
            // Missile vs ShieldGrid
            GameObject game_object = (GameObject)CompositeForwardIterator.GetChild(this);
            CollisionPair.Collide(m, game_object);
        }

        public override void Update()
        {
            // Go to first child
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }
    }
}
