using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SpriteFont : SpriteBase
    {
        public Font.Name name;
        private Azul.Sprite AzulSprite;
        private Azul.Rect ScreenRect;
        private Azul.Color Color;   // this color is multplied by the texture

        private string Message;
        public Glyph.Name glyphName;

        public float x;
        public float y;

        // Enum
        public enum Name
        {
            Squid1, Squid2,
            Crab1, Crab2,
            Crab3, Crab4,
            Octopus1, Octopus2,
            Octopus3, Octopus4,

            RedBird,
            YellowBird,
            GreenBird,
            WhiteBird,

            Null_Object,
            Uninitialized
        }

        // Constructor
        public SpriteFont()
            : base()
        {
            // Create empty sprite

            this.AzulSprite = new Azul.Sprite();
            this.ScreenRect = new Azul.Rect();
            this.Color = new Azul.Color(1.0f, 1.0f, 1.0f);

            this.Message = null;
            this.glyphName = Glyph.Name.Uninitialized;

            this.x = 0.0f;
            this.y = 0.0f;
        }

        public void Set(Font.Name name, String Message, Glyph.Name glyphName, float xStart, float yStart)
        {
            Debug.Assert(Message != null);
            this.Message = Message;

            this.x = xStart;
            this.y = yStart;

            this.name = name;

            // TODO: for wash... this should be a nullGlyph
            this.glyphName = glyphName;

            // White Color for Font
            Debug.Assert(this.Color != null);
            this.Color.Set(1.0f, 1.0f, 1.0f);
        }

        public void SetColor(float red, float green, float blue, float alpha = 1.0f)
        {
            Debug.Assert(this.Color != null);
            this.Color.Set(red, green, blue, alpha);
        }

        public void UpdateMessage(String message)
        {
            Debug.Assert(message != null);
            this.Message = message;
        }

        override public void Update()
        {
            Debug.Assert(this.AzulSprite != null);
        }

        override public void Render()
        {
            Debug.Assert(this.AzulSprite != null);
            Debug.Assert(this.Color != null);
            Debug.Assert(this.ScreenRect != null);
            Debug.Assert(this.Message != null);
            Debug.Assert(this.Message.Length > 0);

            float xTmp = this.x;
            float yTmp = this.y;

            float xEnd = this.x;

            for (int i = 0; i < this.Message.Length; i++)
            {
                int key = Convert.ToByte(Message[i]);

                Glyph pGlyph = GlyphManager.Find(this.glyphName, key);
                Debug.Assert(pGlyph != null);

                xTmp = xEnd + pGlyph.GetAzulRect().width / 2;
                this.ScreenRect.Set(xTmp, yTmp, pGlyph.GetAzulRect().width, pGlyph.GetAzulRect().height);

                AzulSprite.Swap(pGlyph.GetAzulTexture(), pGlyph.GetAzulRect(), this.ScreenRect, this.Color);

                AzulSprite.Update();
                AzulSprite.Render();

                // move the starting to the next character
                xEnd = pGlyph.GetAzulRect().width / 2 + xTmp;
            }
        }

        private void Clear()
        {
            Debug.Assert(this.AzulSprite != null);
            Debug.Assert(this.Color != null);
            Debug.Assert(this.ScreenRect != null);

            this.ScreenRect.Set(0, 0, 0, 0);
            this.Color.Set(1.0f, 1.0f, 1.0f);

            this.Message = null;
            this.glyphName = Glyph.Name.Uninitialized;

            this.x = 0.0f;
            this.y = 0.0f;
        }

        public override object GetName()
        {
            return this.name;
        }

        override public void Wash()
        {
            this.Clear();
        }

        override public bool Compare(NodeBase node_to_fine)
        { 
            Debug.Assert(node_to_fine != null);

            SpriteFont data = (SpriteFont)node_to_fine;

            bool status = false;

            if (this.name == data.name)
            {
                status = true;
            }

            return status;
        }

        override public void Dump()
        {
            Debug.WriteLine("This sprite font is:   {0} ({1})", this.name, this.GetHashCode());

            base.Dump();
        }
    }
}


