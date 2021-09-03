using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class RemoveShieldObserver : CollisionObserver
    {
        private GameObject Shield;
        public RemoveShieldObserver()
        {
            this.Shield = null;
        }
        public RemoveShieldObserver(RemoveShieldObserver observer)
        {
            this.Shield = observer.Shield;
        }
        public override void Notify()
        {
            // Delete missile
            //Debug.WriteLine("RemoveMissileObserver: {0} {1}", this.pSubject.pObjA, this.pSubject.pObjB);

            this.Shield = (Leaf)this.Subject.Object_A;

            Debug.Assert(this.Shield != null);

            if (Shield.MarkForDeath == false)
            {
                Shield.MarkForDeath = true;
                //   Delay
                RemoveShieldObserver observer = new RemoveShieldObserver(this);
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
