using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class ListBase
    {
        abstract public void AddFrontNode(NodeBase node);
        abstract public void AddEndNode(NodeBase node);
        abstract public void AddNodeToIndex(NodeBase node, float id);
        abstract public NodeBase DeleteFrontNode();
        abstract public void DeleteNode(NodeBase node);
        abstract public Iterator GetIterator();
    }
}
