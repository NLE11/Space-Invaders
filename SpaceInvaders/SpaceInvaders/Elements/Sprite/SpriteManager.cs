using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SpriteManager : ManagerBase
    {
        private readonly Sprite NodeCompare;
        private static SpriteManager Instance = null; //Singleton to return this instance

        public SpriteManager(int numReserve = 3, int reserveGrow = 1)
            : base(new DLinkMAN(), new DLinkMAN(), numReserve, reserveGrow)
        {
            //LTN - Constructor
            this.NodeCompare = new Sprite();
        }

        //Static methods
        public static void Create(int numReserve = 3, int reserveGrow = 1)
        {
            Debug.Assert(numReserve > 0);
            Debug.Assert(reserveGrow > 0);

            Debug.Assert(Instance == null);

            //Initialize singleton
            if (Instance == null)
            {
                //LTN - This instance manager is created to control sprite nodes added to or removed from the lists
                Instance = new SpriteManager(numReserve, reserveGrow);
            }

            // Null sprite added to manager
            SpriteManager.Add(Sprite.Name.Null_Object, Image.Name.GreenBird, 0.0f, 0.0f, 0.0f, 0.0f, null);
        }

        private static SpriteManager GetInstance()
        {
            Debug.Assert(Instance != null);
            return Instance;
        }

        public void Destroy()
        {
            SpriteManager manager = SpriteManager.GetInstance();
            Debug.Assert(manager != null);

            manager.baseDumpNodes();
            Instance = null;
        }

        public static Sprite Add(Sprite.Name name, Image.Name imageName, float x, float y, float width, float height, Azul.Color color = null)
        {
            SpriteManager manager = SpriteManager.GetInstance();

            Image current_image = ImageManager.Find(imageName);

            Sprite node = (Sprite)manager.baseAddToFront();

            //Set data
            node.Set(name, current_image, x, y, width, height, color);
            return node;
        }

        public static Sprite Find(Sprite.Name name)
        {
            SpriteManager manager = SpriteManager.GetInstance();
            Debug.Assert(manager != null);

            manager.NodeCompare.name = name; //Set the name of this node the same to the node we want to find

            Sprite foundNode = (Sprite)manager.baseFind(manager.NodeCompare);
            return foundNode;
        }

        public static void Remove(Sprite sprite)
        {
            Debug.Assert(sprite != null);
            SpriteManager manager = SpriteManager.GetInstance();
            Debug.Assert(manager != null);

            manager.baseRemoveNode(sprite);
        }

        public static void Dump()
        {
            SpriteManager manager = SpriteManager.GetInstance();
            Debug.Assert(manager != null);

            manager.baseDumpNodes();
        }

        protected override NodeBase derivedCreateNode()
        {
            //LTN - SpriteManager owns this SpriteNode
            NodeBase nodebase = new Sprite();
            Debug.Assert(nodebase != null);

            return nodebase;
        }

    }
}