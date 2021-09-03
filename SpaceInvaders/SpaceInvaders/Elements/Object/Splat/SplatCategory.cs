using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class SplatCategory : Leaf
    {
        public enum Type
        {
            Splat,
            SplatRoot,
            Unitialized
        }

        protected SplatCategory(GameObject.Name name, Sprite.Name spriteName, float positionX, float positionY)
            : base(name, spriteName, positionX, positionY)
        {

        }

        // Data: ---------------
        ~SplatCategory()
        {
        }
    }
}