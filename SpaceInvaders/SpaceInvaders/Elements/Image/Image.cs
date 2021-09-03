using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Image : DLink
    {
        public Name name;
        public Azul.Rect Rect;
        public Texture Texture;

        public enum Name
        {
            Squid1, Squid2,
            Crab1, Crab2,
            Crab3, Crab4,
            Octopus1, Octopus2,
            Octopus3, Octopus4,
            UFO,
            UFOSelect,

            RedBird,
            YellowBird,
            GreenBird,
            WhiteBird,

            Ship,
            ShipMini,
            Missile,
            GreenWall,
            Splat,

            BombZigZag,
            BombStraight,
            BombCross,

            Brick,
            BrickLeft_Top0,
            BrickLeft_Top1,
            BrickLeft_Bottom,
            BrickRight_Top0,
            BrickRight_Top1,
            BrickRight_Bottom,

            Null_Image,

            Uninitialized
        }

        public Image()
        {
            this.name = Name.Uninitialized;
            this.Texture = null;
            this.Rect = new Azul.Rect(); //Cut rectangle image
        }

        public void Set(Name name, Texture texture, float x, float y, float width, float height)
        {
            Debug.Assert(texture != null);
            Debug.Assert(Rect != null);
            this.Texture = texture;
            this.Rect.Set(x, y, width, height);
            this.name = name;
        }

        public Azul.Texture GetAzulTexture()
        {
            return this.Texture.GetAzulTexture();
        }

        public Azul.Rect GetAzulRect()
        {
            return this.Rect;
        }

        private void DefaultImage()
        {
            Debug.Assert(this.Rect != null);
            this.name = Name.Uninitialized;
            this.Texture = null;
            this.Rect.Clear();
        }

        override public bool Compare(NodeBase NodeToFind)
        {
            // This is used in ManBase.Find() 
            Debug.Assert(NodeToFind != null);

            Image current_image = (Image)NodeToFind;

            bool status = false;

            if (this.name == current_image.name)
            {
                status = true;
            }

            return status;
        }

        public override object GetName()
        {
            return this.name;
        }

        public override void Dump()
        {
            Debug.WriteLine("This image is {0} ({1})", this.name, this.GetHashCode());
            Debug.WriteLine("Rect: [{0} {1} {2} {3}]", this.Rect.x, this.Rect.y, this.Rect.width, this.Rect.height);
            base.Dump();
        }

        public override void Wash()
        {
            this.DefaultImage();
        }
    }
}
