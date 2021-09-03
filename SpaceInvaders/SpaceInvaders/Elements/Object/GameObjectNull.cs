using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class GameObjectNull : Leaf
    {
        //LTN - This grid holds a null sprite proxy and null sprite box proxy in case a null leaf is indicated
        private static SpriteProxyNull dataSpriteProxyNull = new SpriteProxyNull();
        
        public GameObjectNull()
            : base(GameObject.Name.Null_Object, 
                    Sprite.Name.Null_Object, 
                    0, 0)
        {

        }

        public override void Accept(CollisionVisitor other)
        {
            // Important: at this point we have an NullGameObject
            // Call collision reaction            
            other.VisitNullGameObject(this);
        }

        public override void Move()
        {
        }

        public override void Update()
        {
            // do nothing - its a null object
        }
    }
}
