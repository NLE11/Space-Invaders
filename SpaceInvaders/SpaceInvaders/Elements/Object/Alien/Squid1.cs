using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Squid1 : AlienCategory
    {
        public Squid1(Sprite.Name spriteName, float posX, float posY)
        : base(GameObject.Name.Squid1, spriteName, posX, posY)
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

        public override void Move()
        {
            //this.x += 7.0f;
            //this.y += 0.0f;
        }

        ~Squid1()
        {

        }
        public override void Accept(CollisionVisitor other)
        {
            // Important: at this point we have an RedBird
            // Call the appropriate collision reaction            
            other.VisitSquid1(this);
        }

        public override void VisitMissile(Missile m)
        {
            // MissileGroup vs this m
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
    }
}
