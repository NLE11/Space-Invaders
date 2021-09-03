using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class TimedCharCommand : Command
    {

        // Data
        private string Letter;
        private float x;
        private float y;
        private float red;
        private float green;
        private float blue;
        private Font Font;
        private TimedCharCommand Command;
        public TimedCharCommand(TimedCharCommand command, string letter, float xPosition, float yPosition, float _red, float _green, float _blue)
        {
            this.Letter = letter;
            this.x = xPosition;
            this.y = yPosition;
            this.red = _red;
            this.green = _green;
            this.blue = _blue;
            this.Font = null;
            this.Command = command;

            if (this.Command != null)
            {
                //Debug.WriteLine(" New Command: {0} ----- Old Command:{1}", this.GetHashCode(), this.Command.GetHashCode());
            }
            else
            {
                //Debug.WriteLine(" New Command: {0} ----- Old Command:{1}", this.GetHashCode(), "null");

            }
        }
        override public void Execute(float deltaTime)
        {
            //Debug.WriteLine("Execution starts: {0} ", this.GetHashCode());

            // New one
            Font font = FontManager.Add(Font.Name.TimedChar,
                                     SpriteBatch.Name.Texts,
                                     this.Letter,
                                     Glyph.Name.Consolas36pt,
                                     this.x,
                                     this.y);

            font.SetColor(red, green, blue);
            this.Font = font;

            //Debug.WriteLine("Execution exits: {0} Message's Font: {1}", this.GetHashCode(), this.Font.GetHashCode());

            // Get rid of the old one 
            if (this.Command != null)
            {
                //Debug.WriteLine("     Remove Old Command: {0}", this.Command.GetHashCode());
                FontManager.Remove(this.Command.Font);
            }
        }
    }
}
