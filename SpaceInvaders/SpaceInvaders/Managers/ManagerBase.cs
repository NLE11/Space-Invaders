using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class ManagerBase
    {
        private ListBase Active;
        private ListBase Reserve;
        private int DeltaGrow;
        private int numTotal;
        private int numReserve;
        private int numActive;

        public ManagerBase(ListBase _Active, ListBase _Reserve, int InitNumReserved = 5, int _DeltaGrow = 2)
        {
            Debug.Assert(_Active != null);
            Debug.Assert(_Reserve != null);
            Debug.Assert(InitNumReserved >= 0);
            Debug.Assert(DeltaGrow >= 0);

            this.Active = _Active;
            this.Reserve = _Reserve;
            this.numTotal = 0;
            this.numActive = 0;
            this.numReserve = 0;
            this.DeltaGrow = _DeltaGrow;

            this.addtoReserve(InitNumReserved);
        }

        private void addtoReserve(int num)
        {
            //ensure the number of links to be refilled larger than zero
            Debug.Assert(num > 0);
            this.numTotal += num;
            this.numReserve += num;

            for (int i = 0; i < num; i++)
            {
                //create new node
                NodeBase node = this.derivedCreateNode();
                Debug.Assert(node != null);
                Reserve.AddFrontNode(node); //add this new node to reserved list
            }
        }

        abstract protected NodeBase derivedCreateNode();
        //abstract protected bool derivedCompare(NodeBase NodeA, NodeBase NodeB);

        protected void SetReserve(int NumReserve, int ReserveGrow)
        {
            this.DeltaGrow = ReserveGrow;

            if (ReserveGrow > this.numReserve)
            {
                this.addtoReserve(NumReserve - this.numReserve);
            }
        }

        public NodeBase baseAddToFront()
        {
            Iterator iterator = Reserve.GetIterator();
            Debug.Assert(iterator != null);

            //check if reverse list is null, we can't take from it if it's null
            if (iterator.First() == null) //first node in Reserve is null, that means no node exists in this list
            {
                //refill reverse list with Delta Grow if it's null
                this.addtoReserve(this.DeltaGrow);
            }

            //take from reverse list
            NodeBase node_base = Reserve.DeleteFrontNode();
            Debug.Assert(node_base != null); //ensure the node taken is not null

            //Wash node
            node_base.Wash();

            //update status
            this.numActive++;
            this.numReserve--;

            //now we copy the node to active list
            Active.AddFrontNode(node_base);

            return node_base;
        }

        public NodeBase baseAddToIndex(float id)
        {
            Iterator iterator = Reserve.GetIterator();
            Debug.Assert(iterator != null);

            //check if reverse list is null, we can't take from it if it's null
            if (iterator.First() == null) //first node in Reserve is null, that means no node exists in this list
            {
                //refill reverse list with Delta Grow if it's null
                this.addtoReserve(this.DeltaGrow);
            }

            //take from reverse list
            NodeBase node_base = Reserve.DeleteFrontNode();
            Debug.Assert(node_base != null); //ensure the node taken is not null

            //Wash node
            node_base.Wash();

            //update status
            this.numActive++;
            this.numReserve--;

            //now we copy the node to active list
            Active.AddNodeToIndex(node_base, id);

            return node_base;
        }

        public NodeBase baseAddToIndexWithExistingNode(NodeBase node, int id)
        {
            Iterator iterator = Reserve.GetIterator();
            Debug.Assert(iterator != null);

            //check if reverse list is null, we can't take from it if it's null
            if (iterator.First() == null) //first node in Reserve is null, that means no node exists in this list
            {
                //refill reverse list with Delta Grow if it's null
                this.addtoReserve(this.DeltaGrow);
            }

            //take from reverse list
            NodeBase node_base = Reserve.DeleteFrontNode();
            Debug.Assert(node_base != null); //ensure the node taken is not null

            //Wash node
            node_base.Wash();

            //update status
            this.numActive++;
            this.numReserve--;

            //now we copy the node to active list
            Active.AddNodeToIndex(node, id);

            return node;
        }

        public NodeBase baseAddToEnd()
        {
            Iterator iterator = Reserve.GetIterator();
            Debug.Assert(iterator != null);

            //check if reverse list is null, we can't take from it if it's null
            if (iterator.First() == null)
            {
                //refill reverse list with Delta Grow if it's null
                this.addtoReserve(this.DeltaGrow);
            }

            //take from reverse list
            NodeBase node_base = Reserve.DeleteFrontNode();
            Debug.Assert(node_base != null); //ensure the link taken is not null

            //Wash node
            node_base.Wash();

            //update status
            this.numActive++;
            this.numReserve--;


            //now we copy the node to active list
            Active.AddEndNode(node_base);

            return node_base;
        }

        protected Iterator baseGetIterator()
        {
            return Active.GetIterator();
        }

        protected NodeBase baseFind(NodeBase NodetoFind)
        {
            //set active list
            Iterator iterator = Active.GetIterator();
            NodeBase node = iterator.First();

            //iterate active list to find node
            while (!iterator.isDone())
            {
                if (node.Compare(NodetoFind))
                {
                    break;
                }
                node = iterator.Next();
            }

            return node;
        }

        //remove a node from active list and send it back to reserve list
        public void baseRemoveNode(NodeBase node)
        {
            Debug.Assert(node != null);

            //delete node in active_list
            Active.DeleteNode(node);

            //wash the data in the node
            node.Wash();

            //add this link back to reserve list
            Reserve.AddFrontNode(node);

            //update status
            this.numActive--;
            this.numReserve++;
        }

        public void baseDumpNodes() //print infor of 2 lists and nodes in lists
        {
            Debug.WriteLine("BEGIN\n");
            Debug.WriteLine("Manager is running\n");
            Debug.WriteLine("Delta Grow: {0}\n", DeltaGrow);
            Debug.WriteLine("Total Nodes: {0}\n", numTotal);
            Debug.WriteLine("Active Nodes: {0}\n", numActive);
            Debug.WriteLine("Reserved Nodes: {0}\n", numReserve);

            //Iterator Active_iterator = Active.GetIterator();
            ////Debug.Assert(Active_iterator != null);
            //Iterator Reserve_iterator = Reserve.GetIterator();
            ////Debug.Assert(Reserve_iterator != null);

            //NodeBase Active_node = Active_iterator.First();
            //NodeBase Reserve_node = Reserve_iterator.First();

            ////Check the head of 2 lists
            //if (Active_node == null)
            //{
            //    Debug.WriteLine("Active Head: Null\n");
            //}
            //else
            //{
            //    Debug.WriteLine("Active Head: ({0})\n", Active_node.GetHashCode());
            //}

            //if (Reserve_node == null)
            //{
            //    Debug.WriteLine("Reserved Head: Null\n");
            //}
            //else
            //{
            //    Debug.WriteLine("Reserved Head: ({0}) \n", Reserve_node.GetHashCode());
            //}

            ////Print the node in Active List
            //Debug.WriteLine("Active List: \n");

            //int i = 0;
            //NodeBase iterated_data = Active_iterator.First();
            //while (!Active_iterator.isDone())
            //{
            //    Debug.WriteLine("Node {0}:\n", i);
            //    iterated_data.Dump();
            //    Debug.WriteLine("\n");
            //    i++;
            //    iterated_data = Active_iterator.Next(); //move to next node
            //}

            //Debug.WriteLine("Reserved List: \n");

            //int y = 0;
            //iterated_data = Reserve_iterator.First();
            //while (!Reserve_iterator.isDone())
            //{
            //    Debug.WriteLine("Node {0}:\n", y);
            //    iterated_data.Dump();
            //    Debug.WriteLine("\n");
            //    y++;
            //    iterated_data = Reserve_iterator.Next(); //move to next node
            //}

            Debug.WriteLine("THE END");
        } 
    }
}
