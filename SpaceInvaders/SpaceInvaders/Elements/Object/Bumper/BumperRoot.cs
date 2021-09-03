using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class BumperRoot : Composite
    {
        public BumperRoot(GameObject.Name name, Sprite.Name spriteName, SpriteBox.Name spriteboxName, float posX, float posY)
            : base(name, spriteName, spriteboxName)
        {
            this.x = posX;
            this.y = posY;

            this.collison_object.CollisionSpriteBox.SetColor(1, 1, 0);

            this.name = name;
        }
        ~BumperRoot()
        {

        }
        public override void Accept(CollisionVisitor other)
        {
            // A ship may visit this root          
            other.VisitBumperRoot(this);
        }

        public override void VisitUFORoot(UFORoot u)
        {
            // UFORoot vs Bumper
            GameObject game_object = (GameObject)CompositeForwardIterator.GetChild(this);
            CollisionPair.Collide(u, game_object);
        }

        public override void VisitUFO(UFO u)
        {
            // MissileRoot vs AlienRoot
            GameObject game_object = (GameObject)CompositeForwardIterator.GetChild(this);
            CollisionPair.Collide(u, game_object);
        }


        public override void Update()
        {
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }
    }
}