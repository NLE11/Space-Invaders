using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class AlienCategory : Leaf
    {
        public enum Type
        {
            Red,
            Yellow,
            Green,
            White,

            Squid1, Squid2,
            Crab1, Crab2,
            Crab3, Crab4,
            Octopus1, Octopus2,
            Octopus3, Octopus4,

            AlienColumn,
            AlienGrid,
            AlienRoot,

            Unitialized
        }

        protected AlienCategory(GameObject.Name gameName, Sprite.Name spriteName, float _x, float _y)
            : base(gameName, spriteName, _x, _y)
        {

        }
    }
}
