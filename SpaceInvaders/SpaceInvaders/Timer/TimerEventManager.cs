using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class TimerEventManager : ManagerBase
    {
        private static TimerEvent NodeToCompare = new TimerEvent();
        private static TimerEventManager Instance = null;
        private static TimerEventManager ActiveTEManager = null;
        protected float Current_Time;
        
        public TimerEventManager(int reserveNum = 3, int reserveGrow = 1)
                : base(new DLinkMAN(), new DLinkMAN(), reserveNum, reserveGrow)
        {
            // initialize derived data here

            //LTN - Constructor
            TimerEventManager.ActiveTEManager = null;
        }

        public static void Create()
        {
            // initialize the singleton here
            Debug.Assert(Instance == null);

            // Do the initialization
            if (Instance == null)
            {
                //LTN - Owner is TimerEventManager
                Instance = new TimerEventManager();
            }
        }

        private static TimerEventManager GetInstance()
        {
            // Safety - this forces users to call Create() first before using class
            Debug.Assert(Instance != null);
            return Instance;
        }

        public static void Destroy()
        {
            TimerEventManager manager = TimerEventManager.ActiveTEManager;
            Debug.Assert(manager != null);

            // Do something clever here
            // track peak number of active nodes
            // print stats on destroy
            // invalidate the singleton
            manager.baseDumpNodes();
            Instance = null;
            ActiveTEManager = null;
        }

        public static TimerEvent AddToIndex(TimerEvent.Name timeName, Command Command, float deltaTimeToTrigger)
        {
            TimerEventManager manager = TimerEventManager.ActiveTEManager;

            TimerEvent node = (TimerEvent)manager.baseAddToIndex(deltaTimeToTrigger);
            Debug.Assert(node != null);

            Debug.Assert(Command != null);
            Debug.Assert(deltaTimeToTrigger >= 0.0f);

            node.Set(timeName, Command, deltaTimeToTrigger);
            return node;
        }

        public static void SetActive(TimerEventManager current_TEman)
        {
            //TimerEventManager manager = TimerEventManager.GetInstance();
            //Debug.Assert(manager != null);

            Debug.Assert(current_TEman != null);
            TimerEventManager.ActiveTEManager = current_TEman;
        }

        public static TimerEvent Find(TimerEvent.Name name)
        {
            TimerEventManager manager = TimerEventManager.ActiveTEManager;
            Debug.Assert(manager != null);

            // Compare functions only compares two Nodes

            // So:  Use the Compare Node - as a reference
            //      use in the Compare() function
            TimerEventManager.NodeToCompare.name = name;

            TimerEvent data = (TimerEvent)manager.baseFind(TimerEventManager.NodeToCompare);
            return data;
        }

        public static void Remove(TimerEvent image)
        {
            Debug.Assert(image != null);

            TimerEventManager manager = TimerEventManager.ActiveTEManager;
            Debug.Assert(manager != null);

            manager.baseRemoveNode(image);
        }
        public static void Dump()
        {
            TimerEventManager manager = TimerEventManager.ActiveTEManager;
            Debug.Assert(manager != null);

            manager.baseDumpNodes();
        }

        public static void PauseUpdate(float delta)
        {
            // Get the instance
            TimerEventManager manager = TimerEventManager.ActiveTEManager;
            Debug.Assert(manager != null);

            // walk the list
            Iterator iterator = manager.baseGetIterator();
            Debug.Assert(iterator != null);

            TimerEvent this_event = (TimerEvent)iterator.First();

            // Update the times
            while (!iterator.isDone())
            {
                this_event.triggerTime += delta;
                this_event = (TimerEvent)iterator.Next();
            }

        }

        public static void Update(float totalTime)
        {
            // Get the instance
            TimerEventManager manager = TimerEventManager.ActiveTEManager;
            Debug.Assert(manager != null);

            // squirrel away
            manager.Current_Time = totalTime;

            // walk through the list and execute
            Iterator iterator = manager.baseGetIterator();
            Debug.Assert(iterator != null);

            TimerEvent node = (TimerEvent)iterator.First();
            TimerEvent NextNode = null;

            // Walk the list until there is no more list OR currTime is greater than timeEvent 
            // ToDo Fix: List needs to be sorted then its an early out
            while (!iterator.isDone())
            {
                NextNode = (TimerEvent)iterator.Next();

                if (manager.Current_Time >= node.triggerTime)
                {
                    // call it
                    node.Process();

                    // remove from list
                    manager.baseRemoveNode(node);
                }
                else break;

                // advance the pointer
                node = NextNode;
            }
        }
        public static float GetCurrentTime()
        {
            // Get the instance
            TimerEventManager manager = TimerEventManager.ActiveTEManager;
            Debug.Assert(manager != null);

            // return time
            return manager.Current_Time;
        }

        override protected NodeBase derivedCreateNode()
        {
            //LTN - TimerEventManager owns this new event which is created from a template nodebase
            NodeBase node_base = new TimerEvent();
            Debug.Assert(node_base != null);

            return node_base;
        }
    }
}
