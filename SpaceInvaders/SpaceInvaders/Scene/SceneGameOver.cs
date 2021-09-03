
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SceneGameOver : SceneState
    {
        // Data
        public SpriteBatchManager SpriteBatchManager;
        public FontManager FontManager;
        public new TimerEventManager TimerEventManager;
        public SceneGameOver()
        {
            this.Initialize();
        }
        public override void Handle()
        {
            Debug.WriteLine("Handle Scene GameOver");
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
            Font font1 = FontManager.Add(Font.Name.TestMessage, SpriteBatch.Name.Texts, "SCORE <1>       HI-SCORE       SCORE <2>", Glyph.Name.Consolas36pt, 140, 850);
            Font font2 = FontManager.Add(Font.Name.TestMessage, SpriteBatch.Name.Texts, ScenePlayer1.score1.ToString(), Glyph.Name.Consolas36pt, 180, 800);
            Font font3 = FontManager.Add(Font.Name.TestMessage, SpriteBatch.Name.Texts, ScenePlayer1.maxScore.ToString(), Glyph.Name.Consolas36pt, 460, 800);
            Font font4 = FontManager.Add(Font.Name.TestMessage, SpriteBatch.Name.Texts, ScenePlayer1.score2.ToString(), Glyph.Name.Consolas36pt, 730, 800);
            font1.SetColor(0.90f, 0.90f, 0.90f);
            font2.SetColor(0.90f, 0.90f, 0.90f);
            font3.SetColor(0.90f, 0.90f, 0.90f);
            font4.SetColor(0.90f, 0.90f, 0.90f);

            TimedCharFactory.Install("GAME OVER", 1.0f, 0.10f, 410, 650, 0.9f, 0.9f, 0.9f);
            TimedCharFactory.Install("A GAME BY", 3.0f, 0.10f, 410, 580, 0.9f, 0.9f, 0.9f);
            TimedCharFactory.Install("-HO TIN NGHIA LE-", 4.0f, 0.10f, 340, 500, 0.9f, 0.9f, 0.9f);
            TimedCharFactory.Install("DEPAUL UNIVERSITY", 7.0f, 0.10f, 320, 430, 0.9f, 0.9f, 0.9f);
            TimedCharFactory.Install("SE456", 9.0f, 0.10f, 450, 360, 0.9f, 0.9f, 0.9f);
            TimedCharFactory.Install("ARCHITECTURE REAL-TIME SOFTWARE", 11.0f, 0.10f, 210, 290, 0.9f, 0.9f, 0.9f);
            TimedCharFactory.Install("Press 0 To Play Again", 13.0f, 0.10f, 300, 220, 0.9f, 0.9f, 0.9f);


        }
        int count = 0;
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

                // Do the collision checks
                CollisionPairManager.Process();

                // walk through all objects and push to flyweight
                GameObjectNodeManager.Update();

                // Delete any objects here...
                DelayedObjectManager.Process();

                if (count == 200)
                {
                    count = 0;
                    SpaceInvaders.Select = true;
                }
            } 

        }

        public override void Draw()
        {
            // draw all objects
            SpriteBatchManager.Draw();
        }

        public override void Entering()
        {
            SpaceInvaders.GameOver = false;
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