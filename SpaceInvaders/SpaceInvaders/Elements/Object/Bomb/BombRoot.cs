using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class BombRoot : Composite
    {
        public BombRoot(GameObject.Name name, Sprite.Name spriteName, SpriteBox.Name spriteboxName, float positionX, float positionY)
            : base(name, spriteName, spriteboxName)
        {
            this.x = positionX;
            this.y = positionY;

            this.collison_object.CollisionSpriteBox.SetColor(1, 1, 1);
        }

        ~BombRoot()
        {
        }

        public override void Accept(CollisionVisitor other)
        {
            other.VisitBombRoot(this);
        }

        public override void VisitMissileGroup(MissileGroup m)
        {
            // MissileRoot vs AlienRoot
            GameObject game_object = (GameObject)CompositeForwardIterator.GetChild(this);
            CollisionPair.Collide(m, game_object);
        }

        public override void VisitShieldRoot(ShieldRoot s)
        {
            // ShieldRoot v BombRoot
            GameObject game_object = (GameObject)CompositeForwardIterator.GetChild(this);
            CollisionPair.Collide(s, game_object);
        }

        public override void VisitShipRoot(ShipRoot s)
        {
            // ShieldRoot v BombRoot
            GameObject game_object = (GameObject)CompositeForwardIterator.GetChild(this);
            CollisionPair.Collide(s, game_object);
        }

        public override void VisitWallGroup(WallGroup w)
        {
            // ShieldRoot v BombRoot
            GameObject game_object = (GameObject)CompositeForwardIterator.GetChild(this);
            CollisionPair.Collide(w, game_object);
        }


        public override void Update()
        {
            // Go to first child
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }

        public void Remove()
        {
            CompositeForwardIterator iterator = new CompositeForwardIterator(this);

            Component node = iterator.First();
            while (!iterator.isDone())
            {
                GameObject game_object = (GameObject)node;
                game_object.Remove();

                node = iterator.Next();
            }
        }

        public void MoveRoot()
        {
            CompositeForwardIterator iterator = new CompositeForwardIterator(this);

            Component node = iterator.First();
            while (!iterator.isDone())
            {
                GameObject game_object = (GameObject)node;
                game_object.x -= 0;
                game_object.y -= 10;

                node = iterator.Next();
            }
        }
    }
}