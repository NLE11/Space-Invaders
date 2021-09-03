using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class Composite : GameObject
    {
        public DLinkMAN DMan;
        public Composite()
            : base(Component.Container.COMPOSITE,
                  GameObject.Name.Null_Object,
                  Sprite.Name.Null_Object,
                  SpriteBox.Name.Null_Object)
        {
            this.DMan = new DLinkMAN();
        }
        public Composite(GameObject.Name gameName,
                            Sprite.Name spriteName,
                            SpriteBox.Name spriteboxName)
            : base(Component.Container.COMPOSITE,
                    gameName,
                    spriteName,
                    spriteboxName)
        {
            this.DMan = new DLinkMAN();
        }

        public override void Resurrect()
        {
            // check the DLinkMan
            Debug.Assert(this.DMan.Head == null);

            base.Resurrect();
        }

        override public void Add(Component component)
        {
            Debug.Assert(component != null);
            Debug.Assert(this.DMan != null);
            this.DMan.AddFrontNode(component);

            component.parent = this;

            //GameObjectNodeManager.Attach((GameObject)component);
        }

        public Component GetHead()
        {
            Debug.Assert(this.DMan != null);
            Component head = (GameObject)this.DMan.Head;
            return head;
        }

        override public void Remove(Component component)
        {
            Debug.Assert(component != null);
            Debug.Assert(this.DMan != null);
            this.DMan.DeleteNode(component);
        }

        public override void Move()
        {
            // walk through the list and render
            Iterator iterator = this.DMan.GetIterator();
            Debug.Assert(iterator != null);

            GameObject pNode = (GameObject)iterator.First();

            // Walk through the nodes
            while (!iterator.isDone())
            {
                // Update the node
                Debug.Assert(pNode != null);

                pNode.Move();

                pNode = (GameObject)iterator.Next();
            }
        }

        public override void Print()
        {
            Debug.WriteLine("");
            Debug.WriteLine("Composite:");

            // walk through the list and render
            Iterator iterator = this.DMan.GetIterator();
            Debug.Assert(iterator != null);

            GameObject pNode = (GameObject)iterator.First();

            // Walk through the nodes
            while (!iterator.isDone())
            {
                // Update the node
                Debug.Assert(pNode != null);

                pNode.Print();

                pNode = (GameObject)iterator.Next();
            }
        }

        public override void Wash()
        {
            // shouldn't be called
            Debug.Assert(false);
        }

        override public void DumpNode()
        {
            if (CompositeForwardIterator.GetParent(this) != null)
            {
                Debug.WriteLine(" GameObject Name:({0}) parent:{1} <---- Composite", this.GetHashCode(), CompositeForwardIterator.GetParent(this).GetHashCode());
            }
            else
            {
                Debug.WriteLine(" GameObject Name:({0}) parent:null <---- Composite", this.GetHashCode());
            }
        }
    }
}
