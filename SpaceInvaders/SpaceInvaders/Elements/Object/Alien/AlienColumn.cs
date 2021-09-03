using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class AlienColumn : Composite
    {
        public AlienColumn(GameObject.Name name, Sprite.Name spriteName, SpriteBox.Name spriteboxName, float posX, float posY)
            : base(name, spriteName, spriteboxName)
        {
            this.x = posX;
            this.y = posY;
            this.SetCollisionColor(1.0f, 0.0f, 0.0f);
        }

        public void Resurrect(float posX, float posY)
        {
            this.x = posX;
            this.y = posY;
            this.SetCollisionColor(1.0f, 0.0f, 0.0f);
            base.Resurrect();
            this.SetCollisionColor(1.0f, 1.0f, 1.0f);
        }
        ~AlienColumn()
        {
        }
        public override void Accept(CollisionVisitor other)
        {
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction            
            other.VisitColumn(this);
        }
        public override void VisitMissile(Missile m)
        {
            // Missile vs AlienColumn
            GameObject game_object = (GameObject)CompositeForwardIterator.GetChild(this);
            CollisionPair.Collide(m, game_object);
        }
        

        public override void Update()
        {
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }
    }
}
