using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SpriteProxy : SpriteBase
    {
        // Data
        public Name name;
        public float x;
        public float y;
        public float sx;
        public float sy;
        public Sprite Sprite;

        public enum Name
        {
            Proxy,
            Proxy_null,
            Uninitialized
        }

        // Constructor

        // Create a single sprite and all dynamic objects ONCE and ONLY ONCE (OOO- tm)
        public SpriteProxy()
        : base()
        {
            this.Clear();
        }

        public SpriteProxy(SpriteProxy.Name name)
        : base()
        {
            this.name = name;
            this.Clear();
        }

        //--------------------------------------------------
        // Methods
        //--------------------------------------------------

        public void Set(Sprite.Name name)
        {
            this.name = SpriteProxy.Name.Proxy;

            this.x = 0.0f;
            this.y = 0.0f;
            this.sx = 1.0f;
            this.sy = 1.0f;
            // Save the data to this proxy sprite 
            this.Sprite = SpriteManager.Find(name);
            Debug.Assert(this.Sprite != null);
        }
        private void PushToRealSprite()
        {
            // Adjust the data of real sprite
            Debug.Assert(this.Sprite != null);

            this.Sprite.x = this.x;
            this.Sprite.y = this.y;

            this.Sprite.sx = this.sx;
            this.Sprite.sy = this.sy;
        }



        private void Clear()
        {
            // Clear proxy sprite
            this.name = SpriteProxy.Name.Uninitialized;

            this.x = 0.0f;
            this.y = 0.0f;
            this.sx = 1.0f;
            this.sy = 1.0f;
            this.Sprite = null;
        }

        // Override
        public override void Render()
        {
            // move the values over to Real GameSprite
            this.PushToRealSprite();

            // update and draw real sprite 
            // Seems redundant - Real Sprite might be stale
            this.Sprite.Update();
            this.Sprite.Render();
        }

        public override void Update()
        {
            // push the data from proxy to Real GameSprite
            this.PushToRealSprite();
            this.Sprite.Update();
        }

        public override object GetName()
        {
            return this.name;
        }

        override public void Wash()
        {
            this.Clear();
        }

        override public bool Compare(NodeBase NodeToFind)
        {
            // This is used in ManBase.Find() 
            Debug.Assert(NodeToFind != null);

            SpriteProxy node = (SpriteProxy)NodeToFind;

            bool status = false;

            if (this.Sprite.name == node.Sprite.name)
            {
                status = true;
            }

            return status;
        }

        override public void Dump()
        {
            // we are using HASH code as its unique identifier 
            Debug.WriteLine("This Sprite Proxy: {0} ({1})", this.name, this.GetHashCode());

            // Data:
            if (Sprite != null)
            {
                Debug.WriteLine("    Sprite Proxy:{0} ({1})", this.Sprite.GetName(), this.Sprite.GetHashCode());
            }
            else
            {
                Debug.WriteLine("    Sprite Proxy: null");
            }
            Debug.WriteLine("Size of proxy (x,y): {0},{1}", this.x, this.y);

            base.Dump();
        }
    }
}
