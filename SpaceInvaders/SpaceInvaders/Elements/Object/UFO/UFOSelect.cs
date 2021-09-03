using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class UFOSelect : UFOCategory
    {
        public float UFOSpeed;
        public UFOSelect(Sprite.Name spriteName, float posX, float posY)
        : base(GameObject.Name.UFO, spriteName, posX, posY)
        {
            this.x = posX;
            this.y = posY;

            this.UFOSpeed = 3.0f;

            this.collison_object.CollisionSpriteBox.SetColor(1, 1, 0);
        }
        public void Resurrect(float posX, float posY)
        {
            this.x = posX;
            this.y = posY;
            this.UFOSpeed = 3.0f;

            base.Resurrect();
            this.collison_object.CollisionSpriteBox.SetColor(1, 1, 0);
        }
        ~UFOSelect()
        {

        }
        public override void Accept(CollisionVisitor other)
        {
            // Important: at this point we have an RedBird
            // Call the appropriate collision reaction            
            other.VisitUFOSelect(this);
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
