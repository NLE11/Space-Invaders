using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class ShipCategory : Leaf
    {
        protected ShipCategory.Type ShipType;
        public enum Type
        {
            Ship,
            ShipRoot,
            Unitialized
        }

        protected ShipCategory(GameObject.Name name, Sprite.Name spriteName, float positionX, float positionY, ShipCategory.Type shipType)
            : base(name, spriteName, positionX, positionY)
        {
            this.ShipType = shipType;
        }

        // Data: ---------------
        ~ShipCategory()
        {
        }
    }
}