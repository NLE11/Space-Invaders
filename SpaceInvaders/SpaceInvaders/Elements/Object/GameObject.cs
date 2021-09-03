using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class GameObject : Component
    {
        // Data: ---------------
        public GameObject.Name name;
        public Sprite.Name spriteName;

        public bool MarkForDeath;

        public float x;
        public float y;
        public SpriteProxy SpriteProxy;
        public SpriteBoxProxy SpriteBoxProxy;
        public CollisionObject collison_object;

        public enum Name
        {
            AlienGrid,
            AlienRoot,

            AlienColumn,
            AlienColumn_0,
            AlienColumn_1,
            AlienColumn_2,
            AlienColumn_3,
            AlienColumn_4,
            AlienColumn_5,
            AlienColumn_6,
            AlienColumn_7,
            AlienColumn_8,
            AlienColumn_9,
            AlienColumn_10,

            ShieldRoot,
            ShieldColumn_0,
            ShieldColumn_1,
            ShieldColumn_2,
            ShieldColumn_3,
            ShieldColumn_4,
            ShieldColumn_5,
            ShieldColumn_6,
            ShieldBrick,

            Squid1, Squid2,
            Crab1, Crab2,
            Octopus1, Octopus2,
            
            RedBird,
            YellowBird,
            GreenBird,

            Box1,
            Box2,
            Box3,
            Box4,

            Missile,
            MissileGroup,

            WallGroup,
            WallRight,
            WallLeft,
            WallTop,
            WallBottom,
            WallMiddle,

            Ship,
            ShipRoot,
            ShipMiniRoot,
            ShipMini1,
            ShipMini2,
            ShipMini3,

            UFORoot,
            UFO,

            SplatRoot,
            Splat,

            BumperRoot,
            BumperRight,
            BumperLeft,

            Bomb,
            BombRoot,
            BombRootUFO,
            BombUFOZigZag,

            Null_Object,
            Uninitialized
        }

        protected GameObject(Component.Container component_type, 
                    GameObject.Name gameName, 
                    Sprite.Name proxyName, 
                    SpriteBox.Name boxproxyName)
            : base(component_type)
        {
            this.name = gameName;
            this.x = 0.0f;
            this.y = 0.0f;

            this.MarkForDeath = false;
            this.spriteName = proxyName;
            SpriteProxy Proxy = SpriteProxyManager.Find(proxyName);
            Debug.Assert(Proxy != null);
            this.SpriteProxy = Proxy;
            //SpriteBoxProxy Box_Proxy = SpriteBoxProxyManager.Find(boxproxyName);
            //Debug.Assert(Box_Proxy != null);
            //this.SpriteBoxProxy = Box_Proxy;

            this.collison_object = new CollisionObject(this.SpriteProxy);
            Debug.Assert(this.collison_object != null);
        }

        protected GameObject(Component.Container component_type, GameObject.Name gameName, Sprite.Name spriteName, float x, float y)
            : base(component_type)
        {
            this.name = gameName;
            this.x = x;
            this.y = y;

            this.MarkForDeath = false;
            this.spriteName = spriteName;
            this.SpriteProxy = SpriteProxyManager.Add(this.spriteName);

            this.collison_object = new CollisionObject(this.SpriteProxy);
            Debug.Assert(this.collison_object != null);
        
        }
        override public void Resurrect()
        {
            this.MarkForDeath = false;
            this.SpriteProxy = SpriteProxyManager.Add(this.spriteName);

            // the new is temporary.. need a "update" to reset ColObject
            // for now call new
            this.collison_object = new CollisionObject(this.SpriteProxy);


            Debug.Assert(this.collison_object != null);
            base.Resurrect();
        }
        ~GameObject()
        {

        }

        public virtual void Remove()
        {
            Debug.WriteLine("REMOVE: {0}", this);

            // Keenan(delete.A)
            // -----------------------------------------------------------------
            // Very difficult at first... if you are messy, you will pay here!
            // Given a game object....
            // -----------------------------------------------------------------

            // Remove from SpriteBatch

            // Find the SpriteNode
            Debug.Assert(this.SpriteProxy != null);
            //Get Back SpriteNode from SpriteBase
            SpriteNode SpriteNode = this.SpriteProxy.GetSpriteNode();

            // Remove it from the manager
            Debug.Assert(SpriteNode != null);
            SpriteBatchManager.Remove(SpriteNode);

            // Remove collision sprite from spriteBatch

            Debug.Assert(this.collison_object != null);
            Debug.Assert(this.collison_object.CollisionSpriteBox != null);
            SpriteNode = this.collison_object.CollisionSpriteBox.GetSpriteNode();

            //Debug.Assert(pSpriteNode != null);
            SpriteBatchManager.Remove(SpriteNode);

            // Remove from GameObjectManager

            GameObjectNodeManager.Remove(this);

            // in the future

            GhostManager.Attach(this);
        }
        protected void BaseUpdateBoundingBox(Component Start)
        {
            GameObject current_node = (GameObject)Start;

            // point to ColTotal
            CollisionRect CollisionTotal = this.collison_object.collision_rect;

            // Get the first child
            current_node = (GameObject)CompositeForwardIterator.GetChild(current_node);
            if (current_node != null)
            {
                // Initialized the union to the first block
                CollisionTotal.Set(current_node.collison_object.collision_rect);

                // loop through sliblings
                while (current_node != null)
                {
                    CollisionTotal.Union(current_node.collison_object.collision_rect);

                    // go to next sibling
                    current_node = (GameObject)CompositeForwardIterator.GetSibling(current_node);
                }


                this.x = this.collison_object.collision_rect.x;
                this.y = this.collison_object.collision_rect.y;

                //Debug.WriteLine("x:{0} y:{1} w:{2} h:{3}", CollisionTotal.x, CollisionTotal.y, CollisionTotal.width, CollisionTotal.height);
            }
        }

        public virtual void Update()
        {
            if (this.SpriteProxy != null)
            {
                this.SpriteProxy.x = this.x;
                this.SpriteProxy.y = this.y;

                this.collison_object.UpdatePosition(this.x, this.y);
                this.collison_object.CollisionSpriteBox.Update();
            }
            if (this.SpriteBoxProxy != null)
            {
                this.SpriteBoxProxy.x = this.x;
                this.SpriteBoxProxy.y = this.y;
            }
        }

        public void ActivateCollisionSprite(SpriteBatch sprite_batch)
        {
            Debug.Assert(sprite_batch != null);
            Debug.Assert(this.collison_object != null);
            sprite_batch.Attach(this.collison_object.CollisionSpriteBox);
        }
        public void ActivateSprite(SpriteBatch sprite_batch)
        {
            Debug.Assert(sprite_batch != null);
            sprite_batch.Attach(this.SpriteProxy);
        }

        public void SetCollisionColor(float red, float green, float blue)
        {
            Debug.Assert(this.collison_object != null);
            Debug.Assert(this.collison_object.CollisionSpriteBox != null);

            this.collison_object.CollisionSpriteBox.SetColor(red, green, blue);
        }

        override public void Dump()
        {
            // Data:
            Debug.WriteLine("");
            Debug.WriteLine("\tGameObject: --------------");
            Debug.WriteLine("\t\t\t       name: {0} ({1})", this.name, this.GetHashCode());

            if (this.SpriteProxy != null)
            {
                Debug.WriteLine("\t\t   ProxySprite: {0}", this.SpriteProxy.name);
                if (this.SpriteProxy.Sprite == null)
                {
                    Debug.WriteLine("\t\t    RealSprite: null");
                }
                else
                {
                    Debug.WriteLine("\t\t    RealSprite: {0}", this.SpriteProxy.Sprite.GetName());
                }
            }
            else
            {
                Debug.WriteLine("\t\t   ProxySprite: null");
                Debug.WriteLine("\t\t    RealSprite: null");
            }
            Debug.WriteLine("\t\t\t      (x,y): {0}, {1}", this.x, this.y);

            base.Dump();
        }

        override public object GetName()
        {
            return this.name;
        }

        public CollisionObject GetCollisionObject()
        {
            Debug.Assert(this.collison_object != null);
            return this.collison_object;
        }
    }
}
