using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class CollisionObject
    {
        // This Collision object holds a SpriteBox around it
        public SpriteBox CollisionSpriteBox;  
        public CollisionRect collision_rect;
        public CollisionObject(SpriteProxy SpriteProxy)
        {
            Debug.Assert(SpriteProxy != null);

            // Create Collision Rectangle around the object
            // Use the reference sprite to set size and shape
            Sprite Sprite = SpriteProxy.Sprite;
            Debug.Assert(Sprite != null);

            // Origin is in the UPPER RIGHT 
            if (Sprite != null)
            {
                this.collision_rect = new CollisionRect(Sprite.GetRect());
                Debug.Assert(this.collision_rect != null);



                // Create the spritebox around the sprite
                this.CollisionSpriteBox = SpriteBoxManager.Add(SpriteBox.Name.Box, this.collision_rect.x, this.collision_rect.y, this.collision_rect.width, this.collision_rect.height);
                Debug.Assert(this.CollisionSpriteBox != null);
                this.CollisionSpriteBox.SetColor(1.0f, 0.0f, 0.0f);
            }
        }

        public void UpdatePosition(float x, float y)
        {
            // Note we are not considering angle or scale at this time

            this.collision_rect.x = x;
            this.collision_rect.y = y;

            this.CollisionSpriteBox.x = this.collision_rect.x;
            this.CollisionSpriteBox.y = this.collision_rect.y;


            this.CollisionSpriteBox.SetRect(this.collision_rect.x, this.collision_rect.y, this.collision_rect.width, this.collision_rect.height);
            this.CollisionSpriteBox.Update();
        }
    }
}
