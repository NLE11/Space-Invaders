using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class CollisionSubject
    {
        // Data: ------------------------
        public GameObject Object_A;
        public GameObject Object_B;

        private SLinkMAN SLinkManager;
        public CollisionSubject()
        {
            this.Object_A = null;
            this.Object_B = null;

            this.SLinkManager = new SLinkMAN();
            Debug.Assert(this.SLinkManager != null);
        }

        ~CollisionSubject()
        {
            this.Object_A = null;
            this.Object_B = null;
        }

        public void Attach(CollisionObserver Observer)
        {
            // protection
            Debug.Assert(Observer != null);

            Observer.Subject = this;

            // Attach it to the Animation Sprite ( Push to front )
            this.SLinkManager.AddFrontNode(Observer);
        }

        public void Notify()
        {
            Iterator iterator = this.SLinkManager.GetIterator();

            CollisionObserver Observer = (CollisionObserver)iterator.Current();

            // Check the list of grid and sound observers and make them notify
            while (!iterator.isDone())
            {
                // Fire off listener
                Observer.Notify();

                Observer = (CollisionObserver)iterator.Next();
            }
        }

        public void Detach()
        {
        }
    }
}
