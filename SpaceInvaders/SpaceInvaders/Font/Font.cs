using System.Diagnostics;

namespace SpaceInvaders
{
    public class Font : DLink
    {

        // Data
        public Name name;
        public SpriteFont SpriteFont;
        static private string NullString = "null";

        // Enum
        public enum Name
        {
            TestMessage,
            TestOneOff,
            ScoreBoard,
            ScoreBoard1,
            ScoreBoard2,
            ScoreBoardMax,

            TimedChar,

            NullObject,
            Uninitialized
        }

        // Constructor

        public Font()
        {
            this.name = Name.Uninitialized;
            this.SpriteFont = new SpriteFont();
        }

        //---------------------------------------------------------------------------------------------------------
        // Methods
        //---------------------------------------------------------------------------------------------------------

        public void Set(Font.Name name, string pMessage, Glyph.Name glyphName, float xStart, float yStart)
        {
            Debug.Assert(pMessage != null);

            this.name = name;
            this.SpriteFont.Set(name, pMessage, glyphName, xStart, yStart);
        }


        public void UpdateMessage(string pMessage)
        {
            Debug.Assert(pMessage != null); 
            Debug.Assert(this.SpriteFont != null);
            this.SpriteFont.UpdateMessage(pMessage);
        }

        public void SetColor(float red, float green, float blue)
        {
            this.SpriteFont.SetColor(red, green, blue);
        }

        private void Clear()
        {
            this.name = Name.Uninitialized;
            this.SpriteFont.Set(Font.Name.NullObject, NullString, Glyph.Name.Null_Object, 0.0f, 0.0f);
        }

        public override object GetName()
        {
            return this.name;
        }

        override public void Wash()
        {
            this.Clear();
        }

        override public bool Compare(NodeBase node_to_find)
        {

            Debug.Assert(node_to_find != null);

            Font data = (Font)node_to_find;

            bool status = false;

            if (this.name == data.name)
            {
                status = true;
            }

            return status;
        }

        override public void Dump()
        {
            Debug.WriteLine("This font is:   {0} ({1})", this.name, this.GetHashCode());

            base.Dump();
        }
    }
}