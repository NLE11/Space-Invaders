using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SpriteBoxManager : ManagerBase
    {
        private readonly SpriteBox NodeToCompare;
        private static SpriteBoxManager Instance = null;

        private SpriteBoxManager(int NumReserve = 3, int ReserveGrow = 1)
            : base(new DLinkMAN(), new DLinkMAN(), NumReserve, ReserveGrow)
        {
            //LTN - Constructor
            this.NodeToCompare = new SpriteBox();
        }

        public static void Create(int NumReserve = 3, int ReserveGrow = 1)
        {
            Debug.Assert(NumReserve > 0);
            Debug.Assert(ReserveGrow > 0);

            Debug.Assert(Instance == null);

            if (Instance == null)
            {
                //LTN - This instance manager is created to control box nodes added to or removed from the lists
                Instance = new SpriteBoxManager(NumReserve, ReserveGrow);
            }
            // Null sprite added to manager
            SpriteBoxManager.Add(SpriteBox.Name.Null_Object, 1.0f, 1.0f, 0.0f, 0.0f, null);
        }

        public static void Destroy()
        {
            SpriteBoxManager manager = SpriteBoxManager.GetInstance();
            Debug.Assert(manager != null);

            manager.baseDumpNodes();
            Instance = null;
        }

        public static SpriteBox Add(SpriteBox.Name name, float x, float y, float width, float height, Azul.Color Color = null)
        {
            SpriteBoxManager manager = SpriteBoxManager.GetInstance();
            Debug.Assert(manager != null);

            SpriteBox node = (SpriteBox)manager.baseAddToFront();
            Debug.Assert(node != null);

            node.Set(name, x, y, width, height, Color);

            return node;
        }

        public static SpriteBox Find(SpriteBox.Name name)
        {
            SpriteBoxManager manager = SpriteBoxManager.GetInstance();
            Debug.Assert(manager != null);

            manager.NodeToCompare.name = name;

            SpriteBox box = (SpriteBox)manager.baseFind(manager.NodeToCompare);
            return box;
        }

        public static void Remove(SpriteBox current_node)
        {
            Debug.Assert(current_node != null);

            SpriteBoxManager manager = SpriteBoxManager.GetInstance();
            Debug.Assert(manager != null);

            manager.baseRemoveNode(current_node);
        }

        public static void Dump()
        {
            SpriteBoxManager manager = SpriteBoxManager.GetInstance();
            Debug.Assert(manager != null);

            manager.baseDumpNodes();
        }

        private static SpriteBoxManager GetInstance()
        {
            Debug.Assert(Instance != null);
            return Instance;
        }

        protected override NodeBase derivedCreateNode()
        {
            //LTN - SpriteBoxManager owns this new node
            NodeBase basenode = new SpriteBox();
            Debug.Assert(basenode != null);

            return basenode;
        }
    }
}



