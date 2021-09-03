using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Sprite : SpriteBase
    {
        public Name name;
        public Azul.Color Color;
        public Azul.Sprite AzSprite;
        public Image Image;
        private Azul.Rect Rect;

        public float x;
        public float y;
        public float sx;
        public float sy;
        public float angle;

        public enum Name
        {
            Squid1, Squid2,
            Crab1, Crab2,
            Crab3, Crab4,
            Octopus1, Octopus2,
            Octopus3, Octopus4,
            UFO,
            UFOSelect,

            Ship,
            ShipMini,
            GreenWall,
            Missile,
            Splat,

            BombStraight,
            BombZigZag,
            BombCross,

            Brick,
            Brick_LeftTop0,
            Brick_LeftTop1,
            Brick_LeftBottom,
            Brick_RightTop0,
            Brick_RightTop1,
            Brick_RightBottom,

            RedBird,
            YellowBird,
            GreenBird,
            WhiteBird,

            Null_Object,
            Uninitialized
        }

        public Sprite()
            : base()
        {
            this.x = 0.0f;
            this.y = 0.0f;
            this.sx = 1.0f;
            this.sy = 1.0f;
            this.angle = 0.0f;

            this.name = Name.Uninitialized;
            this.Image = null;
            //LTN - These news are use to draw one sprite only, other sprites need other news
            this.Color = new Azul.Color();
            Debug.Assert(this.Color != null);

            this.AzSprite = new Azul.Sprite();
            Debug.Assert(this.AzSprite != null);

            this.Rect = new Azul.Rect();
            Debug.Assert(this.Rect != null);
        }

        override public void Update()
        {
            this.AzSprite.x = this.x;
            this.AzSprite.y = this.y;
            this.AzSprite.sx = this.sx;
            this.AzSprite.sy = this.sy;
            this.AzSprite.angle = this.angle;
            

            this.AzSprite.Update();
        }

        override public void Render()
        { 
            this.AzSprite.Render();
        }

        public void Set(Name name, Image image, float x, float y, float width, float height, Azul.Color color)
        {
            Debug.Assert(image != null);
            Debug.Assert(Rect != null);
            Debug.Assert(this.AzSprite != null);
            Debug.Assert(this.Color != null);

            this.Image = image;
            this.name = name;

            this.Rect.Set(x, y, width, height); //Put the image on sprite

            if(color == null)
            {
                this.Color.Set(1.0f, 1.0f, 1.0f, 1.0f);
            }
            else
            {
                this.Color.Set(color);
            }

            this.AzSprite.Swap(Image.Texture.AzTexture, image.Rect, Rect, Color);
            this.AzSprite.Update();

            this.x = AzSprite.x;
            this.y = AzSprite.y;
            this.sx = AzSprite.sx;
            this.sx = AzSprite.sx;
            this.angle = AzSprite.angle;
        }

        private void DefaultSprite()
        {
            Debug.Assert(this.Color != null);
            Debug.Assert(this.AzSprite != null);

            this.x = 0.0f;
            this.y = 0.0f;
            this.sx = 1.0f;
            this.sy = 1.0f;
            this.angle = 0.0f;

            this.name = Name.Uninitialized;
            this.Image = null;

            this.Color.Set(1.0f, 1.0f, 1.0f, 1.0f);

            Image image = ImageManager.Find(Image.Name.GreenBird);
            Debug.Assert(image != null);

            this.Rect.Set(0.0f, 0.0f, 1.0f, 1.0f);
            this.AzSprite.Swap(image.GetAzulTexture(), image.Rect, Rect, Color);
            this.AzSprite.Update();
        }

        override public bool Compare(NodeBase NodeToFind)
        {
            Debug.Assert(NodeToFind != null);
            Sprite node = (Sprite)NodeToFind;
            bool status = false;
            
            if (this.name == node.name)
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
            Debug.WriteLine("This sprite is {0} ({1})", this.name, this.GetHashCode());
            Debug.WriteLine("Image: {0} ({1})", this.Image.name, this.Image.GetHashCode());
            Debug.WriteLine("AzulSprite: ({0})", this.AzSprite.GetHashCode());
            Debug.WriteLine("(x,y): {0},{1}", this.x, this.y);
            Debug.WriteLine("(sx,sy): {0},{1}", this.sx, this.sy);
            Debug.WriteLine("(angle): {0}", this.angle); 

            this.Dump();
        }

        public override void Wash()
        {
            this.DefaultSprite();
        }

        public void SwapColor(Azul.Color color)
        {
            Debug.Assert(color != null);
            Debug.Assert(this.Color != null);
            Debug.Assert(this.AzSprite != null);
            this.Color.Set(color);
            this.AzSprite.SwapColor(color);
        }

        public void SwapColor(float red, float green, float yellow, float alpha = 1.0f)
        {
            Debug.Assert(this.Color != null);
            Debug.Assert(this.AzSprite != null);
            this.Color.Set(red, green, yellow, alpha);
            this.AzSprite.SwapColor(this.Color);
        }

        public void SwapImage(Image new_image)
        {
            Debug.Assert(this.AzSprite != null);
            Debug.Assert(new_image != null);
            this.Image = new_image;
            this.AzSprite.SwapTexture(this.Image.GetAzulTexture());
            this.AzSprite.SwapTextureRect(this.Image.GetAzulRect());
            
        }

        public void Walk()
        {

            if (this.x > 1200 || this.x < 100)
            {
                this.x += -3.0f;
            }
            else this.x += 3.0f;
            
            Update();
        }

        public Azul.Rect GetRect()
        {
            Debug.Assert(this.Rect != null);
            return this.Rect;
        }
    }
}

