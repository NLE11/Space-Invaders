using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SLinkIterator : Iterator
    {
        public NodeBase Head;
        public NodeBase current_node;
        public bool Done;
        public SLinkIterator()
        {
            this.Clear();
        }
        private void Clear()
        {
            this.current_node = null;
            this.Head = null;
            this.Done = true;
        }
        override public NodeBase Next()
        {
            SLink sLink = (SLink)this.current_node;

            if (sLink != null)
            {
                sLink = sLink.Next;
            }

            this.current_node = sLink;

            if (sLink == null)
            {
                Done = true;
            }
            else
            {
                Done = false;
            }

            return sLink;
        }
        override public bool isDone()
        {
            return Done;
        }
        override public NodeBase First()
        {
            // this should give the first node
            // essentially reset the list
            if (this.Head != null)
            {
                this.Done = false;
                this.current_node = this.Head;
            }
            else
            {
                this.Clear();
            }

            return current_node;
        }
        override public NodeBase Current()
        {
            NodeBase Node = this.current_node;
            return Node;
        }
        public void Reset(SLink Head)
        {
            if (Head != null)
            {
                this.Done = false;
                this.current_node = Head;
                this.Head = Head;
            }
            else
            {
                this.Clear();
            }
        }
    }
}
