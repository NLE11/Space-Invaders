using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SpriteBoxProxyManager : ManagerBase
    {
        // Data

        private readonly SpriteBoxProxy NodeToCompare;
        private static SpriteBoxProxyManager Instance = null;

        // Constructor
        private SpriteBoxProxyManager(int reserveNum = 3, int reserveGrow = 1)
                : base(new DLinkMAN(), new DLinkMAN(), reserveNum, reserveGrow)
        {
            // initialize derived data here
            //LTN - Constructor
            this.NodeToCompare = new SpriteBoxProxy();
        }

        public static void Create(int reserveNum = 3, int reserveGrow = 1)
        {
            // make sure values are ressonable 
            Debug.Assert(reserveNum > 0);
            Debug.Assert(reserveGrow > 0);

            // initialize the singleton here
            Debug.Assert(Instance == null);

            // Do the initialization
            if (Instance == null)
            {
                //LTN - This instance manager is created to control box proxy nodes added to or removed from the lists
                Instance = new SpriteBoxProxyManager(reserveNum, reserveGrow);
            }
            // Add a SpriteProxyNull
            SpriteBoxProxyManager.Add(SpriteBox.Name.Null_Object);
        }
        public static void Destroy()
        {
            SpriteBoxProxyManager manager = SpriteBoxProxyManager.GetInstance();
            Debug.Assert(manager != null);

            manager.baseDumpNodes();
            Instance = null;
        }
        private static SpriteBoxProxyManager GetInstance()
        {
            Debug.Assert(Instance != null);
            return Instance;
        }

        public static SpriteBoxProxy Add(SpriteBox.Name name)
        {
            SpriteBoxProxyManager manager = SpriteBoxProxyManager.GetInstance();
            Debug.Assert(manager != null);

            SpriteBoxProxy node = (SpriteBoxProxy)manager.baseAddToFront();
            Debug.Assert(node != null);

            node.Set(name);

            return node;
        }

        public static SpriteBoxProxy Find(SpriteBox.Name name)
        {
            SpriteBoxProxyManager manager = SpriteBoxProxyManager.GetInstance();
            Debug.Assert(manager != null);

            manager.NodeToCompare.SpriteBox.name = name;

            SpriteBoxProxy found_node = (SpriteBoxProxy)manager.baseFind(manager.NodeToCompare);
            return found_node;
        }

        public static void Remove(SpriteBoxProxy current_node)
        {
            Debug.Assert(current_node != null);

            SpriteBoxProxyManager manger = SpriteBoxProxyManager.GetInstance();
            Debug.Assert(manger != null);

            manger.baseRemoveNode(current_node);
        }
        public static void Dump()
        {
            SpriteBoxProxyManager manager = SpriteBoxProxyManager.GetInstance();
            Debug.Assert(manager != null);

            manager.baseDumpNodes();
        }

        override protected NodeBase derivedCreateNode()
        {
            //LTN - SpriteBoxProxyNode owns it
            NodeBase node_base = new SpriteBoxProxy();
            Debug.Assert(node_base != null);

            return node_base;
        }
    }
}
