using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SpriteBox : SpriteBase
    {
        public float x;
        public float y;
        public float sx;
        public float sy;
        public float angle;

        public Name name;
        public Azul.Color BoxColor;
        private Azul.SpriteBox AzulSpriteBox;

        static private Azul.Rect Rect = new Azul.Rect();

        public enum Name
        {
            Box,
            Box1,
            Box2,
            Box3,
            Box4,

            Null_Object,
            Uninitialized
        }

        //Constructor

        public SpriteBox()
            : base()
        {
            //Set name when box is created
            this.name = SpriteBox.Name.Uninitialized;

            Debug.Assert(SpriteBox.Rect != null);
            SpriteBox.Rect.Set(0, 0, 1, 1);

            //Set color
            //STN - This news are for drawing one box only. Other box with different color need different news
            this.BoxColor = new Azul.Color(1, 1, 1);
            Debug.Assert(this.BoxColor != null);

            this.AzulSpriteBox = new Azul.SpriteBox(Rect, this.BoxColor);
            Debug.Assert(this.AzulSpriteBox != null);

            this.x = AzulSpriteBox.x;
            this.y = AzulSpriteBox.y;
            this.sx = AzulSpriteBox.sx;
            this.sy = AzulSpriteBox.sy;
            this.angle = AzulSpriteBox.angle;
        }

        //Decor box
        public void Set(SpriteBox.Name name, float x, float y, float width, float height, Azul.Color BColor)
        {
            Debug.Assert(this.AzulSpriteBox != null);
            Debug.Assert(this.BoxColor != null);

            Debug.Assert(Rect != null);
            SpriteBox.Rect.Set(x, y, width, height);

            this.name = name;

            if (BColor == null)
            {
                this.BoxColor.Set(1, 1, 1);
            }
            else
            {
                this.BoxColor.Set(BColor);
            }

            this.AzulSpriteBox.Swap(Rect, this.BoxColor);

            this.x = AzulSpriteBox.x;
            this.y = AzulSpriteBox.y;
            this.sx = AzulSpriteBox.sx;
            this.sy = AzulSpriteBox.sy;
            this.angle = AzulSpriteBox.angle;
        }

        public void Set(SpriteBox.Name name, float x, float y, float width, float height)
        {
            Debug.Assert(this.AzulSpriteBox != null);
            Debug.Assert(this.BoxColor != null);

            Debug.Assert(Rect != null);
            SpriteBox.Rect.Set(x, y, width, height);

            this.name = name;

            this.AzulSpriteBox.Swap(Rect, this.BoxColor);

            this.x = AzulSpriteBox.x;
            this.y = AzulSpriteBox.y;
            this.sx = AzulSpriteBox.sx;
            this.sy = AzulSpriteBox.sy;
            this.angle = AzulSpriteBox.angle;
        }

        public void SetRect(float x, float y, float width, float height)
        {
            this.Set(this.name, x, y, width, height);
        }

        public void SetColor(float red, float green, float blue, float alpha = 1.0f)
        {
            Debug.Assert(this.BoxColor != null);
            this.BoxColor.Set(red, green, blue, alpha);
            this.AzulSpriteBox.SwapColor(this.BoxColor);
        }

        private void Clear()
        {
            this.name = SpriteBox.Name.Uninitialized;

            this.BoxColor.Set(1, 1, 1);

            this.x = 0.0f;
            this.y = 0.0f;
            this.sx = 1.0f;
            this.sy = 1.0f;
            this.angle = 0.0f;
        }

        public void SwapColor(Azul.Color BColor)
        {
            Debug.Assert(BColor != null);
            this.AzulSpriteBox.SwapColor(BColor);
        }

        public override object GetName()
        {
            return this.GetName();
        }

        public override void Render()
        {
            this.AzulSpriteBox.Render();
        }

        public override void Update()
        {
            this.AzulSpriteBox.x = this.x;
            this.AzulSpriteBox.y = this.y;
            this.AzulSpriteBox.sx = this.sx;
            this.AzulSpriteBox.sy = this.sy;
            this.AzulSpriteBox.angle = this.angle;

            this.AzulSpriteBox.Update();
        }

        public override void Wash()
        {
            this.Clear();
        }

        public override bool Compare(NodeBase NodeToFind)
        {
            Debug.Assert(NodeToFind != null);

            SpriteBox node = (SpriteBox)NodeToFind;

            bool status = false;

            if (this.name == node.name)
            {
                status = true;
            }

            return status;
        }

        public override void Dump()
        {
            Debug.WriteLine("Box Name: {0} ({1})", this.name, this.GetHashCode());
            Debug.WriteLine("Color(r,g,b): {0}, {1}, {2}, ({3})", this.BoxColor.red, this.BoxColor.green, this.BoxColor.blue, this.BoxColor.GetHashCode());
            Debug.WriteLine("AzulSprite: ({0})", this.AzulSpriteBox.GetHashCode());
            Debug.WriteLine("x, y, sx, sy: {0}, {1}, {2}, {3}", this.x, this.y, this.sx, this.sy);
            Debug.WriteLine("angle: {0}", this.angle);

            base.Dump();
        }
    }
}
