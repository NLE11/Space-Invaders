using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SpriteBatch : DLink
    {
        // Data
        public SpriteBatch.Name name;
        public int id;
        private readonly SpriteNodeManager SpriteNodeManager;
        private bool DrawEnable;

        public enum Name
        {
            Aliens,

            Birds,

            Boxes,
            Boxes1,
            Boxes2,

            Texts,

            Shields,

            Uninitialized
        }

        public SpriteBatch()
            : base()
        {
            this.name = SpriteBatch.Name.Uninitialized;
            this.id = 0;
            this.SpriteNodeManager = new SpriteNodeManager();
            Debug.Assert(this.SpriteNodeManager != null);
        }

        public void Set(SpriteBatch.Name name, int NumReserve = 3, int ReserveGrow = 1)
        {
            this.DrawEnable = true;
            this.name = name;
            this.SpriteNodeManager.Set(name, id, NumReserve, ReserveGrow);
        }

        public void SetIndex(SpriteBatch.Name name, int id, int NumReserve = 3, int ReserveGrow = 1)
        {
            this.DrawEnable = true;
            this.name = name;
            this.id = id;
            this.SpriteNodeManager.Set(name, id, NumReserve, ReserveGrow);
        }

        public void SetName(SpriteBatch.Name thisname)
        {
            this.name = thisname;
        }

        public SpriteNodeManager GetSpriteBatchNodeManager()
        {
            return this.SpriteNodeManager;
        }

        public SpriteNode Attach(GameObject game_object)
        {
            Debug.Assert(game_object != null);
            SpriteNode node = this.SpriteNodeManager.Attach(game_object.SpriteProxy);
            // Initialize SpriteBatchNode
            node.Set(game_object.SpriteProxy, this.SpriteNodeManager);

            // Back pointer
            this.SpriteNodeManager.SetSpriteBatch(this);

            return node;
        }

        public SpriteNode Attach(SpriteBase current_node)
        {
            SpriteNode node = this.SpriteNodeManager.Attach(current_node);

            // Initialize SpriteBatchNode
            node.Set(current_node, this.SpriteNodeManager);

            // Back pointer
            this.SpriteNodeManager.SetSpriteBatch(this);

            return node;
        }

        public override object GetName()
        {
            return this.name;
        }
        public override void Wash()
        {
            this.Clear();    
        }

        public override bool Compare(NodeBase NodeToFind)
        {
            Debug.Assert(NodeToFind != null);

            SpriteBatch node = (SpriteBatch)NodeToFind;

            bool status = false;

            if (this.name == node.name)
            {
                status = true;
            }

            return status;
        }

        public override void Dump()
        {
            Debug.WriteLine("Batch Name: {0} ({1})", this.name, this.GetHashCode());
            base.Dump();
        }

        public void SetDrawEnable(bool status)
        {
            this.DrawEnable = status;
        }
        public bool GetDrawEnable()
        {
            return this.DrawEnable;
        }
    }
}
