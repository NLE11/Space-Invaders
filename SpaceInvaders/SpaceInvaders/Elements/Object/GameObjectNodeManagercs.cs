using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class GameObjectNodeManager : ManagerBase
    {
        // Data 
        private readonly GameObjectNode Node_To_Compare = new GameObjectNode();
        private readonly GameObjectNull GameObject = new GameObjectNull();
        private static GameObjectNodeManager Instance = null;
        private static GameObjectNodeManager ActiveGONManager = null;

        // Constructor
        public GameObjectNodeManager(int reserveNum = 3, int reserveGrow = 1)
                : base(new DLinkMAN(), new DLinkMAN(), reserveNum, reserveGrow)   
        {
            // initialize derived data here
            //LTN - Constructor
            this.Node_To_Compare.GameObject = this.GameObject;
            GameObjectNodeManager.ActiveGONManager = null;
            
        }

        public static void Create(int reserveNum = 3, int reserveGrow = 1)
        {
            // initialize the singleton here
            Debug.Assert(Instance == null);

            // Do the initialization
            if (Instance == null)
            {
                //LTN - This instance manager is created to control game object nodes added to or removed from the lists
                Instance = new GameObjectNodeManager();
            }
        }
        public static void Destroy()
        {
            GameObjectNodeManager manager = GameObjectNodeManager.ActiveGONManager;
            Debug.Assert(manager != null);

            manager.baseDumpNodes();
            Instance = null;
            manager = null;
        }

        public static GameObjectNodeManager GetInstance()
        {
            Debug.Assert(Instance != null);
            return Instance;
        }

        public static void SetActive(GameObjectNodeManager GONMAn)
        {
            GameObjectNodeManager manager = GameObjectNodeManager.GetInstance();
            Debug.Assert(manager != null);

            Debug.Assert(GONMAn != null);
            GameObjectNodeManager.ActiveGONManager = GONMAn;
        }

        public static GameObjectNode Attach(GameObject GameObject)
        {
            GameObjectNodeManager manager = GameObjectNodeManager.ActiveGONManager;
            Debug.Assert(manager != null);

            GameObjectNode node = (GameObjectNode)manager.baseAddToFront();
            Debug.Assert(node != null);

            node.Set(GameObject);
            return node;
        }

        public static GameObject Find(GameObject.Name name)
        {
            GameObjectNodeManager manager = GameObjectNodeManager.ActiveGONManager;
            Debug.Assert(manager != null);

            // Compare functions only compares two Nodes

            // So:  Use the Compare Node - as a reference
            //      use in the Compare() function
            Debug.Assert(manager.Node_To_Compare.GameObject != null);

            manager.Node_To_Compare.GameObject.name = name;

            GameObjectNode node = (GameObjectNode)manager.baseFind(manager.Node_To_Compare);
            Debug.Assert(node != null);

            return node.GameObject;
        }

        public static void Update()
        {
            GameObjectNodeManager manager = GameObjectNodeManager.ActiveGONManager;
            Debug.Assert(manager != null);

            // Debug.WriteLine("---------------");

            Iterator iterator = manager.baseGetIterator();
            GameObjectNode game_node = (GameObjectNode)iterator.First();

            while (!iterator.isDone())
            {
                CompositeReverseIterator reverse_iterator = new CompositeReverseIterator(game_node.GameObject);

                Component current_node = reverse_iterator.First();
                while (!reverse_iterator.isDone())
                {
                    GameObject game_object = (GameObject)current_node;

                    //Debug.WriteLine("update: {0} ({1})", pGameObj, pGameObj.GetHashCode());
                    game_object.Update();

                    current_node = reverse_iterator.Next();
                }

                game_node = (GameObjectNode)iterator.Next();
            }
        }

        public static void Remove(GameObjectNode current_node)
        {
            Debug.Assert(current_node != null);

            GameObjectNodeManager manager = GameObjectNodeManager.ActiveGONManager;
            Debug.Assert(manager != null);

            manager.baseRemoveNode(current_node);
        }

        public static void Remove(GameObject node)
        {
            // Keenan(delete.E)
            Debug.Assert(node != null);
            GameObjectNodeManager manager = GameObjectNodeManager.ActiveGONManager;

            GameObject safe_node = node;

            // OK so we have a linked list of trees (Remember that)

            // 1) find the tree root (we already know its the most parent)

            GameObject temp = node;
            GameObject root = null;
            while (temp != null)
            {
                root = temp;
                temp = (GameObject)CompositeForwardIterator.GetParent(temp);
            }

            // 2) pRoot is the tree we are looking for
            // now walk the active list looking for pRoot

            Iterator iterator = manager.baseGetIterator();
            GameObjectNode tree = (GameObjectNode)iterator.First();

            while (!iterator.isDone())
            {
                if (tree.GameObject == root)
                {
                    // found it
                    break;
                }
                tree = (GameObjectNode)iterator.Next();
            }

            // 3) pTree is the tree that holds pNode
            //  Now remove the node from that tree

            Debug.Assert(tree != null);
            Debug.Assert(tree.GameObject != null);

            // Is pTree.poGameObj same as the node we are trying to delete?
            // Answer: should be no... since we always have a group (that was a good idea)

            //Debug.Assert(tree.GameObject != node);

            GameObject Parent = (GameObject)CompositeForwardIterator.GetParent(node);
            //Debug.Assert(Parent != null);

            // Make sure there is no child before the delete
            GameObject Child = (GameObject)CompositeForwardIterator.GetChild(node);
            Debug.Assert(Child == null);

            // remove the node
            Parent.Remove(node);

            // FOUND the bug!!!!
            Parent.Update();

        }
        public static void Dump()
        {
            GameObjectNodeManager manager = GameObjectNodeManager.ActiveGONManager;
            Debug.Assert(manager != null);

            manager.baseDumpNodes();
        }
        
        override protected NodeBase derivedCreateNode()
        {
            //LTN - Game object node manager owns this new game object node
            NodeBase node_base = new GameObjectNode();
            Debug.Assert(node_base != null);

            return node_base;
        }
    }
}
