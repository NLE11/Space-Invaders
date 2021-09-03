using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShieldColumn : Composite
    {
        public ShieldColumn(GameObject.Name name, Sprite.Name spriteName, SpriteBox.Name spriteboxName, float posX, float posY)
            : base(name, spriteName, spriteboxName)
        {
            this.x = posX;
            this.y = posY;
            this.SetCollisionColor(1.0f, 0.0f, 0.0f);
        }
        ~ShieldColumn()
        {
        }
        public void Resurrect(float posX, float posY)
        {
            this.x = posX;
            this.y = posY;

            this.SetCollisionColor(1.0f, 1.0f, 1.0f);
            base.Resurrect();
            this.SetCollisionColor(1.0f, 1.0f, 1.0f);
        }
        public override void Accept(CollisionVisitor other)
        {
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction            
            other.VisitShieldColumn(this);
        }

        public override void VisitMissile(Missile missile)
        {
            // Missile vs AlienColumn
            GameObject pGameObj = (GameObject)CompositeForwardIterator.GetChild(this);
            CollisionPair.Collide(missile, pGameObj);
        }

        public override void VisitBomb(Bomb b)
        {
            // Missile vs AlienColumn
            GameObject pGameObj = (GameObject)CompositeForwardIterator.GetChild(this);
            CollisionPair.Collide(b, pGameObj);
        }

        public override void Update()
        {
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }

    }
}
