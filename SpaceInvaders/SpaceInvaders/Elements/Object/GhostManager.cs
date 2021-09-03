using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class GhostManager : ManagerBase
    {
        // Data
        private readonly GameObjectNode NodeToCompare = new GameObjectNode();
        private readonly GameObjectNull GameObject = new GameObjectNull();
        private static GhostManager Instance = null;
        private static GhostManager ActiveGhostManager = null;

        // Constructor
        public GhostManager(int reserveNum = 3, int reserveGrow = 1)
                : base(new DLinkMAN(), new DLinkMAN(), reserveNum, reserveGrow)  
        {
            this.NodeToCompare.GameObject = this.GameObject;
            GhostManager.ActiveGhostManager = null;
        }

        public static void Create()
        {
            // Start singleton
            Debug.Assert(Instance == null);

            // Do the initialization
            if (Instance == null)
            {
                Instance = new GhostManager();
            }
        }
        public static void Destroy()
        {
            GhostManager manager = GhostManager.ActiveGhostManager;
            Debug.Assert(manager != null);

            manager.baseDumpNodes();
            Instance = null;
        }
        public static void SetActive(GhostManager ghost_manager)
        {
            GhostManager manager = GhostManager.GetInstance();
            Debug.Assert(manager != null);

            Debug.Assert(ghost_manager != null);
            GhostManager.ActiveGhostManager = ghost_manager;
        }

        public static GameObjectNode Attach(GameObject game_object)
        {
            GhostManager manager = GhostManager.ActiveGhostManager;
            GameObjectNode this_node = (GameObjectNode)manager.baseAddToFront();

            this_node.Set(game_object);
            return this_node;
        }

        public static GameObjectNode Find(GameObject.Name name)
        {
            GhostManager manager = GhostManager.ActiveGhostManager;

            Debug.Assert(manager.NodeToCompare.GameObject != null);

            manager.NodeToCompare.GameObject.name = name;

            GameObjectNode node_found = (GameObjectNode)manager.baseFind(manager.NodeToCompare);
            return node_found;
        }


        public static void Remove(GameObjectNode current_node)
        {
            Debug.Assert(current_node != null);

            GhostManager manager = GhostManager.ActiveGhostManager;
            Debug.Assert(manager != null);

            manager.baseRemoveNode(current_node);
        }

        public static void Dump()
        {
            GhostManager pMan = GhostManager.ActiveGhostManager;

            pMan.baseDumpNodes();
        }

        public static GhostManager GetInstance()
        {
            Debug.Assert(Instance != null);

            return Instance;
        }

        override protected NodeBase derivedCreateNode()
        {
            NodeBase node_base = new GameObjectNode();
            Debug.Assert(node_base != null);

            return node_base;
        }
    }
}
