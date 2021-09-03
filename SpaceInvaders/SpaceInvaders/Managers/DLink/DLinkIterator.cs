using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class DLinkIterator : Iterator
    {
        public NodeBase current_node;
        public bool done;
        public DLinkIterator()
        {
            this.current_node = null;
            this.done = true;
        }

        public override NodeBase Current()
        {
            NodeBase Node = this.current_node;
            return Node;
        }

        public override NodeBase First()
        {
            NodeBase node = this.current_node;
            return node;
        }

        public override bool isDone()
        {
            return done;
        }

        public override NodeBase Next()
        {
            DLink link = (DLink)this.current_node;

            if (link != null) //if this node is not null, move next
            {
                link = link.Next;
            }

            this.current_node = link; //Set current_node to next node

            if (link == null)
            {
                done = true; //This is the end of the list
            }
            else
            {
                done = false;
            }

            return link;
        }

        public void Reset(DLink head)
        {
            if(head != null)
            {
                this.done = false;
                this.current_node = head;
            }
            else
            {
                this.done = true;
                this.current_node = null;
            }
        }
    }
}
