using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShipMiniRoot : Composite
    {
        public ShipMiniRoot(GameObject.Name name, Sprite.Name spriteName, SpriteBox.Name spriteboxName, float posX, float posY)
            : base(name, spriteName, spriteboxName)
        {
            this.x = posX;
            this.y = posY;

            this.collison_object.CollisionSpriteBox.SetColor(0, 0, 1);
        }

        ~ShipMiniRoot()
        {
        }

        public override void Accept(CollisionVisitor other)
        {

        }

        public override void Update()
        {
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }

    }
}
