using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class CollisionObserver : SLink
    {
        // This observer holds a collision subject 
        public CollisionSubject Subject;
        public abstract void Notify();
        override public void Wash()
        {
            Debug.Assert(false);
        }
        public virtual void Execute()
        {
            // Do something here
        }
    }
}
