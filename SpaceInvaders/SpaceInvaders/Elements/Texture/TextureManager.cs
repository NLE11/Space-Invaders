using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class TextureManager : ManagerBase
    {
        private readonly Texture NodeCompare;
        private static TextureManager Instance = null; //Singleton to return this instance
            
        public TextureManager(int numReserve = 3, int reserveGrow = 1)
            : base(new DLinkMAN(), new DLinkMAN(), numReserve, reserveGrow)
        {
            //LTN - Constructor 
            this.NodeCompare = new Texture();
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
                //LTN - This instance manager will be used for controlling the new textures added to or removed from the lists. TextureManagers own it.
                Instance = new TextureManager(numReserve, reserveGrow);
            }

            //Default
            Texture AliensTexture = TextureManager.Add(Texture.Name.Aliens, "Invaders_1.tga");
            Debug.Assert(AliensTexture != null);
        }

        private static TextureManager GetInstance()
        {
            Debug.Assert(Instance != null);
            return Instance;
        }

        public void Destroy()
        {
            TextureManager manager = TextureManager.GetInstance();
            Debug.Assert(manager != null);

            manager.baseDumpNodes();
            Instance = null;
        }

        public static Texture Add(Texture.Name name, string TextureName)
        {
            TextureManager manager = TextureManager.GetInstance();
            Debug.Assert(manager != null);

            Texture node = (Texture)manager.baseAddToFront();
            Debug.Assert(node != null);

            //Set data
            node.Set(name, TextureName);
            return node;
        }

        public static Texture Find(Texture.Name name)
        {
            TextureManager manager = TextureManager.GetInstance();
            Debug.Assert(manager != null);

            manager.NodeCompare.name = name; //Set the name of this node the same to the node we want to find

            Texture foundNode = (Texture)manager.baseFind(manager.NodeCompare);
            return foundNode;
        }

        public static void Remove(Texture texture)
        {
            Debug.Assert(texture != null);
            TextureManager manager = TextureManager.GetInstance();
            Debug.Assert(manager != null);

            manager.baseRemoveNode(texture);
        }

        public static void Dump()
        {
            TextureManager manager = TextureManager.GetInstance();
            Debug.Assert(manager != null);

            manager.baseDumpNodes();
        }

        
        protected override NodeBase derivedCreateNode()
        {
            //LTN - Texture Manager owns it.
            NodeBase nodebase = new Texture();
            Debug.Assert(nodebase != null);

            return nodebase;
        }
    }
}
