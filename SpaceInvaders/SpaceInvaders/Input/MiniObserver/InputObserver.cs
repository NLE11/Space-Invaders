using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract class InputObserver : SLink
    {
        // define this in concrete
        abstract public void Notify();

        override public void Wash()
        {
            Debug.Assert(false);
        }

        public InputSubject Subject;
    }
}