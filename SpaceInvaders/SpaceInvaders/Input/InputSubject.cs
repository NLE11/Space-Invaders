using System;
using System.Diagnostics;


namespace SpaceInvaders
{
    class InputSubject
    {
        // Data: ------------------------
        private SLinkMAN SLinkManager;

        public InputSubject()
        {
            this.SLinkManager = new SLinkMAN();
            Debug.Assert(this.SLinkManager != null);
        }

        public void Attach(InputObserver input_observer)
        {
            // protection
            Debug.Assert(input_observer != null);

            input_observer.Subject = this;

            // Attach it to the Animation Sprite ( Push to front )
            this.SLinkManager.AddFrontNode(input_observer);
        }


        public void Notify()
        {
            Iterator iterator = this.SLinkManager.GetIterator();

            InputObserver input_observer = (InputObserver)iterator.Current();

            while (!iterator.isDone())
            {
                // Notify all listeners
                input_observer.Notify();

                input_observer = (InputObserver)iterator.Next();
            }

        }

        public void Detach()
        {
        }
    }
}