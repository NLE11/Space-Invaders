using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class DLink : NodeBase
    {
        public DLink Next;
        public DLink Prev;
        public float id;

        protected DLink() //clear when create new DLink
        {
            this.Clear();
        }

        public void Clear()
        {
            this.Next = null;
            this.Prev = null;
            this.id = 0;
        }

        override public void Dump()
        {
            if (this.Prev == null)
            {
                Debug.WriteLine("Previous Node is null!");
            }    
            else
            {
                NodeBase temp = (NodeBase)this.Prev;
                Debug.WriteLine("Previous Node: {0} {1}", temp.GetName(), temp.GetHashCode());
            }
            
            if (this.Next == null)
            {
                Debug.WriteLine("Next Node is null!");
            }
            else
            {
                NodeBase temp = (NodeBase)this.Next;
                Debug.WriteLine("Next Node is {0} {1}", temp.GetName(), temp.GetHashCode());
            }
        }
    }
}
