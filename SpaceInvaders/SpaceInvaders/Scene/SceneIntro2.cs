
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SceneIntro2 : SceneState
    {
        // Data
        public SpriteBatchManager SpriteBatchManager;
        public FontManager FontManager;
        public new TimerEventManager TimerEventManager;
        public SceneIntro2()
        {
            this.Initialize();
        }
        public override void Handle()
        {
            Debug.WriteLine("Handle Scene Intro 1");
        }
        public override void Initialize()
        {
            this.SpriteBatchManager = new SpriteBatchManager(3, 1);
            SpriteBatchManager.SetActive(this.SpriteBatchManager);

            this.FontManager = new FontManager(3, 1);
            FontManager.SetActive(this.FontManager);

            this.TimerEventManager = new TimerEventManager(3, 1);
            TimerEventManager.SetActive(this.TimerEventManager);

            SpriteBatch SB_Texts = SpriteBatchManager.Add(SpriteBatch.Name.Texts);


            Texture texture = TextureManager.Add(Texture.Name.Consolas36pt, "Consolas36pt.tga");
            GlyphManager.AddXml(Glyph.Name.Consolas36pt, "Consolas36pt.xml", Texture.Name.Consolas36pt);

        }
        private void LoadOnEntry()
        {
            Font font = FontManager.Add(Font.Name.TestMessage, SpriteBatch.Name.Texts, "PLAYER 2", Glyph.Name.Consolas36pt, 440, 450);
            font.SetColor(0.90f, 0.90f, 0.90f);
        }
        int count = 0;
        public override void Update(float systemTime)
        {
            count++;
            // Single Step, Free running...
            Simulation.Update(systemTime);

            // Input
            InputManager.Update();

            // Run based on simulation stepping
            if (Simulation.GetTimeStep() > 0.0f)
            {
                // Fire off the timer events
                TimerEventManager.Update(Simulation.GetTotalTime());

                // Do the collision checks
                CollisionPairManager.Process();

                // walk through all objects and push to flyweight
                GameObjectNodeManager.Update();

                // Delete any objects here...
                DelayedObjectManager.Process();

                
            }
            if (count == 100)
            {
                count = 0;
                SpaceInvaders.Player2 = true;
            }

        }

        public override void Draw()
        {
            // draw all objects
            SpriteBatchManager.Draw();
        }

        public override void Entering()
        {
            SpaceInvaders.Intro2 = false;
            SpriteBatchManager.SetActive(this.SpriteBatchManager);
            FontManager.SetActive(this.FontManager);
            TimerEventManager.SetActive(this.TimerEventManager);

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
        }
    }
}