using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class GameObjectNode : DLink
    {

        // Data
        public GameObject GameObject;

        // Constructor
        public GameObjectNode()
            : base()
        {
            this.Clear();
        }

        public void Set(GameObject game_object)
        {
            Debug.Assert(game_object != null);
            this.GameObject = game_object;
        }

        private void Clear()
        {
            this.GameObject = null;
        }
        
        //Override
        public override object GetName()
        {
            Debug.Assert(this.GameObject != null);

            return this.GameObject.GetName();
        }

        override public void Wash()
        {
            this.Clear();
        }

        override public bool Compare(NodeBase NodeToFind)
        {
            // This is used in ManBase.Find() 
            Debug.Assert(NodeToFind != null);

            GameObjectNode node = (GameObjectNode)NodeToFind;

            bool status = false;

            Debug.Assert(node.GameObject != null);
            Debug.Assert(this.GameObject != null);

            if (this.GameObject.name == node.GameObject.name)
            {
                status = true;
            }

            return status;
        }

        override public void Dump()
        {
            // we are using HASH code as its unique identifier 
            Debug.WriteLine("GameObjectNode: ({0})", this.GetHashCode());

            // Data:
            if (this.GameObject != null)
            {
                Debug.WriteLine("   GameObject.name: {0} ({1})", this.GameObject.GetName(), this.GameObject.GetHashCode());
            }
            else
            {
                Debug.WriteLine("   GameObject.name: null");
            }

            base.Dump();
        }
    }
}
