using System;
using System.Diagnostics;

namespace SpaceInvaders
{
   
    public class SpaceInvaders : Azul.Game
    {
        public static SceneContext SceneContext = null;
        public static bool Select = false;
        public static bool GameOver = false;
        public static bool Player1 = false;
        public static bool Player2 = false;
        public static bool Intro1 = false;
        public static bool Intro2 = false;
        public static int count = 0;

        // Create Sound Manager
        IrrKlang.ISoundEngine sound_engine = null;

        public override void Initialize()
        {
            // Start the game here
            this.SetWindowName("Space Invaders");
            this.SetWidthHeight(1024, 896);
            this.SetClearColor(0.0f, 0.0f, 0.0f, 0.0f);
        }

        public override void LoadContent()
        {
            // We need to load 3 managers for images, textures and sprites here
            TextureManager.Create(1, 1);
            ImageManager.Create();
            SpriteManager.Create();
            SpriteBatchManager.Create();
            SpriteBoxManager.Create(1, 1);
            TimerEventManager.Create();
            SpriteProxyManager.Create(1, 1);
            SpriteBoxProxyManager.Create(1, 1);
            GameObjectNodeManager.Create();
            CollisionPairManager.Create();
            GlyphManager.Create(1, 1);
            FontManager.Create();
            ShipManager.Create();
            GhostManager.Create();
            Simulation.Create();

            // Scene

            SceneContext = new SceneContext();          

        }

        public override void UnLoadContent()
        {
        }

        public override void Draw()
        {
            SceneContext.GetState().Draw();
        }

        public override void Update()
        {
            GlobalTimer.Update(this.GetTime());

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_0) == true)
            {
                SceneContext.SetState(SceneContext.Scene.Select);
            }

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_E) == true)
            {
                SceneContext.SetState(SceneContext.Scene.Intro1);
            }

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_1) == true)
            {
                SceneContext.SetState(SceneContext.Scene.Player1);
            }

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_2) == true)
            {
                SceneContext.SetState(SceneContext.Scene.Player2);
            }

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_3) == true)
            {
                SceneContext.SetState(SceneContext.Scene.GameOver);
            }

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_4) == true)
            {
                SceneContext.SetState(SceneContext.Scene.Intro1);
            }

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_5) == true)
            {
                SceneContext.SetState(SceneContext.Scene.Intro2);
            }

            if (GameOver == true)
            {
                SceneContext.SetState(SceneContext.Scene.GameOver);
            }

            if (Player1 == true)
            {
                SceneContext.SetState(SceneContext.Scene.Player1);
            }

            if (Player2 == true)
            {
                SceneContext.SetState(SceneContext.Scene.Player2);
            }

            if (Intro1 == true)
            {
                SceneContext.SetState(SceneContext.Scene.Intro1);
            }

            if (Intro2 == true)
            {
                SceneContext.SetState(SceneContext.Scene.Intro2);
            }

            if (Select == true)
            {
                SceneContext.SetState(SceneContext.Scene.Select);
            }

            // Update the scene
            SceneContext.GetState().Update(this.GetTime());
        }
    }
}

