using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class BumperCategory : Leaf
    {
        // Data
        protected BumperCategory.Type BumperType;
        public enum Type
        {
            Right,
            Left,

            Unitialized
        }

        protected BumperCategory(GameObject.Name gameName, Sprite.Name spriteName, float x, float y, BumperCategory.Type bumperType)
        : base(gameName, spriteName, x, y)
        {
            BumperType = bumperType;
        }

        ~BumperCategory()
        {
        }

        public BumperCategory.Type GetCategoryType()
        {
            return this.BumperType;
        }
    }
}