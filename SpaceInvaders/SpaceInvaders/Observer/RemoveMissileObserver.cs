using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class RemoveMissileObserver : CollisionObserver
    {
        private GameObject Missile;
        public RemoveMissileObserver()
        {
            this.Missile = null;
        }
        public RemoveMissileObserver(RemoveMissileObserver missile_observer)
        {
            this.Missile = missile_observer.Missile;
        }
        public override void Notify()
        {
            // Delete missile
            //Debug.WriteLine("RemoveMissileObserver: {0} {1}", this.pSubject.pObjA, this.pSubject.pObjB);

            this.Missile = (Missile)this.Subject.Object_A;
            Debug.Assert(this.Missile != null);

            if (Missile.MarkForDeath == false)
            {
                Missile.MarkForDeath = true;
                //   Delay
                RemoveMissileObserver observer = new RemoveMissileObserver(this);
                DelayedObjectManager.Attach(observer);
            }
        }
        public override void Execute()
        {
            // Let the gameObject deal with this... 
            this.Missile.Remove();
        }
    }
}
