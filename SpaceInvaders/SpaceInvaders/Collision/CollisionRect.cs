using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class CollisionRect : Azul.Rect
    {
        // Constructor
        public CollisionRect(float x, float y, float width, float height)
            : base(x, y, width, height)
        {
        }
        public CollisionRect(Azul.Rect Rect)
            : base(Rect)
        {
        }
        public CollisionRect(CollisionRect Rect)
            : base(Rect)
        {
        }
        public CollisionRect()
            : base()
        {
        }

        // Check if intersect
        static public bool Intersect(CollisionRect CollisionRectA, CollisionRect CollisionRectB)
        {
            bool status = false;

            float A_minx = CollisionRectA.x - CollisionRectA.width / 2;
            float A_maxx = CollisionRectA.x + CollisionRectA.width / 2;
            float A_miny = CollisionRectA.y - CollisionRectA.height / 2;
            float A_maxy = CollisionRectA.y + CollisionRectA.height / 2;

            float B_minx = CollisionRectB.x - CollisionRectB.width / 2;
            float B_maxx = CollisionRectB.x + CollisionRectB.width / 2;
            float B_miny = CollisionRectB.y - CollisionRectB.height / 2;
            float B_maxy = CollisionRectB.y + CollisionRectB.height / 2;

            // Trivial reject
            if ((B_maxx < A_minx) || (B_minx > A_maxx) || (B_maxy < A_miny) || (B_miny > A_maxy))
            {
                status = false;
            }
            else
            {
                status = true;
            }

            return status;
        }

        public void Union(CollisionRect CollisionRect)
        {
            float minX;
            float minY;
            float maxX;
            float maxY;

            if ((this.x - this.width / 2) < (CollisionRect.x - CollisionRect.width / 2))
            {
                minX = (this.x - this.width / 2);
            }
            else
            {
                minX = (CollisionRect.x - CollisionRect.width / 2);
            }

            if ((this.x + this.width / 2) > (CollisionRect.x + CollisionRect.width / 2))
            {
                maxX = (this.x + this.width / 2);
            }
            else
            {
                maxX = (CollisionRect.x + CollisionRect.width / 2);
            }

            if ((this.y + this.height / 2) > (CollisionRect.y + CollisionRect.height / 2))
            {
                maxY = (this.y + this.height / 2);
            }
            else
            {
                maxY = (CollisionRect.y + CollisionRect.height / 2);
            }

            if ((this.y - this.height / 2) < (CollisionRect.y - CollisionRect.height / 2))
            {
                minY = (this.y - this.height / 2);
            }
            else
            {
                minY = (CollisionRect.y - CollisionRect.height / 2);
            }

            this.width = (maxX - minX);
            this.height = (maxY - minY);
            this.x = minX + this.width / 2;
            this.y = minY + this.height / 2;
        }
    }
}
