using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ImageManager : ManagerBase
    {
        private readonly Image NodeCompare;
        private static ImageManager Instance = null; //Singleton to return this instance

        public ImageManager(int numReserve = 3, int reserveGrow = 1)
            : base(new DLinkMAN(), new DLinkMAN(), numReserve, reserveGrow)
        {
            this.NodeCompare = new Image();
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
                Instance = new ImageManager(numReserve, reserveGrow);
            }

            Image GreenBird = ImageManager.Add(Image.Name.GreenBird, Texture.Name.Aliens, 246, 135, 99, 72);
            Debug.Assert(GreenBird != null);

        }

        private static ImageManager GetInstance()
        {
            Debug.Assert(Instance != null);
            return Instance;
        }

        public void Destroy()
        {
            ImageManager manager = ImageManager.GetInstance();
            Debug.Assert(manager != null);

            manager.baseDumpNodes();
            Instance = null;
        }

        public static Image Add(Image.Name name, Texture.Name textureName, float x, float y, float width, float height)
        {
            ImageManager manager = ImageManager.GetInstance();

            Texture current_texture = TextureManager.Find(textureName);

            Image node = (Image)manager.baseAddToFront();
            Debug.Assert(node != null);

            //Set data
            node.Set(name, current_texture, x, y, width, height);
            return node;
        }

        public static Image Find(Image.Name name)
        {
            ImageManager manager = ImageManager.GetInstance();
            Debug.Assert(manager != null);

            manager.NodeCompare.name = name; //Set the name of this node the same to the node we want to find

            Image foundNode = (Image)manager.baseFind(manager.NodeCompare);
            return foundNode;
        }

        public static void Remove(Image image)
        {
            Debug.Assert(image != null);
            ImageManager manager = ImageManager.GetInstance();
            Debug.Assert(manager != null);

            manager.baseRemoveNode(image);
        }

        public static void Dump()
        {
            ImageManager manager = ImageManager.GetInstance();
            Debug.Assert(manager != null);

            manager.baseDumpNodes();
        }

        
        protected override NodeBase derivedCreateNode()
        {
            NodeBase nodebase = new Image();
            Debug.Assert(nodebase != null);

            return nodebase;
        }
    }
}
