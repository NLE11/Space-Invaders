
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SceneSelect : SceneState
    {
        // Create Sound Manager
        IrrKlang.ISoundEngine sound_engine = null;
        IrrKlang.ISound music = null;

        // Data

        public SpriteBatchManager SpriteBatchManager;
        public FontManager FontManager;
        public new TimerEventManager TimerEventManager;
        public GameObjectNodeManager GONMan;

        DrawingCommand Draw_Command1;
        DrawingCommand Draw_Command2;
        DrawingCommand Draw_Command3;
        DrawingCommand Draw_Command4;
        GameObject Squid1;
        GameObject Crab1;
        GameObject Octopus1;
        GameObject UFOSelect;
        SpriteBatch SB_Texts;
        public SceneSelect()
        {
            this.Initialize();
        }
        public override void Handle()
        {
            Debug.WriteLine("Handle Scene Select");
        }
        public override void Initialize()
        {
            this.SpriteBatchManager = new SpriteBatchManager(3, 1);
            SpriteBatchManager.SetActive(this.SpriteBatchManager);

            this.FontManager = new FontManager(3, 1);
            FontManager.SetActive(this.FontManager);

            this.TimerEventManager = new TimerEventManager(3, 1);
            TimerEventManager.SetActive(this.TimerEventManager);

            this.GONMan = new GameObjectNodeManager(3, 1);
            GameObjectNodeManager.SetActive(this.GONMan);

        }
        private void LoadOnEntry()
        {
            SB_Texts = SpriteBatchManager.Add(SpriteBatch.Name.Texts);

            sound_engine = new IrrKlang.ISoundEngine();
            music = sound_engine.Play2D("theme.wav");
            music.Volume = 0.2f;

            Texture texture = TextureManager.Add(Texture.Name.Consolas36pt, "Consolas36pt.tga");
            GlyphManager.AddXml(Glyph.Name.Consolas36pt, "Consolas36pt.xml", Texture.Name.Consolas36pt);

            Font font1 = FontManager.Add(Font.Name.TestMessage, SpriteBatch.Name.Texts, "SCORE <1>       HI-SCORE       SCORE <2>", Glyph.Name.Consolas36pt, 140, 850);
            Font font2 = FontManager.Add(Font.Name.TestMessage, SpriteBatch.Name.Texts, "0000", Glyph.Name.Consolas36pt, 180, 800);
            Font font3 = FontManager.Add(Font.Name.TestMessage, SpriteBatch.Name.Texts, "0000", Glyph.Name.Consolas36pt, 460, 800);
            Font font4 = FontManager.Add(Font.Name.TestMessage, SpriteBatch.Name.Texts, "0000", Glyph.Name.Consolas36pt, 730, 800);
            font1.SetColor(0.90f, 0.90f, 0.90f);
            font2.SetColor(0.90f, 0.90f, 0.90f);
            font3.SetColor(0.90f, 0.90f, 0.90f);
            font4.SetColor(0.90f, 0.90f, 0.90f);

            TextureManager.Add(Texture.Name.Aliens, "Invaders_1.tga");

            ImageManager.Add(Image.Name.Squid1, Texture.Name.Aliens, 300, 20, 100, 100);
            ImageManager.Add(Image.Name.Crab1, Texture.Name.Aliens, 10, 20, 120, 90);
            ImageManager.Add(Image.Name.Octopus1, Texture.Name.Aliens, 0, 160, 135, 95);
            ImageManager.Add(Image.Name.UFOSelect, Texture.Name.Aliens, 50, 320, 120, 80);

            SpriteManager.Add(Sprite.Name.Squid1, Image.Name.Squid1, 400, 500, 50, 50);
            SpriteManager.Add(Sprite.Name.Crab1, Image.Name.Crab1, 230, 500, 50, 50);
            SpriteManager.Add(Sprite.Name.Octopus1, Image.Name.Octopus1, 230, 500, 50, 50);
            SpriteManager.Add(Sprite.Name.UFOSelect, Image.Name.UFOSelect, 230, 200, 50, 50);

            // SpriteBatch Aliens_SpriteBatch = SpriteBatchManager.Add(SpriteBatch.Name.Aliens);
            Squid1 = new Squid1(Sprite.Name.Squid1, 390, 360);
            Crab1 = new Crab1(Sprite.Name.Crab1, 390, 290);
            Octopus1 = new Octopus1(Sprite.Name.Octopus1, 390, 220);
            UFOSelect = new UFOSelect(Sprite.Name.UFOSelect, 390, 430);

            GameObjectNodeManager.Attach(Squid1);
            GameObjectNodeManager.Attach(Crab1);
            GameObjectNodeManager.Attach(Octopus1);
            GameObjectNodeManager.Attach(UFOSelect);

            TimedCharFactory.Install("PLAY", 1.0f, 0.10f, 460, 650, 0.9f, 0.9f, 0.9f);
            TimedCharFactory.Install("SPACE  INVADERS", 2.0f, 0.10f, 360, 580, 0.9f, 0.9f, 0.9f);
            TimedCharFactory.Install("* SCORE ADVANCE TABLE *", 4.0f, 0.10f, 270, 500, 0.9f, 0.9f, 0.9f);
            Draw_Command1 = new DrawingCommand(UFOSelect, SB_Texts);
            TimerEventManager.AddToIndex(TimerEvent.Name.Draw, Draw_Command1, 6.9f);
            TimedCharFactory.Install("= 100 POINTS", 7.0f, 0.10f, 430, 430, 0.2f, 0.8f, 0.2f);
            Draw_Command2 = new DrawingCommand(Squid1, SB_Texts);
            TimerEventManager.AddToIndex(TimerEvent.Name.Draw, Draw_Command2, 8.9f);
            TimedCharFactory.Install("= 30 POINTS", 9.0f, 0.10f, 430, 360, 0.9f, 0.9f, 0.9f);
            Draw_Command3 = new DrawingCommand(Crab1, SB_Texts);
            TimerEventManager.AddToIndex(TimerEvent.Name.Draw, Draw_Command3, 10.9f);
            TimedCharFactory.Install("= 20 POINTS", 11.0f, 0.10f, 430, 290, 0.9f, 0.9f, 0.9f);
            Draw_Command4 = new DrawingCommand(Octopus1, SB_Texts);
            TimerEventManager.AddToIndex(TimerEvent.Name.Draw, Draw_Command4, 12.9f);
            TimedCharFactory.Install("= 10 POINTS", 13.0f, 0.10f, 430, 220, 0.9f, 0.9f, 0.9f);
            TimedCharFactory.Install("Press E to Continue", 15.0f, 0.10f, 320, 150, 0.9f, 0.9f, 0.9f);
        }

        public override void Update(float systemTime)
        {

            
            // Single Step, Free running...
            Simulation.Update(systemTime);

            // Input
            InputManager.Update();

            // Run based on simulation stepping
            if (Simulation.GetTimeStep() > 0.0f)
            {
                // Fire off the timer events
                TimerEventManager.Update(Simulation.GetTotalTime());

                // walk through all objects and push to flyweight
                GameObjectNodeManager.Update();

                // Delete any objects here...
                DelayedObjectManager.Process();
            }
        }

        public override void Draw()
        {
            // draw all objects
            SpriteBatchManager.Draw();
        }

        public override void Entering()
        {
            SpriteBatchManager.SetActive(this.SpriteBatchManager);
            FontManager.SetActive(this.FontManager);
            TimerEventManager.SetActive(this.TimerEventManager);

            Debug.WriteLine("\nCreate Font Manager\n");
            FontManager.Dump();
            Debug.WriteLine("\nCreate Timer Event Manager\n");
            TimerEventManager.Dump();
            Debug.WriteLine("\nCreate Sprite Batch Manager\n");
            SpriteBatchManager.Dump();

            // FontMan.RemoveAll();

            // Update timer since last pause
            float t0 = GlobalTimer.GetTime();
            float t1 = this.TimeAtPause;
            float delta = t0 - t1;
            TimerEventManager.PauseUpdate(delta);


            this.LoadOnEntry();
        }
        public override void Leaving()
        {
            this.TimeAtPause = GlobalTimer.GetTime();
            music.Volume = 0;
        }
    }
}