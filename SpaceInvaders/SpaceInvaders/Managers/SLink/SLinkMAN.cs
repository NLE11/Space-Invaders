using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SLinkMAN : ListBase
    {
        public SLink Head;
        public int head_id;
        public SLinkIterator this_Iterator;
        
        public SLinkMAN()
            : base()
        {
            //LTN - Constructor
            this.this_Iterator = new SLinkIterator();
            this.head_id = 0;
            this.Head = null;
        }
        override public void AddFrontNode(NodeBase node)
        {
            //check to ensure the node to add is not null
            Debug.Assert(node != null);

            SLink current_node = (SLink)node;
            // add node
            if (Head == null)
            {
                // push to the front
                Head = current_node;
                current_node.Next = null;
            }
            else
            {
                //update this node to become head
                current_node.Next = Head;
                Head = current_node;
            }

            //Head is no longer null because now we have at least one node
            Debug.Assert(Head != null);
        }
        override public void AddEndNode(NodeBase node)
        {
            //check to ensure the node to add is not null
            Debug.Assert(node != null);
            SLink current_node = (SLink)node;

            //add node to front first
            if (Head == null)
            {
                //list has nothing so add this first node
                Head = current_node;
                current_node.Next = null;
            }
            else
            {
                //move the node just added to the end
                SLink temp = Head;//when temp move next, head stay the same
                SLink last = Head;
                while (temp != null)
                {
                    last = temp;
                    temp = temp.Next;//move temp to next node until it becomes null
                }

                //set up node at the end of linked list
                last.Next = current_node;
                current_node.Next = null;

            }

            //Head is no longer null because now we have at least one node
            Debug.Assert(Head != null);
        }
        override public void DeleteNode(NodeBase node)
        {
            // There should always be something on list
            Debug.Assert(Head != null);
            Debug.Assert(node != null);

            SLink current_node = (SLink)node;

            if (current_node == Head)
            {   // Only node or First Node
                Head = current_node.Next;
            }
            else
            {   // middle or last (minimum of 2 nodes)
                // find node before pNode
                SLink temp = Head;
                SLink prev = Head;
                while (temp != current_node)
                {
                    prev = temp;
                    temp = temp.Next;
                }

                // prev is valid
                prev.Next = current_node.Next;
            }
            //delete the node
            current_node.Clear();
        }
        override public NodeBase DeleteFrontNode()
        {
            //ensure the list is not empty so we can delete something
            Debug.Assert(Head != null);

            //this is the node to be removed
            SLink current_node = Head;

            // Update head (OK if it points to NULL)
            Head = Head.Next;

            // remove any lingering links
            // HUGELY important - otherwise its crossed linked 
            current_node.Clear();

            return current_node;
        }

        override public Iterator GetIterator()
        {
            this_Iterator.Reset(this.Head);
            return this_Iterator;
        }

        public override void AddNodeToIndex(NodeBase node, float id)
        {
            //check to ensure the node to add is not null
            Debug.Assert(node != null);

            SLink new_node = (SLink)node;
            new_node.id = id;

            //Empty List
            if (Head == null)
            {
                Head = new_node;
                new_node.Next = null;
            }
            //Non-empty List
            else
            {
                Debug.Assert(Head != null);
                //New node is smaller than head
                if (new_node.id <= Head.id)
                {
                    //Push new node to front
                    new_node.Next = Head;
                    this.Head = new_node;
                }
                //New node is bigger than head
                else
                {
                    SLink iterator = Head;
                    while (iterator != null)
                    {
                        //There's no next node after head
                        if (iterator.Next == null)
                        {
                            //Add new node after iterator
                            iterator.Next = new_node;
                            new_node.Next = null;
                            break;
                        }
                        else if (iterator.Next.id > new_node.id)
                        {
                            //Put new node between iterator and iterator.next
                            new_node.Next = iterator.Next;
                            iterator.Next = new_node;
                            break;
                        }
                        iterator = iterator.Next;
                    }

                }
            }
            //Head is no longer null because now we have at least one node
            Debug.Assert(Head != null);
        }

    }
}
