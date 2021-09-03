using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class SpriteBase : DLink
    {
        // Data: -------------------------------------------

        // Keenan(delete.B)
        // If you remove a SpriteBase initiated by gameObject... 
        //     its hard to get the spriteBatchNode
        //     so have a back pointer to it
        private SpriteNode BackSpriteNode;
        public SpriteBase()
        : base()
        {
            this.BackSpriteNode = null;
        }

        abstract public void Render();
        abstract public void Update();

        public SpriteNode GetSpriteNode()
        {
            Debug.Assert(this.BackSpriteNode != null);
            return this.BackSpriteNode;
        }
        public void SetSpriteNode(SpriteNode pSpriteBatchNode)
        {
            Debug.Assert(pSpriteBatchNode != null);
            this.BackSpriteNode = pSpriteBatchNode;
        }   
    }
}
