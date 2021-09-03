
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ScenePlayer2 : SceneState
    {
        CollisionPair collision_pair;
        int random_column;
        public static int score1 = 0;
        public static int score2 = 0;
        public static int maxScore = 0;
        public static int killedcount = 0;
        public static int lives1 = 3;
        public static int lives2 = 3;
        public static float splatX = 0;
        public static float splatY = 0;

        public static IrrKlang.ISoundSource soundWalk1 = null;
        public static IrrKlang.ISoundSource soundWalk2 = null;
        public static IrrKlang.ISoundSource soundWalk3 = null;
        public static IrrKlang.ISoundSource soundWalk4 = null;

        // Create Sound Manager
        IrrKlang.ISoundEngine sound_engine = null;

        // Data
        public SpriteBatchManager SpriteBatchManager;
        public FontManager FontManager;
        public new TimerEventManager TimerEventManager;
        public GameObjectNodeManager GONMan;
        public GhostManager GhostManager;
        public CollisionPairManager ColMan;
        public ShipManager ShipManager;

        public ScenePlayer2()
        {
            this.Initialize();
        }
        public override void Handle()
        {
            Debug.WriteLine("Handle Scene Player 2");
        }
        public override void Initialize()
        {

            // Setup Sound Engine
            sound_engine = new IrrKlang.ISoundEngine();
            sound_engine.SoundVolume = 0.3f;
            soundWalk1 = sound_engine.AddSoundSourceFromFile("fastinvader1.wav");
            soundWalk2 = sound_engine.AddSoundSourceFromFile("fastinvader2.wav");
            soundWalk3 = sound_engine.AddSoundSourceFromFile("fastinvader3.wav");
            soundWalk4 = sound_engine.AddSoundSourceFromFile("fastinvader4.wav");

            // Create Managers
            this.SpriteBatchManager = new SpriteBatchManager(3, 1);
            SpriteBatchManager.SetActive(this.SpriteBatchManager);

            this.TimerEventManager = new TimerEventManager(3, 1);
            TimerEventManager.SetActive(this.TimerEventManager);

            this.FontManager = new FontManager(3, 1);
            FontManager.SetActive(this.FontManager);

            this.GONMan = new GameObjectNodeManager(3, 1);
            GameObjectNodeManager.SetActive(this.GONMan);

            this.GhostManager = new GhostManager(3, 1);
            GhostManager.SetActive(this.GhostManager);

            this.ColMan = new CollisionPairManager(3, 1);
            CollisionPairManager.SetActive(this.ColMan);

            this.ShipManager = new ShipManager();
            ShipManager.SetActive(this.ShipManager);

            // Load Textures
            TextureManager.Add(Texture.Name.Aliens, "Invaders_1.tga");
            TextureManager.Add(Texture.Name.Bombs, "birds_N_shield.tga");

            TextureManager.Add(Texture.Name.Consolas36pt, "Consolas36pt.tga");
            GlyphManager.AddXml(Glyph.Name.Consolas36pt, "Consolas36pt.xml", Texture.Name.Consolas36pt);

            // Create Images
            ImageManager.Add(Image.Name.Squid1, Texture.Name.Aliens, 300, 20, 100, 100);
            ImageManager.Add(Image.Name.Squid2, Texture.Name.Aliens, 440, 20, 100, 100);
            ImageManager.Add(Image.Name.Crab1, Texture.Name.Aliens, 10, 20, 120, 90);
            ImageManager.Add(Image.Name.Crab2, Texture.Name.Aliens, 150, 20, 120, 90);
            ImageManager.Add(Image.Name.Octopus1, Texture.Name.Aliens, 0, 160, 135, 95);
            ImageManager.Add(Image.Name.Octopus2, Texture.Name.Aliens, 140, 160, 135, 95);
            ImageManager.Add(Image.Name.UFO, Texture.Name.Aliens, 50, 320, 120, 80);
            ImageManager.Add(Image.Name.Splat, Texture.Name.Aliens, 600, 20, 100, 100);

            ImageManager.Add(Image.Name.Ship, Texture.Name.Bombs, 10, 93, 30, 18);
            ImageManager.Add(Image.Name.ShipMini, Texture.Name.Bombs, 10, 93, 30, 18);
            ImageManager.Add(Image.Name.Missile, Texture.Name.Bombs, 73, 53, 5, 4);
            ImageManager.Add(Image.Name.GreenWall, Texture.Name.Bombs, 40, 185, 20, 10);

            ImageManager.Add(Image.Name.BombZigZag, Texture.Name.Bombs, 132, 100, 20, 50);
            ImageManager.Add(Image.Name.BombStraight, Texture.Name.Bombs, 111, 101, 5, 49);
            ImageManager.Add(Image.Name.BombCross, Texture.Name.Bombs, 219, 103, 19, 47);

            ImageManager.Add(Image.Name.Brick, Texture.Name.Bombs, 20, 210, 10, 5);
            ImageManager.Add(Image.Name.BrickLeft_Top0, Texture.Name.Bombs, 15, 180, 10, 5);
            ImageManager.Add(Image.Name.BrickLeft_Top1, Texture.Name.Bombs, 15, 185, 10, 5);
            ImageManager.Add(Image.Name.BrickLeft_Bottom, Texture.Name.Bombs, 35, 215, 10, 5);
            ImageManager.Add(Image.Name.BrickRight_Top0, Texture.Name.Bombs, 75, 180, 10, 5);
            ImageManager.Add(Image.Name.BrickRight_Top1, Texture.Name.Bombs, 75, 185, 10, 5);
            ImageManager.Add(Image.Name.BrickRight_Bottom, Texture.Name.Bombs, 55, 215, 10, 5);

            // Create Sprites             
            SpriteManager.Add(Sprite.Name.Squid1, Image.Name.Squid1, 400, 500, 50, 50);
            SpriteManager.Add(Sprite.Name.Squid2, Image.Name.Squid2, 400, 500, 50, 50);
            SpriteManager.Add(Sprite.Name.Crab1, Image.Name.Crab1, 230, 500, 50, 50);
            SpriteManager.Add(Sprite.Name.Crab2, Image.Name.Crab2, 230, 500, 50, 50);
            SpriteManager.Add(Sprite.Name.Octopus1, Image.Name.Octopus1, 230, 300, 50, 50);
            SpriteManager.Add(Sprite.Name.Octopus2, Image.Name.Octopus2, 230, 300, 50, 50);
            SpriteManager.Add(Sprite.Name.UFO, Image.Name.UFO, 130, 700, 50, 50);
            SpriteManager.Add(Sprite.Name.Splat, Image.Name.Splat, 150, 650, 40, 40);

            SpriteManager.Add(Sprite.Name.Missile, Image.Name.Missile, 0, 0, 5, 50);
            SpriteManager.Add(Sprite.Name.Ship, Image.Name.Ship, 500, 100, 80, 28);
            SpriteManager.Add(Sprite.Name.ShipMini, Image.Name.ShipMini, 500, 100, 40, 14);
            SpriteManager.Add(Sprite.Name.GreenWall, Image.Name.GreenWall, 448, 900, 850, 30);

            SpriteManager.Add(Sprite.Name.BombZigZag, Image.Name.BombZigZag, 100, 100, 10, 40);
            SpriteManager.Add(Sprite.Name.BombStraight, Image.Name.BombStraight, 100, 100, 5, 40);
            SpriteManager.Add(Sprite.Name.BombCross, Image.Name.BombCross, 100, 100, 10, 40);

            SpriteManager.Add(Sprite.Name.Brick, Image.Name.Brick, 50, 25, 14, 7);
            SpriteManager.Add(Sprite.Name.Brick_LeftTop0, Image.Name.BrickLeft_Top0, 50, 25, 14, 7);
            SpriteManager.Add(Sprite.Name.Brick_LeftTop1, Image.Name.BrickLeft_Top1, 50, 25, 14, 7);
            SpriteManager.Add(Sprite.Name.Brick_LeftBottom, Image.Name.BrickLeft_Bottom, 50, 25, 14, 7);
            SpriteManager.Add(Sprite.Name.Brick_RightTop0, Image.Name.BrickRight_Top0, 50, 25, 14, 7);
            SpriteManager.Add(Sprite.Name.Brick_RightTop1, Image.Name.BrickRight_Top1, 50, 25, 14, 7);
            SpriteManager.Add(Sprite.Name.Brick_RightBottom, Image.Name.BrickRight_Bottom, 50, 25, 14, 7);

            SpriteBatch Aliens_SpriteBatch = SpriteBatchManager.Add(SpriteBatch.Name.Aliens);
            SpriteBatch Texts_SpriteBatch = SpriteBatchManager.Add(SpriteBatch.Name.Texts);
            SpriteBatch Boxes_SpriteBatch = SpriteBatchManager.Add(SpriteBatch.Name.Boxes);
            SpriteBatch Shields_SpriteBatch = SpriteBatchManager.Add(SpriteBatch.Name.Shields);

            // Create Texts
            Font font1 = FontManager.Add(Font.Name.ScoreBoard, SpriteBatch.Name.Texts, "SCORE <1>       HI-SCORE       SCORE <2>", Glyph.Name.Consolas36pt, 140, 850);
            Font font2 = FontManager.Add(Font.Name.ScoreBoard1, SpriteBatch.Name.Texts, ScenePlayer1.score1.ToString(), Glyph.Name.Consolas36pt, 180, 800);
            Font font3 = FontManager.Add(Font.Name.ScoreBoardMax, SpriteBatch.Name.Texts, ScenePlayer1.maxScore.ToString(), Glyph.Name.Consolas36pt, 460, 800);
            Font font4 = FontManager.Add(Font.Name.ScoreBoard2, SpriteBatch.Name.Texts, ScenePlayer1.score2.ToString(), Glyph.Name.Consolas36pt, 730, 800);
            font1.SetColor(0.90f, 0.90f, 0.90f);
            font2.SetColor(0.90f, 0.90f, 0.90f);
            font3.SetColor(0.90f, 0.90f, 0.90f);
            font4.SetColor(0.90f, 0.90f, 0.90f);



            // Instantiate random number generator.  
            System.Random random = new System.Random();
            random_column = random.Next(0, 10);
            Debug.WriteLine("Number: {0}", random_column);

            // Create Aliens and Shields
            GameObject alien_root = AlienFactory.NewAlienRoot();

            GameObject shield_root = ShieldFactory.CreateSingleShield();

            // Input
            InputSubject InputSubject;
            InputSubject = InputManager.GetArrowRightSubject();
            InputSubject.Attach(new MoveRightObserver());

            InputSubject = InputManager.GetArrowLeftSubject();
            InputSubject.Attach(new MoveLeftObserver());

            InputSubject = InputManager.GetSpaceSubject();
            InputSubject.Attach(new ShootObserver());

            // Create Missile Group
            MissileGroup missile_group = new MissileGroup();
            missile_group.ActivateSprite(Aliens_SpriteBatch);
            missile_group.ActivateCollisionSprite(Boxes_SpriteBatch);

            GameObjectNodeManager.Attach(missile_group);

            // Create Bomb Group
            BombRoot BombRoot = new BombRoot(GameObject.Name.BombRoot, Sprite.Name.Null_Object, SpriteBox.Name.Null_Object, 0.0f, 0.0f);
            BombRoot.ActivateCollisionSprite(Boxes_SpriteBatch);
            BombRoot.ActivateSprite(Aliens_SpriteBatch);


            Bomb BombCross = new Bomb(GameObject.Name.Bomb, Sprite.Name.BombCross, new FallCross(), 700, 300);
            BombCross.ActivateCollisionSprite(Boxes_SpriteBatch);
            BombCross.ActivateSprite(Aliens_SpriteBatch);

            Bomb BombStraight = new Bomb(GameObject.Name.Bomb, Sprite.Name.BombStraight, new FallStraight(), 600, 300);
            BombStraight.ActivateCollisionSprite(Boxes_SpriteBatch);
            BombStraight.ActivateSprite(Aliens_SpriteBatch);

            Bomb BombZigZag = new Bomb(GameObject.Name.Bomb, Sprite.Name.BombZigZag, new FallZigZag(), 500, 300);
            BombZigZag.ActivateCollisionSprite(Boxes_SpriteBatch);
            BombZigZag.ActivateSprite(Aliens_SpriteBatch);

            BombRoot.Add(BombStraight);
            BombRoot.Add(BombCross);
            BombRoot.Add(BombZigZag);

            GameObjectNodeManager.Attach(BombRoot);

            // Create Bomb UFO
            BombRoot BombRootUFO = new BombRoot(GameObject.Name.BombRootUFO, Sprite.Name.Null_Object, SpriteBox.Name.Null_Object, 0.0f, 0.0f);
            BombRootUFO.ActivateCollisionSprite(Boxes_SpriteBatch);
            BombRootUFO.ActivateSprite(Aliens_SpriteBatch);

            Bomb BombUFOZigZag = new Bomb(GameObject.Name.BombUFOZigZag, Sprite.Name.BombZigZag, new FallZigZag(), 130, 700);
            BombUFOZigZag.ActivateCollisionSprite(Boxes_SpriteBatch);
            BombUFOZigZag.ActivateSprite(Aliens_SpriteBatch);

            BombRootUFO.Add(BombUFOZigZag);

            GameObjectNodeManager.Attach(BombRootUFO);

            // Create Walls
            WallGroup wall_group = new WallGroup(GameObject.Name.WallGroup, Sprite.Name.Null_Object, SpriteBox.Name.Null_Object, 0.0f, 0.0f);
            wall_group.ActivateSprite(Aliens_SpriteBatch);
            //wall_group.ActivateCollisionSprite(Boxes_SpriteBatch);

            WallTop wall_top = new WallTop(GameObject.Name.WallTop, Sprite.Name.Null_Object, 510, 850, 900, 50);
            wall_top.ActivateCollisionSprite(Boxes_SpriteBatch);

            WallBottom wall_bottom = new WallBottom(GameObject.Name.WallBottom, Sprite.Name.Null_Object, 520, 50, 900, 50);
            wall_bottom.ActivateCollisionSprite(Boxes_SpriteBatch);

            wall_group.Add(wall_top);
            wall_group.Add(wall_bottom);

            GameObjectNodeManager.Attach(wall_group);

            // Create Bumper
            BumperRoot BumperRoot = new BumperRoot(GameObject.Name.BumperRoot, Sprite.Name.Null_Object, SpriteBox.Name.Null_Object, 0.0f, 0.0f);
            BumperRoot.ActivateSprite(Boxes_SpriteBatch);

            BumperRight BumperRight = new BumperRight(GameObject.Name.BumperRight, Sprite.Name.Null_Object, 942, 475, 20, 800);
            BumperRight.ActivateCollisionSprite(Boxes_SpriteBatch);

            BumperLeft BumperLeft = new BumperLeft(GameObject.Name.BumperLeft, Sprite.Name.Null_Object, 100, 475, 20, 800);
            BumperLeft.ActivateCollisionSprite(Boxes_SpriteBatch);

            // Add to the composite the children
            BumperRoot.Add(BumperRight);
            BumperRoot.Add(BumperLeft);

            GameObjectNodeManager.Attach(BumperRoot);

            // Create Ship

            ShipRoot ShipRoot = new ShipRoot(GameObject.Name.ShipRoot, Sprite.Name.Null_Object, SpriteBox.Name.Null_Object, 0.0f, 0.0f);
            GameObjectNodeManager.Attach(ShipRoot);

            this.ShipManager.Ship = ShipManager.ActivateShip();
            this.ShipManager.Ship.SetMoveState(ShipManager.MoveState.MoveBoth);
            this.ShipManager.Ship.SetMissileState(ShipManager.MissileState.Ready);

            ShipRoot ShipMiniRoot = new ShipRoot(GameObject.Name.ShipMiniRoot, Sprite.Name.Null_Object, SpriteBox.Name.Null_Object, 0.0f, 0.0f);
            GameObjectNodeManager.Attach(ShipMiniRoot);

            Ship Ship1 = new Ship(GameObject.Name.ShipMini1, Sprite.Name.ShipMini, 850, 750);
            Ship Ship2 = new Ship(GameObject.Name.ShipMini2, Sprite.Name.ShipMini, 800, 750);
            Ship Ship3 = new Ship(GameObject.Name.ShipMini3, Sprite.Name.ShipMini, 750, 750);
            Aliens_SpriteBatch.Attach(Ship1);
            Aliens_SpriteBatch.Attach(Ship2);
            Aliens_SpriteBatch.Attach(Ship3);
            Ship1.ActivateCollisionSprite(Boxes_SpriteBatch);
            Ship2.ActivateCollisionSprite(Boxes_SpriteBatch);
            Ship3.ActivateCollisionSprite(Boxes_SpriteBatch);

            ShipMiniRoot.Add(Ship1);
            ShipMiniRoot.Add(Ship2);
            ShipMiniRoot.Add(Ship3);

            // Create UFO Root
            UFO ufo = new UFO(Sprite.Name.UFO, 130, 700);
            Aliens_SpriteBatch.Attach(ufo);
            ufo.ActivateCollisionSprite(Boxes_SpriteBatch);
            UFORoot UFO_root = new UFORoot(GameObject.Name.UFORoot, Sprite.Name.Null_Object, SpriteBox.Name.Null_Object, 0.0f, 0.0f);
            UFO_root.Add(ufo);
            GameObjectNodeManager.Attach(UFO_root);

            // Create Splat Root
            SplatRoot splat_root = new SplatRoot(GameObject.Name.SplatRoot, Sprite.Name.Null_Object, SpriteBox.Name.Null_Object, 0.0f, 0.0f);
            GameObjectNodeManager.Attach(splat_root);

            Splat splat = new Splat(Sprite.Name.Splat, 0, 0);
            Aliens_SpriteBatch.Attach(splat);
            splat.ActivateCollisionSprite(Boxes_SpriteBatch);

            splat_root.Add(splat);


            // Collision Pair

            // Bumper vs Ship
            collision_pair = CollisionPairManager.Add(CollisionPair.Name.Bumper_Ship, BumperRoot, ShipRoot);
            collision_pair.Attach(new ShipMoveObserver());


            // Missile v WallTop
            collision_pair = CollisionPairManager.Add(CollisionPair.Name.Missile_WallTop, missile_group, wall_group);
            collision_pair.Attach(new RemoveMissileObserver());
            collision_pair.Attach(new ShipReadyObserver());

            // Missile vs Aliens
            collision_pair = CollisionPairManager.Add(CollisionPair.Name.Missile_Alien, missile_group, alien_root);
            collision_pair.Attach(new RemoveMissileObserver());
            collision_pair.Attach(new RemoveAlienObserver());
            collision_pair.Attach(new ShipReadyObserver());

            // Missile vs UFO
            collision_pair = CollisionPairManager.Add(CollisionPair.Name.Missile_UFO, missile_group, UFO_root);
            collision_pair.Attach(new RemoveMissileObserver());
            collision_pair.Attach(new RemoveUFOObserver());
            collision_pair.Attach(new ShipReadyObserver());

            // Missile vs Shields
            collision_pair = CollisionPairManager.Add(CollisionPair.Name.Missile_Alien, missile_group, shield_root);
            collision_pair.Attach(new RemoveMissileObserver());
            collision_pair.Attach(new RemoveShieldMIssileObserver());
            collision_pair.Attach(new ShipReadyObserver());

            // Alien vs Wall
            collision_pair = CollisionPairManager.Add(CollisionPair.Name.Wall_Alien, shield_root, alien_root);
            collision_pair.Attach(new AlienShieldObserver());


            // Bumper vs Alien
            collision_pair = CollisionPairManager.Add(CollisionPair.Name.Bumper_Alien, BumperRoot, alien_root);
            collision_pair.Attach(new AlienBumperObserver());

            // Bomb vs WallGroup
            collision_pair = CollisionPairManager.Add(CollisionPair.Name.Bomb_Wall, wall_group, BombRoot);
            collision_pair.Attach(new ResetBombObserver());

            // Bomb vs Shield
            collision_pair = CollisionPairManager.Add(CollisionPair.Name.Bomb_Shield, shield_root, BombRoot);
            collision_pair.Attach(new ResetBombObserver());
            collision_pair.Attach(new RemoveShieldObserver());

            // Bomb vs Missile
            collision_pair = CollisionPairManager.Add(CollisionPair.Name.Bomb_Missile, missile_group, BombRoot);
            collision_pair.Attach(new ResetBombObserver());
            collision_pair.Attach(new RemoveMissileObserver());
            collision_pair.Attach(new ShipReadyObserver());
            collision_pair.Attach(new RemoveBombUFOObserver());

            // Bomb vs Ship
            collision_pair = CollisionPairManager.Add(CollisionPair.Name.Bomb_Ship, ShipRoot, BombRoot);
            collision_pair.Attach(new BombShipObserver());
            collision_pair.Attach(new ResetBombObserver());

            // BombUFO vs WallGroup
            collision_pair = CollisionPairManager.Add(CollisionPair.Name.Bomb_Wall, wall_group, BombRootUFO);
            collision_pair.Attach(new ResetBombUFOObserver());

            // BombUFO vs Shield
            collision_pair = CollisionPairManager.Add(CollisionPair.Name.Bomb_Shield, shield_root, BombRootUFO);
            collision_pair.Attach(new ResetBombUFOObserver());
            collision_pair.Attach(new RemoveShieldObserver());

            // BombUFO vs Missile
            collision_pair = CollisionPairManager.Add(CollisionPair.Name.Bomb_Missile, missile_group, BombRootUFO);
            collision_pair.Attach(new ResetBombUFOObserver());
            collision_pair.Attach(new RemoveMissileObserver());
            collision_pair.Attach(new ShipReadyObserver());
            collision_pair.Attach(new RemoveBombUFOObserver());

            // BombUFO vs Ship
            collision_pair = CollisionPairManager.Add(CollisionPair.Name.Bomb_Ship, ShipRoot, BombRootUFO);
            collision_pair.Attach(new BombShipObserver());
            collision_pair.Attach(new ResetBombUFOObserver());

            // UFO vs BumperRight
            collision_pair = CollisionPairManager.Add(CollisionPair.Name.UFO_Bumper, UFO_root, BumperRoot);
            collision_pair.Attach(new ResetUFOObserver());


            // Animation & Movement
            AnimationCommand AnimationAction1 = new AnimationCommand(Sprite.Name.Squid1);
            AnimationCommand AnimationAction2 = new AnimationCommand(Sprite.Name.Crab1);
            AnimationCommand AnimationAction3 = new AnimationCommand(Sprite.Name.Octopus1);
            MovementCommand MovementAction = new MovementCommand(sound_engine);
            BombCommand BombAction = new BombCommand();
            BombUFOCommand BombUFOAction = new BombUFOCommand();
            UFOCommand UFOAction = new UFOCommand();

            // Attach Images to cycle
            AnimationAction1.Attach(Image.Name.Squid1);
            AnimationAction1.Attach(Image.Name.Squid2);
            AnimationAction2.Attach(Image.Name.Crab1);
            AnimationAction2.Attach(Image.Name.Crab2);
            AnimationAction3.Attach(Image.Name.Octopus1);
            AnimationAction3.Attach(Image.Name.Octopus2);


            TimerEventManager.AddToIndex(TimerEvent.Name.SpriteAnimation, AnimationAction1, 0.5f);
            TimerEventManager.AddToIndex(TimerEvent.Name.SpriteAnimation, AnimationAction2, 0.5f);
            TimerEventManager.AddToIndex(TimerEvent.Name.SpriteAnimation, AnimationAction3, 0.5f);
            TimerEventManager.AddToIndex(TimerEvent.Name.ObjectMovement, MovementAction, 0.5f);
            TimerEventManager.AddToIndex(TimerEvent.Name.BombAction, BombAction, 0.5f);
            TimerEventManager.AddToIndex(TimerEvent.Name.BombUFOAction, BombUFOAction, 0.5f);
            //TimerEventManager.AddToIndex(TimerEvent.Name.UFOAction, UFOAction, 0.5f);
        }

        public override void Update(float systemTime)
        {

            sound_engine.Update();

            UFORoot UFO_Root = (UFORoot)GameObjectNodeManager.Find(GameObject.Name.UFORoot);
            UFO_Root.MoveRoot();

            // Single Step, Free running...
            Simulation.Update(systemTime);

            // Input
            InputManager.Update();

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_T) == true)
            {
                SpriteBatch sprite_batch = SpriteBatchManager.Find(SpriteBatch.Name.Boxes);
                Debug.Assert(sprite_batch != null);
                sprite_batch.SetDrawEnable(false);
            }

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_Y) == true)
            {
                SpriteBatch sprite_batch = SpriteBatchManager.Find(SpriteBatch.Name.Boxes);
                Debug.Assert(sprite_batch != null);
                sprite_batch.SetDrawEnable(true);
            }

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_R) == true)
            {
                GhostManager.Dump();
            }

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_E) == true)
            {
                GameObject new_root = AlienFactory.NewAlienRoot();
                GameObject shield_root = ShieldFactory.CreateSingleShield();
                //GhostManager.Dump();
                // No need to re-calling new()

            }

            // Run based on simulation stepping
            if (Simulation.GetTimeStep() > 0.0f)
            {
                // Do the collision checks
                CollisionPairManager.Process();

                // Fire off the timer events
                TimerEventManager.Update(Simulation.GetTotalTime());

                // walk through all objects and push to flyweight
                GameObjectNodeManager.Update();

                // Delete any objects here...
                DelayedObjectManager.Process();

                //Debug.WriteLine("Score: {0}", score1);

            }
        }

        public override void Draw()
        {
            // Draw all objects
            SpriteBatchManager.Draw();
        }

        public override void Entering()
        {
            SpaceInvaders.Player2 = false;
            SpriteBatchManager.SetActive(this.SpriteBatchManager);
            TimerEventManager.SetActive(this.TimerEventManager);
            GameObjectNodeManager.SetActive(this.GONMan);
            FontManager.SetActive(this.FontManager);
            CollisionPairManager.SetActive(this.ColMan);
            ShipManager.SetActive(this.ShipManager);


            // Update timer since last pause
            float t0 = GlobalTimer.GetTime();
            float t1 = this.TimeAtPause;
            float delta = t0 - t1;
            TimerEventManager.PauseUpdate(delta);
        }

        public override void Leaving()
        {
            this.TimeAtPause = GlobalTimer.GetTime();
        }
    }
}