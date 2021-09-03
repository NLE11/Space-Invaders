using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class DLinkMAN : ListBase
    {
        public DLink Head; //This manager has a head pointer
        public DLinkIterator this_Iterator; //This manager has an iterator

        public DLinkMAN() //Create a head and an iterator

        {
            //LTN - Constructor
            this.this_Iterator = new DLinkIterator();
            this.Head = null;
        }

        //Override this function to use it from Listbase
        override public void AddFrontNode(NodeBase node)
        {
            //check to ensure the node to add is not null
            Debug.Assert(node != null);

            DLink current_node = (DLink)node;

            //add node
            if (Head == null)
            {
                Head = current_node;
                current_node.Next = null;
                current_node.Prev = null;
            }
            else
            {
                //if head is not null, assign this head to node.Next
                current_node.Prev = null;
                current_node.Next = Head;

                //update this node to become head
                Head.Prev = current_node;
                Head = current_node;
            }

            //Head is no longer null because now we have at least one node
            Debug.Assert(Head != null);
        }

        override public void AddEndNode(NodeBase node)
        {
            //check to ensure the node to add is not null
            Debug.Assert(node != null);

            DLink current_node = (DLink)node;

            //add node to front first
            if (Head == null)
            {
                //list has nothing so add this first node
                Head = current_node;
                current_node.Next = null;
                current_node.Prev = null;
            }
            else
            {
                //move the node just added to the end
                DLink temp = Head; //when temp move next, head stay the same
                DLink last = temp;
                while (temp != null)
                {
                    last = temp;
                    temp = temp.Next; //move temp to next node until it becomes null
                }

                //set up node at the end of linked list
                last.Next = current_node;
                current_node.Prev = last;
                current_node.Next = null;
            }
            //Head is no longer null because now we have at least one node
            Debug.Assert(Head != null);
        }

        override public void AddNodeToIndex(NodeBase node, float id)
        {
            //check to ensure the node to add is not null
            Debug.Assert(node != null);

            DLink new_node = (DLink)node;
            new_node.id = id;

            //Empty List
            if (Head == null)
            {
                Head = new_node;
                new_node.Next = null;
                new_node.Prev = null;
            }
            //Non-empty List
            else
            {
                Debug.Assert(Head != null);
                //New node is smaller than head
                if (new_node.id <= Head.id)
                {
                    //Push new node to front
                    new_node.Prev = null;
                    new_node.Next = Head;
                    Head.Prev = new_node;
                    this.Head = new_node;
                }
                //New node is bigger than head
                else
                {
                    DLink iterator = Head;
                    while (iterator != null)
                    {
                        //There's no next node after head
                        if(iterator.Next == null)
                        {
                            //Add new node after iterator
                            iterator.Next = new_node;
                            new_node.Prev = iterator;
                            new_node.Next = null;
                            break;
                        }
                        else if (iterator.Next.id > new_node.id)
                        {
                            //Put new node between iterator and iterator.next
                            new_node.Prev = iterator;
                            new_node.Next = iterator.Next;
                            iterator.Next.Prev = new_node;
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

        override public NodeBase DeleteFrontNode()
        {
            //ensure the list is not empty so we can delete something
            Debug.Assert(Head != null);

            //this is the node to be removed
            DLink current_node = Head;

            //update head
            Head = Head.Next; //next node is now head
            if (Head != null)
            {
                Head.Prev = null; //this node.Next stays the same which is 3rd node or null
            }
            else
            {
                Head = null; //no more node in this linked list
            }
            //delete the node
            current_node.Clear();

            return current_node; //we need to save this link after disconnection so that we can add value to it later
        }
        override public void DeleteNode(NodeBase node)
        {
            //ensure the linked list is not empty
            Debug.Assert(Head != null);
            Debug.Assert(node != null);
            DLink pNode = (DLink)node;

            // four cases

            if (pNode.Prev == null && pNode.Next == null)
            {   // Only node
                Head = null;
            }
            else if (pNode.Prev == null && pNode.Next != null)
            {   // First node
                Head = pNode.Next;
                pNode.Next.Prev = pNode.Prev;
            }
            else if (pNode.Prev != null && pNode.Next == null)
            {   // Last node
                pNode.Prev.Next = pNode.Next;
            }
            else // (pNode.pPrev != null && pNode.pNext != null)
            {   // Middle node
                pNode.Next.Prev = pNode.Prev;
                pNode.Prev.Next = pNode.Next;
            }
            //delete the node
            pNode.Clear();
        }

        public override Iterator GetIterator()
        {
            this_Iterator.Reset(this.Head);
            return this_Iterator;
        }
    }
}
