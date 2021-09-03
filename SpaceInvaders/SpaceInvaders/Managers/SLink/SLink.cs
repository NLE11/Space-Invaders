using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class SLink : NodeBase
    { 
        public SLink Next;
        public float id;

        protected SLink()
        {
            this.Clear();
        }
        public void Clear()
        {
            this.Next = null;
            this.id = 0;
        }

        override public void Dump()
        {
            if (this.Next == null)
            {
                Debug.WriteLine("Node next is null.");
            }
            else
            {
                NodeBase Temp = (NodeBase)this.Next;
                Debug.WriteLine("Node next is: {0} ({1})", Temp.GetName(), Temp.GetHashCode());
            }
        }
    }
}
