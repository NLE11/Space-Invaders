using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class RemoveShieldMIssileObserver : CollisionObserver
    {
        private GameObject Shield;
        public RemoveShieldMIssileObserver()
        {
            this.Shield = null;
        }
        public RemoveShieldMIssileObserver(RemoveShieldMIssileObserver observer)
        {
            this.Shield = observer.Shield;
        }
        public override void Notify()
        {
            // Delete missile
            //Debug.WriteLine("RemoveShieldMIssileObserver: {0} {1}", this.pSubject.pObjA, this.pSubject.pObjB);

            this.Shield = (Leaf)this.Subject.Object_B;

            Debug.Assert(this.Shield != null);

            if (Shield.MarkForDeath == false)
            {
                Shield.MarkForDeath = true;
                //   Delay
                RemoveShieldMIssileObserver observer = new RemoveShieldMIssileObserver(this);
                DelayedObjectManager.Attach(observer);
            }
        }
        public override void Execute()
        {
            // Let the gameObject deal with this... 

            this.Shield.Remove();

            GameObject parent = (GameObject)CompositeForwardIterator.GetParent(this.Shield);
            if ((GameObject)CompositeForwardIterator.GetChild(parent) == null)
            {
                parent.Remove();
            }

        }
    }
}
