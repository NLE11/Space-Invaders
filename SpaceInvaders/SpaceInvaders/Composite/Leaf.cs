﻿using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class Leaf : GameObject
    {
        public Leaf(GameObject.Name gameName, Sprite.Name spriteName, float x, float y)
            : base(Component.Container.LEAF, gameName, spriteName, x, y)
        {
        }

        override public void Resurrect()
        {
            base.Resurrect();
        }

        override public void Print()
        {
            this.Dump();
        }

        override public void Add(Component component)
        {
            Debug.Assert(false);
        }
        override public void Remove(Component c)
        {
            Debug.Assert(false);
        }
        override public void DumpNode()
        {
            Debug.WriteLine(" GameObject Name: {0} ({1}) parent:{2}", this.GetName(), this.GetHashCode(), CompositeForwardIterator.GetParent(this).GetHashCode());
        }

        public override void Wash()
        {
            // shouldn't be called
            Debug.Assert(false);
        }

    }
}
