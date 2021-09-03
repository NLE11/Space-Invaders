using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SpriteBoxProxy : SpriteBase
    {
        // Data
        public float x;
        public float y;
        public Name name;
        public SpriteBox SpriteBox;

        public enum Name
        {
            ProxyBox,
            ProxyBox_null,
            Uninitialized
        }


        // Constructor

        public SpriteBoxProxy()
        : base()
        {
            this.Clear();
        }

        public SpriteBoxProxy(SpriteBoxProxy.Name name)
        : base()
        {
            this.name = name;
            this.Clear();
        }

        public void Set(SpriteBox.Name name)
        {
            this.name = SpriteBoxProxy.Name.ProxyBox;

            this.x = 0.0f;
            this.y = 0.0f;

            this.SpriteBox = SpriteBoxManager.Find(name);
            Debug.Assert(this.SpriteBox != null);
        }
        private void PushToReal()
        {
            // push the data from proxy to Real GameSprite
            Debug.Assert(this.SpriteBox != null);

            this.SpriteBox.x = this.x;
            this.SpriteBox.y = this.y;
        }



        private void Clear()
        {
            this.name = SpriteBoxProxy.Name.Uninitialized;

            this.x = 0.0f;
            this.y = 0.0f;

            this.SpriteBox = null;
        }

        //---------------------------------------------------------------------------------------------------------
        // Override
        //---------------------------------------------------------------------------------------------------------

        public override void Render()
        {
            // push the values over to Real BoxSprite
            this.PushToReal();

            // update and draw real box sprite 
            this.SpriteBox.Update();
            this.SpriteBox.Render();
        }

        public override void Update()
        {
            // push the data from proxy to Real GameSprite
            this.PushToReal();
            this.SpriteBox.Update();
        }

        public override object GetName()
        {
            return this.name;
        }

        override public void Wash()
        {
            this.Clear();
        }

        override public bool Compare(NodeBase Node_To_Find)
        {
            Debug.Assert(Node_To_Find != null);

            SpriteBoxProxy node_box = (SpriteBoxProxy)Node_To_Find;

            bool status = false;

            if (this.name == node_box.name)
            {
                status = true;
            }

            return status;
        }

        override public void Dump()
        {
            // we are using HASH code as its unique identifier 
            Debug.WriteLine("This Box Proxy:   {0} ({1})", this.name, this.GetHashCode());

            // Data:
            if (SpriteBox != null)
            {
                Debug.WriteLine("    Sprite Box:{0} ({1})", this.SpriteBox.GetName(), this.SpriteBox.GetHashCode());
            }
            else
            {
                Debug.WriteLine("    Sprite Box: null");
            }
            Debug.WriteLine(" Size of Box proxy (x,y): {0},{1}", this.x, this.y);

            base.Dump();
        }

    }
}
