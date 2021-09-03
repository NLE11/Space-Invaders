using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class BombCategory : Leaf
    {
        // Data
        protected BombCategory.Type BombType;

        public enum Type
        {
            Bomb,
            BombRoot,
            Unitialized
        }

        protected BombCategory(GameObject.Name name, Sprite.Name spriteName, float posX, float posY, BombCategory.Type bomb_type)
            : base(name, spriteName, posX, posY)
        {
            this.BombType = bomb_type;
        }

        // Data: ---------------
        ~BombCategory()
        {
        }
    }
}
