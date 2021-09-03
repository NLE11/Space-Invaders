using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SplatRoot : Composite
    {
        public SplatRoot(GameObject.Name name, Sprite.Name spriteName, SpriteBox.Name spriteboxName, float posX, float posY)
            : base(name, spriteName, spriteboxName)
        {
            this.x = posX;
            this.y = posY;

            this.collison_object.CollisionSpriteBox.SetColor(0, 0, 1);
        }

        ~SplatRoot()
        {

        }

        public override void Accept(CollisionVisitor other)
        {

        }

        public override void Update()
        {
            // Go to first child
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }
        public void SetPos(float x, float y)
        {
            CompositeForwardIterator iterator = new CompositeForwardIterator(this);

            Component node = iterator.First();
            while (!iterator.isDone())
            {
                GameObject game_object = (GameObject)node;
                game_object.x = x;
                game_object.y = y;

                node = iterator.Next();
            }
        }


    }
}
