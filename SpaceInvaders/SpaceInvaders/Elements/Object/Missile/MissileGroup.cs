using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class MissileGroup : Composite
    {
        public MissileGroup()
            : base()
        {
            this.name = Name.MissileGroup;
            this.collison_object.CollisionSpriteBox.SetColor(0, 0, 1);
        }

        ~MissileGroup()
        {

        }

        public override void Accept(CollisionVisitor other)
        {
            // Important: at this point we have an MissileGroup
            // Call collision reaction            
            other.VisitMissileGroup(this);
        }

        public override void Update()
        {
            // Go to first child
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }
    }
}
