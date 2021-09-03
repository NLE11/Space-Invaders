using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShipManager:ManagerBase
    {
        // Data
        private static ShipManager instance = null;
        private static ShipManager ActiveShipMan = null;

        // Active
        public Ship Ship = null;
        private Missile Missile = null;

        // Reference
        private ShipMissileReady StateMissileReady = new ShipMissileReady();
        private ShipMissileFlying StateMissileFlying = new ShipMissileFlying();

        private ShipMoveBoth StateMoveBoth = new ShipMoveBoth();
        private ShipMoveRight StateMoveRight = new ShipMoveRight();
        private ShipMoveLeft StateMoveLeft = new ShipMoveLeft();

        public enum MissileState
        {
            Ready,
            MissileFlying, 
            Dead
        }

        public enum MoveState
        {
            MoveRight,
            MoveLeft,
            MoveBoth
        }

        public ShipManager(int reserveNum = 3, int reserveGrow = 1)
                : base(new DLinkMAN(), new DLinkMAN(), reserveNum, reserveGrow)
        {
            ShipManager.ActiveShipMan = null;

            this.StateMissileReady = new ShipMissileReady();
            this.StateMissileFlying = new ShipMissileFlying();

            this.StateMoveBoth = new ShipMoveBoth();
            this.StateMoveRight = new ShipMoveRight();
            this.StateMoveLeft = new ShipMoveLeft();

        }

        public static void Create()
        {
            // make sure its the first time
            Debug.Assert(instance == null);

            // Do the initialization
            if (instance == null)
            {
                instance = new ShipManager();
            }

            Debug.Assert(instance != null);

        }

        private static ShipManager GetInstance()
        {
            Debug.Assert(instance != null);

            return instance;
        }

        public static Ship GetShip()
        {
            ShipManager manager = ShipManager.ActiveShipMan;

            Debug.Assert(manager != null);
            Debug.Assert(manager.Ship != null);

            return manager.Ship;
        }

        public static ShipMissileState GetMissileState(MissileState state)
        {
            ShipManager manager = ShipManager.ActiveShipMan;
            Debug.Assert(manager != null);

            ShipMissileState ship_missile_state = null;

            switch (state)
            {
                case ShipManager.MissileState.Ready:
                    ship_missile_state = manager.StateMissileReady;
                    break;

                case ShipManager.MissileState.MissileFlying:
                    ship_missile_state = manager.StateMissileFlying;
                    break;

                default:
                    Debug.Assert(false);
                    break;
            }

            return ship_missile_state;
        }
        public static ShipMoveState GetMoveState(MoveState state)
        {
            ShipManager manager = ShipManager.ActiveShipMan;
            Debug.Assert(manager != null);

            ShipMoveState ship_move_state = null;

            switch (state)
            {
                case ShipManager.MoveState.MoveBoth:
                    ship_move_state = manager.StateMoveBoth;
                    break;

                case ShipManager.MoveState.MoveLeft:
                    ship_move_state = manager.StateMoveLeft;
                    break;

                case ShipManager.MoveState.MoveRight:
                    ship_move_state = manager.StateMoveRight;
                    break;

                default:
                    Debug.Assert(false);
                    break;
            }

            return ship_move_state;
        }

        public static Missile GetMissile()
        {
            ShipManager manager = ShipManager.ActiveShipMan;

            Debug.Assert(manager != null);
            Debug.Assert(manager.Missile != null);

            return manager.Missile;
        }

        public static Missile ActivateMissile()
        {
            ShipManager manager = ShipManager.ActiveShipMan;
            Debug.Assert(manager != null);

            // No need to re-calling new()
            Missile missile = null;
            GameObjectNode gameobject_node = GhostManager.Find(GameObject.Name.Missile);
            if (gameobject_node == null)
            {
                missile = new Missile(Sprite.Name.Missile, 400, 100);
            }
            else
            {
                // Resurrect it from Ghost Manager
                Debug.WriteLine("Resurrect Missile!");
                missile = (Missile)gameobject_node.GameObject;
                GhostManager.Remove(gameobject_node);
                // GhostMan.Dump();
                missile.Resurrect(400, 100);
            }

            manager.Missile = missile;

            // Attached to SpriteBatches
            SpriteBatch SB_Aliens = SpriteBatchManager.Find(SpriteBatch.Name.Aliens);
            SpriteBatch SB_Boxes = SpriteBatchManager.Find(SpriteBatch.Name.Boxes);

            missile.ActivateCollisionSprite(SB_Boxes);
            missile.ActivateSprite(SB_Aliens);

            // Attach the missile to the missile root
             GameObject MissileGroup = GameObjectNodeManager.Find(GameObject.Name.MissileGroup);
            Debug.Assert(MissileGroup != null);

            // Add to GameObject Tree
            MissileGroup.Add(manager.Missile);

            return manager.Missile;
        }


        public static Ship ActivateShip()
        {
            ShipManager manager = ShipManager.ActiveShipMan;
            Debug.Assert(manager != null);

            // Create a new ship - Could be recycle
            Ship ship = new Ship(GameObject.Name.Ship, Sprite.Name.Ship, 400, 100);
            manager.Ship = ship;

            // Attach the sprite to the correct sprite batch
            SpriteBatch pSB_Aliens = SpriteBatchManager.Find(SpriteBatch.Name.Aliens);
            pSB_Aliens.Attach(ship);

            // Attach the ship to the ship root
            GameObject ShipRoot = GameObjectNodeManager.Find(GameObject.Name.ShipRoot);
            Debug.Assert(ShipRoot != null);

            // Add to GameObject Tree
            ShipRoot.Add(manager.Ship);

            return manager.Ship;
        }
        public static void SetActive(ShipManager ShipMan)
        {
            ShipManager manager = ShipManager.GetInstance();
            Debug.Assert(manager != null);

            Debug.Assert(ShipMan != null);
            ShipManager.ActiveShipMan = ShipMan;
 
        }

        protected override NodeBase derivedCreateNode()
        {
            NodeBase pNodeBase = new SpriteBatch();
            Debug.Assert(pNodeBase != null);

            return pNodeBase;
        }
    }
}