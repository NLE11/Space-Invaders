using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class CompositeForwardIterator : CompositeIteratorBase
    {

        // Data 

        private Component current;
        private Component Root;
        public CompositeForwardIterator(Component Start)
        {
            Debug.Assert(Start != null);
            //Debug.Assert(Start.component_type == Component.Container.COMPOSITE);    //Can't use this because it could be a LEAF

            this.current = Start;
            this.Root = Start;
        }
        override public Component Current()
        {
            return this.current;
        }
        override public Component First()
        {
            Debug.Assert(this.Root != null);
            Component node = this.Root;

            Debug.Assert(node != null);
            this.current = node;

            //Debug.WriteLine("This Component Node is {0} ", this.current.GetHashCode());
            return this.current;
        }

        override public Component Next()
        {
            Debug.Assert(this.current != null);

            Component node = this.current;

            Component child_node = GetChild(node);
            Component sibling_node = GetSibling(node);
            Component parent_node = GetParent(node);

            // Start - Depth first iteration
            node = this.NextNode(node, parent_node, child_node, sibling_node);

            this.current = node;

            return this.current;
        }

        override public bool isDone()
        {
            return (this.current == null);
        }

        // Support functions
        private Component NextNode(Component node, Component parent_node, Component child_node, Component sibling_node)
        {
            node = null;

            if (child_node != null)
            {
                node = child_node;
            }
            else
            {
                if (sibling_node != null)
                {
                    node = sibling_node;
                }
                else
                {
                    // No more 
                    //       siblings... 
                    //       children...
                    // Go up a level to the parent

                    while (parent_node != null)
                    {
                        node = GetSibling(parent_node);
                        if (node != null)
                        {
                            // Found one
                            break;
                        }
                        else
                        {
                            // Go find grandparent
                            parent_node = GetParent(parent_node);
                        }
                    }
                }
            }

            return node;
        }

        static public Component GetParent(Component node)
        {
            Debug.Assert(node != null);

            return node.parent;

        }
        static public Component GetChild(Component node)
        {
            Debug.Assert(node != null);

            Component child_node;

            if (node.component_type == Component.Container.COMPOSITE)
            {
                child_node = ((Composite)node).GetHead();
            }
            else
            {
                child_node = null;
            }

            return child_node;
        }
        static public Component GetSibling(Component node)
        {
            Debug.Assert(node != null);

            return (Component)node.Next;
        }
    }
}
