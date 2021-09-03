using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class WallCategory : Leaf
    {
        protected WallCategory.Type wall_type;
        public enum Type
        {
            WallGroup,
            Right,
            Left,
            Bottom, 
            Middle,
            Top,

            Unitialized
        }

        protected WallCategory(GameObject.Name gameName, Sprite.Name spriteName, float _x, float _y, WallCategory.Type type)
        : base(gameName, spriteName, _x, _y)
        {
            wall_type = type;
        }

        ~WallCategory()
        {
        }
        public WallCategory.Type GetCategoryType()
        {
            return this.wall_type;
        }
    }
}
