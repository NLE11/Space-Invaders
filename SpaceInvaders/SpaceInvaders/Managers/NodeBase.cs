using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class NodeBase
    {
        abstract public void Wash();
        abstract public void Dump();
        virtual public object GetName()
        {
            return null;
        }
        virtual public bool Compare(NodeBase NodeToFind)
        {
            Debug.Assert(false);
            return false;
        }
    }
}
