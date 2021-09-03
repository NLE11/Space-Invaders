using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SpriteNode : DLink
    {
        public SpriteBase SpriteBase;
        // Keenan(delete.C)
        private SpriteNodeManager BackSpriteNodeManager;

        public SpriteNode()
            : base()
        {
            this.SpriteBase = null;
            this.BackSpriteNodeManager = null;
        }
        public void Set(SpriteBase pNode, SpriteNodeManager SpriteNodeMan)
        {
            Debug.Assert(pNode != null);
            this.SpriteBase = pNode;

            // Set the back pointer
            // Allows easier deletion in the future
            Debug.Assert(SpriteBase != null);
            this.SpriteBase.SetSpriteNode(this);

            Debug.Assert(SpriteNodeMan != null);
            this.BackSpriteNodeManager = SpriteNodeMan;
        }

       
        public SpriteBase GetSpriteBase()
        {
            return this.SpriteBase;
        }
        public SpriteNodeManager GetSBNodeManager()
        {
            Debug.Assert(this.BackSpriteNodeManager != null);
            return this.BackSpriteNodeManager;
        }
        public SpriteBatch GetSpriteBatch()
        {
            Debug.Assert(this.BackSpriteNodeManager != null);
            return this.BackSpriteNodeManager.GetSpriteBatch();
        }

        private void Clear()
        {
            this.SpriteBase = null;
        }

        public override void Dump()
        {
            Debug.WriteLine("This Sprite Node: ({0})", this.GetHashCode());
            Debug.WriteLine("This Sprite: {0} ({1})", this.SpriteBase.GetName(), this.SpriteBase.GetHashCode());
            base.Dump();
        }

        public override void Wash()
        {
            this.Clear();
        }
    }
}
