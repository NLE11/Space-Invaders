using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class CompositeReverseIterator : CompositeIteratorBase
    {

        private Component Current_Node;
        private Component Root;
        private Component Previous;

        public CompositeReverseIterator(Component Start)
        {

            Debug.Assert(Start != null);
            //Debug.Assert(Start.component_type == Component.Container.COMPOSITE);

            // Horrible HACK need to clean up.. but its late
            CompositeForwardIterator Forward = new CompositeForwardIterator(Start);

            this.Root = Start;
            this.Current_Node = this.Root;
            this.Previous = null;

            Component Previous_Node = this.Root;

            // Initialize the reverse pointer
            Component Node = Forward.First();

            while (!Forward.isDone())
            {
                // Squirrel away
                Previous_Node = Node;

                // Advance
                Node = Forward.Next();

                if (Node != null)
                {
                    Node.reverse = Previous_Node;
                }
            }

            Root.reverse = Previous_Node;

        }

        override public Component First()
        {
            Debug.Assert(this.Root != null);

            this.Current_Node = this.Root.reverse;

            return this.Current_Node;
        }
        override public Component Current()
        {
            return this.Current_Node;
        }
        override public Component Next()
        {
            Debug.Assert(this.Current_Node != null);

            this.Previous = this.Current_Node;
            this.Current_Node = this.Current_Node.reverse;
            return this.Current_Node;
        }

        override public bool isDone()
        {
            return (this.Previous == this.Root);
        }
    }
}
