using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SpriteBatchManager : ManagerBase
    {
        private static SpriteBatch NodeToCompare = new SpriteBatch();
        private static SpriteBatchManager CurrentSBManager = null;
        private static SpriteBatchManager Instance = null;

        public SpriteBatchManager(int NumReserve = 3, int ReserveGrow = 1)
        : base(new DLinkMAN(), new DLinkMAN(), NumReserve, ReserveGrow)
        {
            SpriteBatchManager.CurrentSBManager = null;
        }

        public static void Create()
        {
            Debug.Assert(Instance == null);

            //Initialize here
            if (Instance == null)
            {
                //LTN - This instance manager is created to control sprite batch nodes added to or removed from the lists
                Instance = new SpriteBatchManager();

            }
        }

        public static void Destroy()
        {
            SpriteBatchManager manager = SpriteBatchManager.CurrentSBManager;
            Debug.Assert(manager != null);

            manager.baseDumpNodes();
            Instance = null;
            CurrentSBManager = null;
        }

        private static SpriteBatchManager GetInstance()
        {
            Debug.Assert(Instance != null);
            return Instance;
        }

        public static SpriteBatch Add(SpriteBatch.Name name, int NumReserve = 3, int ReserveGrow = 1)
        {
            //Add a node from reserve to active
            SpriteBatchManager manager = SpriteBatchManager.CurrentSBManager;
            Debug.Assert(manager != null);

            SpriteBatch node = (SpriteBatch)manager.baseAddToFront();
            Debug.Assert(node != null);

            //Set data
            node.Set(name, NumReserve, ReserveGrow);
            return node;
        }

        public static SpriteBatch AddIndex(SpriteBatch.Name name, int id, int NumReserve = 3, int ReserveGrow = 1)
        {
            //Add a node from reserve to active
            SpriteBatchManager manager = SpriteBatchManager.CurrentSBManager;
            Debug.Assert(manager != null);

            SpriteBatch node = (SpriteBatch)manager.baseAddToIndex(id);
            Debug.Assert(node != null);

            //Set data
            node.SetIndex(name, id, NumReserve, ReserveGrow);
            return node;
        }

        public static void SetActive(SpriteBatchManager current_manager)
        {
            //SpriteBatchManager manager = SpriteBatchManager.GetInstance();
            //Debug.Assert(manager != null);

            Debug.Assert(current_manager != null);
            SpriteBatchManager.CurrentSBManager = current_manager;
        }

        public static void Draw()
        {
            SpriteBatchManager manager = SpriteBatchManager.CurrentSBManager;
            Debug.Assert(manager != null);

            //Use iterator to render everything in the batch
            Iterator iterator = manager.baseGetIterator();
            Debug.Assert(iterator != null);

            SpriteBatch SpriteBatch = (SpriteBatch)iterator.First();

            while (!iterator.isDone())
            {
                if (SpriteBatch.GetDrawEnable())
                {
                    SpriteNodeManager SBNodeManager = SpriteBatch.GetSpriteBatchNodeManager();
                    Debug.Assert(SBNodeManager != null);

                    // Kick the can
                    SBNodeManager.Draw();  
                }
                SpriteBatch = (SpriteBatch)iterator.Next();
            }
        }

        public static SpriteBatch Find(SpriteBatch.Name name)
        {
            SpriteBatchManager manager = SpriteBatchManager.CurrentSBManager;
            Debug.Assert(manager != null);

            SpriteBatchManager.NodeToCompare.name = name;

            SpriteBatch batch = (SpriteBatch)manager.baseFind(SpriteBatchManager.NodeToCompare);
            return batch;
        }

        public static void Remove(SpriteBatch current_node)
        {
            SpriteBatchManager manager = SpriteBatchManager.CurrentSBManager;
            Debug.Assert(manager != null);

            Debug.Assert(current_node != null);

            manager.baseRemoveNode(current_node);
        }

        public static void Remove(SpriteNode SpriteBatchNode)
        {
            Debug.Assert(SpriteBatchNode != null);
            SpriteNodeManager SpriteNodeManager = SpriteBatchNode.GetSBNodeManager();

            Debug.Assert(SpriteNodeManager != null);
            SpriteNodeManager.Remove(SpriteBatchNode);
        }

        public static void Dump()
        {
            SpriteBatchManager manager = SpriteBatchManager.CurrentSBManager;
            Debug.Assert(manager != null);
            manager.baseDumpNodes();
        }
        protected override NodeBase derivedCreateNode()
        {
            //LTN - SpriteBatchManager owns this new SpriteBatch
            NodeBase node_base = new SpriteBatch();
            Debug.Assert(node_base != null);

            return node_base;
        }

        public static SpriteBatch ChangePriority(SpriteBatch.Name name, int priority, int NumReserve = 3, int ReserveGrow = 1)
        {
            SpriteBatchManager manager = SpriteBatchManager.GetInstance();
            Debug.Assert(manager != null);

            SpriteBatchManager.NodeToCompare.name = name;

            SpriteBatch save_node = (SpriteBatch)manager.baseFind(SpriteBatchManager.NodeToCompare); //save this node

            manager.baseRemoveNode(SpriteBatchManager.NodeToCompare); //remove this node

            SpriteBatch node = (SpriteBatch)manager.baseAddToIndexWithExistingNode(save_node, priority);

            Debug.Assert(node != null);

            //Set data
            node.SetIndex(name, priority, NumReserve, ReserveGrow);
            return node;
        }
    }
}
