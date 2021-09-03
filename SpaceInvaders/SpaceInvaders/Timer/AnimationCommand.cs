using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class AnimationCommand : Command
    {
        private Sprite Sprite;
        private SLinkMAN SLinkManager;
        private Iterator Iterator;

        public AnimationCommand(Sprite.Name SpriteName)
        {
            this.Sprite = SpriteManager.Find(SpriteName);
            Debug.Assert(this.Sprite != null);

            //LTN - The manager is created to control the image nodes which are added for swaping
            this.SLinkManager = new SLinkMAN();
            Debug.Assert(this.SLinkManager != null);

            this.Iterator = this.SLinkManager.GetIterator();
            Debug.Assert(this.Iterator != null);
        }

        public void Attach(Image.Name ImageName)
        {
            Image image = ImageManager.Find(ImageName);
            Debug.Assert(image != null);

            //LTN - This create a new image node to hold an image inside the SLinkManager. This will be reused as the image in the sprite swaps.
            ImageNode image_holder = new ImageNode(image);
            Debug.Assert(image_holder != null);

            this.SLinkManager.AddFrontNode(image_holder);

            this.Iterator = this.SLinkManager.GetIterator();
        }
        public override void Execute(float deltaTime)
        {
            ImageNode image_holder = (ImageNode)this.Iterator.Current();

            if (Iterator.Next() == null)
            {
                Iterator.First();
            }
            this.Sprite.SwapImage(image_holder.image);

            TimerEventManager.AddToIndex(TimerEvent.Name.SpriteAnimation, this, deltaTime);
        }
    }
}
