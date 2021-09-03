using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class MessageObserver : CollisionObserver
    {
        public MessageObserver()
        {

        }
        public override void Notify()
        {
            //Debug.WriteLine("*** Missile Observer: {0} <-> {1}", this.Subject.Object_A.name, this.Subject.Object_B.name);

            ////AlienGrid grid = (AlienGrid)this.Subject.Object_A;
            //MissileGroup missile_group = (MissileGroup)this.Subject.Object_A;

            //FontManager.Add(Font.Name.TestMessage, SpriteBatch.Name.Texts, "BOOM!", Glyph.Name.Consolas36pt, 470, 250);
            ////FontManager.Dump();
            //CollisionPair collision_pair2 = CollisionPairManager.Find(CollisionPair.Name.Missile);
            //CollisionPairManager.Remove(collision_pair2);
        }
    }
}