using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class GridObserver : CollisionObserver
    {
        public GridObserver()
        {

        }
        public override void Notify()
        {
            //Debug.WriteLine("Grid_Observer: {0} {1}", this.Subject.Object_A, this.Subject.Object_B);

            //AlienGrid grid = (AlienGrid)this.Subject.Object_A;

            //WallCategory wall = (WallCategory)this.Subject.Object_B;
            //if (wall.GetCategoryType() == WallCategory.Type.Right)
            //{
            //    grid.SetDelta(-2.0f);
            //}
            //else if (wall.GetCategoryType() == WallCategory.Type.Left)
            //{
            //    grid.SetDelta(2.0f);
            //}
            //else
            //{
            //    Debug.Assert(false);
            //}

        }
    }
}