using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ResetBombUFOObserver : CollisionObserver
    {
        public override void Notify()
        {
            // Instantiate random number generator.  
            GameObject UFORoot = GameObjectNodeManager.Find(GameObject.Name.UFORoot);


            Bomb bomb = (Bomb)this.Subject.Object_B;
            Debug.Assert(bomb != null);

            bomb.Reset(UFORoot.x, UFORoot.y-20);
        }
    }
}
