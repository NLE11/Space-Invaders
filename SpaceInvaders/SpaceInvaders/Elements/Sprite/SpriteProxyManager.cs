using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SpriteProxyManager : ManagerBase
    {
        // Data
        
        private readonly SpriteProxy NodeToCompare;
        private static SpriteProxyManager Instance = null;
        
        // Constructor
        private SpriteProxyManager(int reserveNum = 3, int reserveGrow = 1)
                : base(new DLinkMAN(), new DLinkMAN(), reserveNum, reserveGrow)   
        {
            // initialize derived data here
            //LTN - Constructor
            this.NodeToCompare = new SpriteProxy();
            this.NodeToCompare.Sprite = SpriteManager.Find(Sprite.Name.Null_Object);
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
                //LTN - This instance manager is created to control proxy nodes added to or removed from the lists
                Instance = new SpriteProxyManager(reserveNum, reserveGrow);
            }
            // Add a SpriteProxyNull
            SpriteProxyManager.Add(Sprite.Name.Null_Object);
        }
        public static void Destroy()
        {
            SpriteProxyManager manager = SpriteProxyManager.GetInstance();
            Debug.Assert(manager != null);

            manager.baseDumpNodes();
            Instance = null;
        }
        public static SpriteProxyManager GetInstance()
        {
            Debug.Assert(Instance != null);
            return Instance;
        }

        public static SpriteProxy Add(Sprite.Name name)
        {
            SpriteProxyManager manager = SpriteProxyManager.GetInstance();
            Debug.Assert(manager != null);

            SpriteProxy node = (SpriteProxy)manager.baseAddToFront();
            Debug.Assert(node != null);

            node.Set(name);

            return node;
        }

        public static SpriteProxy Find(Sprite.Name name)
        {
            SpriteProxyManager manager = SpriteProxyManager.GetInstance();
            Debug.Assert(manager != null);
                
            manager.NodeToCompare.Sprite.name = name;

            SpriteProxy found_node = (SpriteProxy)manager.baseFind(manager.NodeToCompare);  
            
            return found_node;
        }

        public static void Remove(SpriteProxy current_node)
        {
            Debug.Assert(current_node != null);

            SpriteProxyManager manger = SpriteProxyManager.GetInstance();
            Debug.Assert(manger != null);

            manger.baseRemoveNode(current_node);
        }
        public static void Dump()
        {
            SpriteProxyManager manager = SpriteProxyManager.GetInstance();
            Debug.Assert(manager != null);

            manager.baseDumpNodes();
        }
        
        override protected NodeBase derivedCreateNode()
        {
            //LTN - SpriteProxyManager owns it.
            NodeBase node_base = new SpriteProxy();
            Debug.Assert(node_base != null);

            return node_base;
        }
    }
}
