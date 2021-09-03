using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Splat : UFOCategory
    {
        public Splat(Sprite.Name spriteName, float posX, float posY)
        : base(GameObject.Name.UFO, spriteName, posX, posY)
        {
            this.x = posX;
            this.y = posY;

            this.SetCollisionColor(1.0f, 1.0f, 1.0f);
        }
        public void Resurrect(float posX, float posY)
        {
            this.x = posX;
            this.y = posY;

            this.SetCollisionColor(1.0f, 1.0f, 1.0f);
            base.Resurrect();
        }
        ~Splat()
        {

        }
        public override void Accept(CollisionVisitor other)
        {

        }


        public override void Update()
        {
            // Debug.WriteLine("update: {0}", this);
            base.Update();
        }

        public override void Move()
        {
        }

        public void SetPosition(float xPos, float yPos)
        {
            this.x = xPos;
            this.y = yPos;
        }

        public void Reset(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public override void Remove()
        {
            // Keenan(delete.E)
            // Since the Root object is being drawn
            // 1st set its size to zero
            this.collison_object.collision_rect.Set(0, 0, 0, 0);
            base.Update();

            // Update the parent (missile root)
            GameObject parent = (GameObject)this.parent;
            parent.Update();

            // Now remove it
            base.Remove();
        }
    }
}
