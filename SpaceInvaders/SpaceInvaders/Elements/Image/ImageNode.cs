using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ImageNode : SLink
    {
        // Data
        public Image image;

        public ImageNode(Image image)
            : base()
        {
            Debug.Assert(image != null);
            this.image = image;
        }

        private void Clean()
        {
            this.image = null;
        }
        override public void Wash()
        {
            this.Clean();
        }
        override public void Dump()
        {
            // we are using HASH code as its unique identifier 
            Debug.WriteLine("   ({0}) node", this.GetHashCode());

            // Data:
            Debug.WriteLine("   Image: {0} ({1})", this.image.GetName(), this.image.GetHashCode());

            base.Dump();
        }
    }
}
