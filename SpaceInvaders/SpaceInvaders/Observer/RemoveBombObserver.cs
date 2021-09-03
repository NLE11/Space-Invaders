using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class RemoveBombUFOObserver : CollisionObserver
    {
        public override void Notify()
        {

            SplatRoot splat_root = (SplatRoot)GameObjectNodeManager.Find(GameObject.Name.SplatRoot);
            splat_root.SetPos(this.Subject.Object_B.x, this.Subject.Object_B.y);
        }
    }
}
