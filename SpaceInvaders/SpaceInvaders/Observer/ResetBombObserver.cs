using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ResetBombObserver : CollisionObserver
    {
        int random_column;
        public override void Notify()
        {
            // Instantiate random number generator.  
            System.Random random = new System.Random();
            random_column = random.Next(0, 10);
            Debug.WriteLine("Number: {0}", random_column);

            AlienColumn alien_column = (AlienColumn)GameObjectNodeManager.Find(GameObject.Name.AlienColumn_0 + random_column);
            

            Bomb bomb = (Bomb)this.Subject.Object_B;
            Debug.Assert(bomb != null);

            bomb.Reset(alien_column.x, alien_column.y - 150);
        }
    }
}
