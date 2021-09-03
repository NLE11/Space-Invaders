
using System.Diagnostics;

namespace SpaceInvaders
{
    class DelayedObjectManager
    {
        private SLinkMAN SLinkMan;
        private static DelayedObjectManager instance = null;
        static public void Attach(CollisionObserver observer)
        {
            Debug.Assert(observer != null);
            DelayedObjectManager manager = DelayedObjectManager.GetInstance();

            manager.SLinkMan.AddFrontNode(observer);
        }

        static public void Process()
        {
            DelayedObjectManager manager = DelayedObjectManager.GetInstance();
            Iterator iterator = manager.SLinkMan.GetIterator();
            CollisionObserver node = (CollisionObserver)iterator.First();

            while (!iterator.isDone())
            {
                // Fire off listener
                node.Execute();

                node = (CollisionObserver)iterator.Next();
            }


            // remove all observers
            CollisionObserver temp = null;

            iterator = manager.SLinkMan.GetIterator();
            node = (CollisionObserver)iterator.First();

            while (!iterator.isDone())
            {
                temp = node;
                node = (CollisionObserver)iterator.Next();

                // remove
                manager.SLinkMan.DeleteNode(temp);
            }
        }
        private DelayedObjectManager()
        {
            this.SLinkMan = new SLinkMAN();
            Debug.Assert(this.SLinkMan != null);
        }

        private static DelayedObjectManager GetInstance()
        {
            // Do the initialization
            if (instance == null)
            {
                instance = new DelayedObjectManager();
            }

            // Safety - this forces users to call create first
            Debug.Assert(instance != null);

            return instance;
        }
    }
}