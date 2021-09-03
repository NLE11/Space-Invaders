using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class Component : CollisionVisitor
    {
        // Data
        public Container component_type;
        public Component parent;
        public Component reverse;

        public enum Container
        {
            LEAF,
            COMPOSITE,
            Unknown
        }

        public Component(Component.Container component_type)
        {
            this.component_type = component_type;
            this.parent = null;
            this.reverse = null;
        }

        public virtual void Resurrect()
        {
            this.parent = null;
            this.reverse = null;
        }

        public abstract void Print();
        public abstract void Add(Component component);
        public abstract void Remove(Component c);
        public abstract void DumpNode();
        public abstract void Move();
    }
}
