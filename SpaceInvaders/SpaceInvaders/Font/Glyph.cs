using System.Diagnostics;

namespace SpaceInvaders
{
    public class Glyph : DLink
    {
        // Data
        public Name name;
        public int key;
        private Azul.Rect Subject_Rect;
        private Texture Texture;

        // Enum
        public enum Name
        {
            Consolas36pt,

            Null_Object,
            Uninitialized
        }
        // Constructor
        public Glyph()
            : base()
        {
            this.name = Name.Uninitialized;
            this.Texture = null;
            this.Subject_Rect = new Azul.Rect();
            this.key = 0;
        }

        public void Set(Glyph.Name name, int key, Texture.Name textureName, float x, float y, float width, float height)
        {
            Debug.Assert(this.Subject_Rect != null);
            this.name = name;

            this.Texture = TextureManager.Find(textureName);
            Debug.Assert(this.Texture != null);

            this.Subject_Rect.Set(x, y, width, height);

            this.key = key;

        }

        private void privClear()
        {
            this.name = Name.Uninitialized;
            this.Texture = null;
            this.Subject_Rect.Set(0, 0, 1, 1);
            this.key = 0;
        }

        public Azul.Rect GetAzulRect()
        {
            Debug.Assert(this.Subject_Rect != null);
            return this.Subject_Rect;
        }

        public Azul.Texture GetAzulTexture()
        {
            Debug.Assert(this.Texture != null);
            return this.Texture.GetAzulTexture();
        }

        public override object GetName()
        {
            return this.name;
        }

        override public void Wash()
        {
            this.privClear();
        }

        override public bool Compare(NodeBase pTarget)
        {
            // This is used in ManBase.Find() 
            Debug.Assert(pTarget != null);

            Glyph pDataB = (Glyph)pTarget;

            bool status = false;

            if (this.name == pDataB.name && this.key == pDataB.key)
            {
                status = true;
            }

            return status;
        }

        override public void Dump()
        {
            Debug.WriteLine("Glyph Name: {0} ({1})", this.name, this.GetHashCode());
            Debug.WriteLine("--Key: {0}", this.key);
            if (this.Texture != null)
            {
                Debug.WriteLine("----Texture: {0}", this.Texture.GetName());
            }
            else
            {
                Debug.WriteLine("----Texture: null");
            }
            Debug.WriteLine("----Rectangle Size: {0}, {1}, {2}, {3}", this.Subject_Rect.x, this.Subject_Rect.y, this.Subject_Rect.width, this.Subject_Rect.height);

            base.Dump();
        }
    }
}

