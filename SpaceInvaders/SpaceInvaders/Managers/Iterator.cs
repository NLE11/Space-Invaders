using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class Iterator
    {
        abstract public NodeBase Next();
        abstract public NodeBase First();
        abstract public bool isDone();
        abstract public NodeBase Current();
    }
}
