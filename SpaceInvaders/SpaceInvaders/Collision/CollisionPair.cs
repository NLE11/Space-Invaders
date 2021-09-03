using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class CollisionPair : DLink
    {
        // Data
        public CollisionPair.Name name;
        public GameObject TreeA;
        public GameObject TreeB;
        public CollisionSubject Subject;
        public enum Name
        {
            Missile_Shield,
            Missile_WallTop,
            Missile_Alien,
            Missile_UFO,
            Bumper_Ship,
            Wall_Alien,
            Bumper_Alien,
            Bomb_Wall,
            Bomb_Ship,
            Bomb_Missile,
            Bomb_Shield,
            UFO_Bumper,


            NullObject,
            Not_Initialized
        }

        public CollisionPair()
            : base()
        {
            this.TreeA = null;
            this.TreeB = null;
            this.name = CollisionPair.Name.Not_Initialized;

            // The subject now holds 2 game objects and 1 SLinkMAN
            this.Subject = new CollisionSubject();
            Debug.Assert(this.Subject != null);
        }

        ~CollisionPair()
        {

        }

        public void Set(CollisionPair.Name name, GameObject TreeRootA, GameObject TreeRootB)
        {
            Debug.Assert(TreeRootA != null);
            Debug.Assert(TreeRootB != null);

            this.TreeA = TreeRootA;
            this.TreeB = TreeRootB;
            this.name = name;
        }

        private void Clear()
        {
            this.TreeA = null;
            this.TreeB = null;
            this.name = CollisionPair.Name.Not_Initialized;
        }

        public void Process()
        {
            Collide(this.TreeA, this.TreeB);
        }

        static public void Collide(GameObject SafeTreeA, GameObject SafeTreeB)
        {
            // A collides B
            GameObject NodeA = SafeTreeA;
            GameObject NodeB = SafeTreeB;

            while (NodeA != null)
            {
                // Restart compare
                NodeB = SafeTreeB;

                while (NodeB != null)
                {
                    // Which 2 game objects colliding that we are testing?
                    //Debug.WriteLine("CollisionPair is testing:  {0} and {1} colliding?", NodeA.name, NodeB.name);

                    // Get rectangles
                    CollisionRect rectangleA = NodeA.GetCollisionObject().collision_rect;
                    CollisionRect rectangleB = NodeB.GetCollisionObject().collision_rect;

                    // Check if they intersect then accept
                    if (CollisionRect.Intersect(rectangleA, rectangleB))
                    {
                        // Boom - it works (Visitor in Action)
                        NodeA.Accept(NodeB);
                        break;
                    }
                    // Continue to test collision with every node in B
                    NodeB = (GameObject)CompositeForwardIterator.GetSibling(NodeB);
                }
                // Continue to test collision with every node in B
                NodeA = (GameObject)CompositeForwardIterator.GetSibling(NodeA);
            }
        }

        public void Attach(CollisionObserver observer)
        {
            this.Subject.Attach(observer);
        }
        public void NotifyListeners()
        {
            this.Subject.Notify(); // Notify Grid or Sound
        }
        public void SetCollision(GameObject ObjectA, GameObject ObjectB)
        {
            Debug.Assert(ObjectA != null);
            Debug.Assert(ObjectA != null);

            this.Subject.Object_A = ObjectA;
            this.Subject.Object_B = ObjectB;
        }

        //---------------------------------------------------------------------------------------------------------
        // Override
        //---------------------------------------------------------------------------------------------------------

        public override object GetName()
        {
            return this.name;
        }

        override public void Wash()
        {
            this.Clear();
        }

        override public bool Compare(NodeBase target_node)
        {
            
            Debug.Assert(target_node != null);

            CollisionPair node = (CollisionPair)target_node;

            bool status = false;

            if (this.name == node.name)
            {
                status = true;
            }
            return status;
        }

        override public void Dump()
        {
            // we are using HASH code as its unique identifier 
            Debug.WriteLine("This Collision Pair is:    {0} ({1})", this.name, this.GetHashCode());

            // Data:
            Debug.WriteLine("Tree A is: {0} - Tree B is: {1}", this.TreeA.name, this.TreeB.name);
            Debug.WriteLine("Collision Subject has: {0} vs {1}", this.Subject.Object_A.name, this.Subject.Object_B.name);
            
            base.Dump();
        }
    }
}
