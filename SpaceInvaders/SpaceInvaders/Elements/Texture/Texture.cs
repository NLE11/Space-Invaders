using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Texture : DLink //Load
    {
        public Name name;
        public Azul.Texture AzTexture;
        public enum Name
        {
            Aliens,

            Birds,

            Bombs,

            Consolas36pt,

            Uninitialized
        }

        public Texture()
        {
            this.AzTexture = new Azul.Texture();
            Debug.Assert(this.AzTexture != null);
            this.name = Texture.Name.Uninitialized;
        }

        //Now we have a few methods here

        public void Set(Name name, string TextureName)
        {
            Debug.Assert(TextureName != null);
            this.AzTexture.Set(TextureName, Azul.Texture_Filter.NEAREST, Azul.Texture_Filter.NEAREST);
            this.name = name;
        }

        public Azul.Texture GetAzulTexture()
        {
            return this.AzTexture;
        }

        private void DefaultTexture() //Clear with default texture
        {
            Debug.Assert(this.AzTexture != null);
            this.AzTexture.Set("stitch.tga", Azul.Texture_Filter.NEAREST, Azul.Texture_Filter.NEAREST);
            this.name = Name.Uninitialized;
        }

        public override object GetName()
        {
            return this.name;
        }
        override public bool Compare(NodeBase NodeToFind)
        {
            // This is used in ManBase.Find() 
            Debug.Assert(NodeToFind != null);

            Texture current_texture = (Texture)NodeToFind;

            bool status = false;

            if (this.name == current_texture.name)
            {
                status = true;
            }

            return status;
        }

        public override void Dump()
        {
            Debug.WriteLine("This texture is: {0} ({1})", this.name, this.GetHashCode());
            Debug.WriteLine("AzulTexture: {0}", this.AzTexture.GetHashCode());
            base.Dump();
        }

        public override void Wash()
        {
            this.DefaultTexture();    
        }
    }
}
