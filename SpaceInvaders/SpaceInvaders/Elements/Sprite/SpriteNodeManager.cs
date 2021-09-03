using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SpriteNodeManager : ManagerBase
    {
        private readonly SpriteNode NodeToCompare;
        private SpriteBatch.Name name;
        private int id;
        // Keenan(delete.D)
        private SpriteBatch BackSpriteBatch;

        public SpriteNodeManager(int NumReserve = 3, int ReserveGrow = 1)
            : base(new DLinkMAN(), new DLinkMAN(), NumReserve, ReserveGrow)
        {
            //LTN - Constructor
            this.NodeToCompare = new SpriteNode();
            this.BackSpriteBatch = null;
        }

        public void Set(SpriteBatch.Name name, int id, int NumReserve, int ReserveGrow)
        {
            this.name = name;
            this.id = id;
            Debug.Assert(NumReserve > 0);
            Debug.Assert(ReserveGrow > 0);

            this.SetReserve(NumReserve, ReserveGrow);
        }

        public SpriteNode Attach(SpriteBase node)
        {
            SpriteNode sprite_node = (SpriteNode)this.baseAddToFront();
            Debug.Assert(sprite_node != null);

            //Set Data
            sprite_node.Set(node, this);
            return sprite_node;
        }




        public void Draw()
        {
            //Iterate through the batch to draw all elements
            Iterator iterator = this.baseGetIterator();
            Debug.Assert(iterator != null);

            SpriteNode node = (SpriteNode)iterator.First();

            while(!iterator.isDone())
            {
                node.SpriteBase.Render();

                node = (SpriteNode)iterator.Next();
            }
        }

        public void Remove(SpriteNode SpriteNode)
        {
            Debug.Assert(SpriteNode != null);
            this.baseRemoveNode(SpriteNode);
        }

        public void Dump()
        {
            this.baseDumpNodes();
        }
        public SpriteBatch GetSpriteBatch()
        {
            return this.BackSpriteBatch;
        }
        public void SetSpriteBatch(SpriteBatch SpriteBatch)
        {
            this.BackSpriteBatch = SpriteBatch;
        }
        protected override NodeBase derivedCreateNode()
        {
            //LTN - New sprite node is created and SpriteNodeManager owns it.
            NodeBase NodeBase = new SpriteNode();
            Debug.Assert(NodeBase != null);

            return NodeBase;
        }
    }
}
