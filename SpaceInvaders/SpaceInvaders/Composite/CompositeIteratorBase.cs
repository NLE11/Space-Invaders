using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class CompositeIteratorBase
    {
        abstract public Component Next();
        abstract public bool isDone();
        abstract public Component First();
        abstract public Component Current();
    }

}
