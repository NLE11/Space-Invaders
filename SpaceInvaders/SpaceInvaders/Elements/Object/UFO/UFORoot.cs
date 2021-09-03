using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class UFORoot : Composite
    {
        public float UFOSpeedX;
        public float UFOSpeedY;
        public UFORoot(GameObject.Name name, Sprite.Name spriteName, SpriteBox.Name spriteboxName, float posX, float posY)
            : base(name, spriteName, spriteboxName)
        {
            this.x = posX;
            this.y = posY;
            this.UFOSpeedX = 1.0f;
            this.UFOSpeedY = 0.0f;

            this.collison_object.CollisionSpriteBox.SetColor(0, 0, 1);
        }

        ~UFORoot()
        {

        }

        public override void Accept(CollisionVisitor other)
        {
            // Important: at this point we have a UFORoot
            // Call collision reaction            
            other.VisitUFORoot(this);
        }

        public override void VisitMissileGroup(MissileGroup m)
        {
            // MissileGroup vs UFORoot
            GameObject game_object = (GameObject)CompositeForwardIterator.GetChild(m);
            CollisionPair.Collide(game_object, this);
        }

        public override void VisitMissile(Missile m)
        {
            // Missile vs UFORoot
            GameObject game_object = (GameObject)CompositeForwardIterator.GetChild(this);
            CollisionPair.Collide(m, game_object);
        }

        public override void Update()
        {
            // Go to first child
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }
        public void MoveRoot()
        {
            CompositeForwardIterator iterator = new CompositeForwardIterator(this);

            Component node = iterator.First();
            while (!iterator.isDone())
            {
                GameObject game_object = (GameObject)node;
                game_object.x += this.UFOSpeedX;
                game_object.y += this.UFOSpeedY;

                node = iterator.Next();
            }
        }
    }
}
