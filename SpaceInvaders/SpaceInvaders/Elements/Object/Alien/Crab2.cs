using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Crab2 : AlienCategory
    {
        public Crab2(Sprite.Name spriteName, float posX, float posY)
        : base(GameObject.Name.Crab2, spriteName, posX, posY)
        {
            this.x = posX;
            this.y = posY;

            this.SetCollisionColor(1.0f, 1.0f, 1.0f);
        }
        public void Resurrect(float posX, float posY)
        {
            this.x = posX;
            this.y = posY;

            this.SetCollisionColor(1.0f, 1.0f, 1.0f);
            base.Resurrect();
        }
        ~Crab2()
        {

        }
        public override void Accept(CollisionVisitor other)
        {
            // Important: at this point we have an RedBird
            // Call the appropriate collision reaction            
            other.VisitCrab2(this);
        }

        public override void VisitMissile(Missile m)
        {
            // MissileGroup vs this leaf
            Debug.WriteLine("\nCollide: {0} with {1}", m, this);
            Debug.WriteLine("FINISHED!");

            CollisionPair collision_pair = CollisionPairManager.GetActiveColPair();
            Debug.Assert(collision_pair != null);

            collision_pair.SetCollision(m, this);
            collision_pair.NotifyListeners();
        }

        public override void Update()
        {
            // Debug.WriteLine("update: {0}", this);
            base.Update();
        }

        public override void Move()
        {
            //this.x += 7.0f;
            //this.y += 0.0f;
        }
    }
}
