using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class CollisionPairManager : ManagerBase
    {
        // Data
        private readonly CollisionPair NodeToCompare = new CollisionPair();
        private static CollisionPairManager Instance = null;
        private static CollisionPairManager ActiveColMan = null;
        private CollisionPair ActiveCollisionPair = new CollisionPair();

        // Constructor

        public CollisionPairManager(int reserveNum = 3, int reserveGrow = 1)
                : base(new DLinkMAN(), new DLinkMAN(), reserveNum, reserveGrow)   // <--- Kick the can (delegate)
        {
            CollisionPairManager.ActiveColMan = null;
        }

        public static void Create(int reserveNum = 3, int reserveGrow = 1)
        {
            // initialize the singleton here
            Debug.Assert(Instance == null);

            // Do the initialization
            if (Instance == null)
            {
                Instance = new CollisionPairManager();
            }
        }

        public static void Destroy()
        {
            CollisionPairManager manager = CollisionPairManager.ActiveColMan;
            Debug.Assert(manager != null);

            manager.baseDumpNodes();
            Instance = null;
            manager = null;
        }

        public static void SetActive(CollisionPairManager ColPairMan)
        {
            CollisionPairManager manager = CollisionPairManager.GetInstance();
            Debug.Assert(manager != null);

            Debug.Assert(ColPairMan != null);
            CollisionPairManager.ActiveColMan = ColPairMan;
        }

        public static CollisionPair Add(CollisionPair.Name colpairName, GameObject treeRootA, GameObject treeRootB)
        {
            // Get the instance
            CollisionPairManager manager = CollisionPairManager.ActiveColMan;
            Debug.Assert(manager != null);

            // Go to Man, get a node from reserve, add to active, return it
            CollisionPair pColPair = (CollisionPair)manager.baseAddToFront();
            Debug.Assert(pColPair != null);

            // Initialize Image
            pColPair.Set(colpairName, treeRootA, treeRootB);

            return pColPair;
        }

        public static void Process()
        {
            // get the singleton
            CollisionPairManager manager = CollisionPairManager.ActiveColMan;

            // walk through the list and render
            Iterator iterator = manager.baseGetIterator();
            Debug.Assert(iterator != null);

            CollisionPair current_node = (CollisionPair)iterator.First();
            bool check;
            if (current_node != null)
            {
                // Walk through the nodes
                while (!iterator.isDone())
                {
                    // set the current active  <--- Key concept: set this before
                    manager.ActiveCollisionPair = current_node;

                    // Update the node
                    Debug.Assert(current_node != null);
                    
                    current_node.Process();
                    if (SpaceInvaders.Intro2 == true) check = true;

                    current_node = (CollisionPair)iterator.Next();
                }
            }

        }

        static public CollisionPair GetActiveColPair()
        {
            // get the singleton
            CollisionPairManager manager = CollisionPairManager.ActiveColMan;

            return manager.ActiveCollisionPair;
        }

        public static CollisionPair Find(CollisionPair.Name name)
        {
            CollisionPairManager manager = CollisionPairManager.ActiveColMan;
            Debug.Assert(manager != null);

            manager.NodeToCompare.name = name;

            CollisionPair data_pair = (CollisionPair)manager.baseFind(manager.NodeToCompare);
            return data_pair;
        }

        public static void Remove(CollisionPair current_node)
        {
            Debug.Assert(current_node != null);

            CollisionPairManager manager = CollisionPairManager.ActiveColMan;
            Debug.Assert(manager != null);

            manager.baseRemoveNode(current_node);
        }
        public static void Dump()
        {
            CollisionPairManager pMan = CollisionPairManager.ActiveColMan;
            Debug.Assert(pMan != null);

            pMan.baseDumpNodes();
        }

        private static CollisionPairManager GetInstance()
        {
            Debug.Assert(Instance != null);

            return Instance;
        }

        override protected NodeBase derivedCreateNode()
        {
            NodeBase node_base = new CollisionPair();
            Debug.Assert(node_base != null);

            return node_base;
        }
    }
}
