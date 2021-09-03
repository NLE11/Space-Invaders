
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Bomb : BombCategory
    {
        // Data
        //public float delta;
        private FallStrategy Strategy;

        public Bomb(GameObject.Name name, Sprite.Name spriteName, FallStrategy strategy, float positionX, float positionY)
            : base(name, spriteName, positionX, positionY, BombCategory.Type.Bomb)
        {
            this.x = positionX;
            this.y = positionY;
            //this.delta = 1.0f;

            Debug.Assert(strategy != null);
            this.Strategy = strategy;

            this.Strategy.Reset(this.x, this.y);

            this.collison_object.CollisionSpriteBox.SetColor(1, 1, 0);
        }

        public void Reset(float x, float y)
        {
            this.x = x;
            this.y = y;
            this.Strategy.Reset(this.x, this.y);
        }
        public override void Remove()
        {
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
        public override void Update()
        {
            base.Update();
            //this.y -= delta;

            // Strategy
            this.Strategy.Fall(this);
        }
        public float GetBoundingBoxHeight()
        {
            return this.collison_object.collision_rect.height;
        }
        ~Bomb()
        {
        }
        public override void Accept(CollisionVisitor other)
        {        
            other.VisitBomb(this);
        }
        public override void VisitMissileGroup(MissileGroup m)
        {
            // ShieldRoot v Bomb
            GameObject game_object = (GameObject)CompositeForwardIterator.GetChild(m);
            CollisionPair.Collide(game_object, this);
        }
        public override void VisitMissile(Missile m)
        {
            // MissileGroup vs this leaf
            Debug.WriteLine("\nCollide: {0} with {1}", m, this);
            Debug.WriteLine("FINISHED!");


            CollisionPair collision_pair = CollisionPairManager.GetActiveColPair();
            Debug.Assert(collision_pair != null);

            collision_pair.SetCollision(m, this);
            collision_pair.NotifyListeners();
        }

        public override void VisitShipRoot(ShipRoot s)
        {
            // MissileGroup vs this leaf
            Debug.WriteLine("\nCollide: {0} with {1}", s, this);
            Debug.WriteLine("FINISHED!");


            CollisionPair collision_pair = CollisionPairManager.GetActiveColPair();
            Debug.Assert(collision_pair != null);

            collision_pair.SetCollision(s, this);
            collision_pair.NotifyListeners();
        }

        public override void VisitShieldRoot(ShieldRoot s)
        {
            // ShieldRoot v Bomb
            GameObject game_object = (GameObject)CompositeForwardIterator.GetChild(s);
            CollisionPair.Collide(game_object, this);
        }
        public override void VisitShieldColumn(ShieldColumn s)
        {
            // ShieldColumn v Bomb
            GameObject game_object = (GameObject)CompositeForwardIterator.GetChild(s);
            CollisionPair.Collide(game_object, this);
        }
        public override void VisitShieldBrick(ShieldBrick s)
        {
            // ShieldBrick v Bomb
            Debug.WriteLine("\nCollide: {0} with {1}", s, this);
            Debug.WriteLine("FINISHED!");


            CollisionPair collision_pair = CollisionPairManager.GetActiveColPair();
            Debug.Assert(collision_pair != null);

            collision_pair.SetCollision(s, this);
            collision_pair.NotifyListeners();
        }
        public override void VisitWallGroup(WallGroup w)
        {
            // ShieldRoot v BombRoot
            GameObject game_object = (GameObject)CompositeForwardIterator.GetChild(w);
            CollisionPair.Collide(game_object, this);
        }

        public override void VisitWallBottom(WallBottom w)
        {
            // ShieldBrick v Bomb
            Debug.WriteLine("\nCollide: {0} with {1}", w, this);
            Debug.WriteLine("FINISHED!");


            CollisionPair collision_pair = CollisionPairManager.GetActiveColPair();
            Debug.Assert(collision_pair != null);

            collision_pair.SetCollision(w, this);
            collision_pair.NotifyListeners();
        }
        public void SetPosition(float xPos, float yPos)
        {
            this.x = xPos;
            this.y = yPos;
        }
        public void MultiplyScale(float sx, float sy)
        {
            Debug.Assert(this.SpriteProxy != null);


        }

        public override void Move()
        {
            throw new System.NotImplementedException();
        }
    }
}