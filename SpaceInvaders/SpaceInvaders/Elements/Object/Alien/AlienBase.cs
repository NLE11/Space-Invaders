using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract class AlienBase : Leaf
    {
        public enum Type
        {
            Squid,
            Crab1, Crab2,
            Crab3, Crab4,
            Octopus1, Octopus2,
            Octopus3, Octopus4,
        }

        protected AlienBase(GameObject.Name gameName, Sprite.Name spriteName, float x, float y)
            : base(gameName, spriteName, x, y)
        {

        }
    }
}
