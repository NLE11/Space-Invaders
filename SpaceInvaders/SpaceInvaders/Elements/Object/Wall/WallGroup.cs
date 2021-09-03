using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class WallGroup : Composite
    {
        public WallGroup(GameObject.Name name, Sprite.Name spriteName, SpriteBox.Name spriteboxName, float posX, float posY)
            : base(name, spriteName, spriteboxName)
        {
            this.x = posX;
            this.y = posY;

            this.collison_object.CollisionSpriteBox.SetColor(1, 1, 1);

            this.name = name;
        }

        ~WallGroup()
        {

        }

        public override void Accept(CollisionVisitor other)
        {
            // Important: at this point we have an Alien
            // Call collision reaction            
            other.VisitWallGroup(this);
        }
        public override void Update()
        {
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }

        public override void VisitGrid(AlienGrid alien_grid)
        {
            // AlienGroup v WallGroup
            Debug.WriteLine("collide: {0} with {1}", alien_grid, this);

            // AlienGroup vs WallGroup
            //              go down a level in Wall Group.
            GameObject game_object = (GameObject)CompositeForwardIterator.GetChild(this);
            CollisionPair.Collide(alien_grid, game_object);
        }

        public override void VisitMissileGroup(MissileGroup m)
        {
            // MissileRoot vs WallRoot
            GameObject game_object = (GameObject)CompositeForwardIterator.GetChild(m);
            CollisionPair.Collide(game_object, this);
        }

        public override void VisitMissile(Missile m)
        {
            // Missile vs WallRoot
            GameObject game_object = (GameObject)CompositeForwardIterator.GetChild(this);
            CollisionPair.Collide(m, game_object);
        }

        public override void VisitBombRoot(BombRoot m)
        {
            // BombRoot vs WallRoot
            GameObject game_object = (GameObject)CompositeForwardIterator.GetChild(this);
            CollisionPair.Collide(m, game_object);
        }
    }
}