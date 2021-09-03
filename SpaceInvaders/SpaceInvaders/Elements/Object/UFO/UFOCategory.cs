using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class UFOCategory : Leaf
    {
        public enum Type
        {
            UFO,
            UFORoot,
            Unitialized
        }

        protected UFOCategory(GameObject.Name name, Sprite.Name spriteName, float positionX, float positionY)
            : base(name, spriteName, positionX, positionY)
        {

        }

        // Data: ---------------
        ~UFOCategory()
        {
        }
    }
}