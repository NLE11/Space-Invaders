using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class ShieldCategory : Leaf
    {
        protected ShieldCategory.Type ShieldType;

        public enum Type
        {
            ShieldRoot,
            ShieldColumn,
            Brick,

            LeftTop0,
            LeftTop1,
            LeftBottom,
            RightTop0,
            RightTop1,
            RightBottom,

            Unitialized
        }

        protected ShieldCategory(GameObject.Name name, Sprite.Name spriteName, float posX, float posY, ShieldCategory.Type shieldType)
            : base(name, spriteName, posX, posY)
        {
            this.ShieldType = shieldType;
        }
        // Data: ---------------
        ~ShieldCategory()
        {
        }
        public ShieldCategory.Type GetCategoryType()
        {
            return this.ShieldType;
        }

    }
}

