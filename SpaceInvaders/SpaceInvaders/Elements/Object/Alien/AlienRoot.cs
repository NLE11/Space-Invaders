using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class AlienRoot : Composite
    {
        public float alienSpeedX;
        public float alienSpeedY;
        public AlienMoveState moving_state;
       
        public AlienRoot(GameObject.Name name, Sprite.Name spriteName, SpriteBox.Name spriteboxName, float posX, float posY)
            : base(name, spriteName, spriteboxName)
        {
            this.x = posX;
            this.y = posY;
            this.alienSpeedX = 10.0f;
            this.alienSpeedY = 0.0f;
        }
        public void Resurrect(float posX, float posY)
        {
            this.x = posX;
            this.y = posY;
            this.SetCollisionColor(1.0f, 1.0f, 1.0f);
            base.Resurrect();
            this.SetCollisionColor(1.0f, 1.0f, 1.0f);
        }
        ~AlienRoot()
        {
        }
        public override void Accept(CollisionVisitor other)
        {
            // Important: at this point we have an Alien
            // Call the appropriate collision reaction            
            other.VisitRoot(this);
        }
        public override void VisitMissileGroup(MissileGroup m)
        {
            // MissileRoot vs AlienRoot
            GameObject pGameObj = (GameObject)CompositeForwardIterator.GetChild(m);
            CollisionPair.Collide(pGameObj, this);
        }
        public override void VisitMissile(Missile m)
        {
            // Missile vs AlienRoot
            GameObject pGameObj = (GameObject)CompositeForwardIterator.GetChild(this);
            CollisionPair.Collide(m, pGameObj);
        }

        public override void VisitWallGroup(WallGroup w)
        {
            // WallGroup vs AlienRoot
            GameObject pGameObj = (GameObject)CompositeForwardIterator.GetChild(w);
            CollisionPair.Collide(pGameObj, this);
        }

        public override void VisitWallTop(WallTop w)
        {
            // WallTop vs AlienRoot
            Debug.WriteLine("\nCollide: {0} with {1}", w, this);
            Debug.WriteLine("FINISHED!");


            CollisionPair collision_pair = CollisionPairManager.GetActiveColPair();
            Debug.Assert(collision_pair != null);

            collision_pair.SetCollision(w, this);
            collision_pair.NotifyListeners();
        }

        public override void VisitWallMiddle(WallMiddle w)
        {
            // WallMiddle vs AlienRoot
            Debug.WriteLine("\nCollide: {0} with {1}", w, this);
            Debug.WriteLine("FINISHED!");


            CollisionPair collision_pair = CollisionPairManager.GetActiveColPair();
            Debug.Assert(collision_pair != null);

            collision_pair.SetCollision(w, this);
            collision_pair.NotifyListeners();
        }

        public override void VisitBumperRoot(BumperRoot b)
        {
            // WallGroup vs AlienRoot
            GameObject pGameObj = (GameObject)CompositeForwardIterator.GetChild(b);
            CollisionPair.Collide(pGameObj, this);
        }

        public override void VisitBumperLeft(BumperLeft b)
        {
            // WallMiddle vs AlienRoot
            Debug.WriteLine("\nCollide: {0} with {1}", b, this);
            Debug.WriteLine("FINISHED!");


            CollisionPair collision_pair = CollisionPairManager.GetActiveColPair();
            Debug.Assert(collision_pair != null);

            collision_pair.SetCollision(b, this);
            collision_pair.NotifyListeners();
        }

        public override void VisitBumperRight(BumperRight b)
        {
            // WallMiddle vs AlienRoot
            Debug.WriteLine("\nCollide: {0} with {1}", b, this);
            Debug.WriteLine("FINISHED!");


            CollisionPair collision_pair = CollisionPairManager.GetActiveColPair();
            Debug.Assert(collision_pair != null);

            collision_pair.SetCollision(b, this);
            collision_pair.NotifyListeners();
        }

        public override void VisitShieldRoot(ShieldRoot s)
        {
            // WallMiddle vs AlienRoot
            Debug.WriteLine("\nCollide: {0} with {1}", s, this);
            Debug.WriteLine("FINISHED!");


            CollisionPair collision_pair = CollisionPairManager.GetActiveColPair();
            Debug.Assert(collision_pair != null);

            collision_pair.SetCollision(s, this);
            collision_pair.NotifyListeners();
        }

        public override void Update()
        {
            // Go to first child
            base.BaseUpdateBoundingBox(this);
            base.Update();

        }

        public void SetMoveState(AlienManager.MoveState inState)
        {
            this.moving_state = AlienManager.GetMoveState(inState);
        }

        public void SetDelta(float delta, float alpha)
        {
            this.alienSpeedX = delta;
            this.alienSpeedY = alpha;
        }

        public void MoveRoot()
        {
            CompositeForwardIterator iterator = new CompositeForwardIterator(this);

            Component node = iterator.First();
            while (!iterator.isDone())
            {
                GameObject game_object = (GameObject)node;
                game_object.x += this.alienSpeedX;
                game_object.y += this.alienSpeedY;

                node = iterator.Next();
            }
        }
    }
}


