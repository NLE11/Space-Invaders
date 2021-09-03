using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class RemoveAlienObserver : CollisionObserver
    {
        IrrKlang.ISoundEngine sound_engine = null;
        IrrKlang.ISound sound = null;
        private GameObject Alien;
        public RemoveAlienObserver()
        {
            this.Alien = null;
        }
        public RemoveAlienObserver(RemoveAlienObserver observer)
        {
            this.Alien = observer.Alien;
        }
        public override void Notify()
        {
            // Delete missile
            //Debug.WriteLine("RemoveMissileObserver: {0} {1}", this.pSubject.pObjA, this.pSubject.pObjB);

            this.Alien = (Leaf)this.Subject.Object_B;
            ScenePlayer1.splatX = this.Subject.Object_B.x;
            ScenePlayer1.splatY = this.Subject.Object_B.y;


            Debug.Assert(this.Alien != null);

            if (Alien.MarkForDeath == false)
            {
                Alien.MarkForDeath = true;
                //   Delay
                RemoveAlienObserver observer = new RemoveAlienObserver(this);
                DelayedObjectManager.Attach(observer);
            }
        }
        public override void Execute()
        {
            sound_engine = new IrrKlang.ISoundEngine();
            sound = sound_engine.Play2D("invaderkilled.wav");
            sound.Volume = 0.2f;

            SceneState state = SpaceInvaders.SceneContext.GetState();
            if (state == SpaceInvaders.SceneContext.ScenePlayer1)
            {
                if (Alien.name == GameObject.Name.Squid1 || Alien.name == GameObject.Name.Squid2)
                {
                    ScenePlayer1.score1 += 30;
                }
                if (Alien.name == GameObject.Name.Crab1 || Alien.name == GameObject.Name.Crab2)
                {
                    ScenePlayer1.score1 += 20;
                }
                if (Alien.name == GameObject.Name.Octopus1 || Alien.name == GameObject.Name.Octopus2)
                {
                    ScenePlayer1.score1 += 10;
                }
            }
            if (state == SpaceInvaders.SceneContext.ScenePlayer2)
            {
                if (Alien.name == GameObject.Name.Squid1 || Alien.name == GameObject.Name.Squid2)
                {
                    ScenePlayer1.score2 += 30;
                }
                if (Alien.name == GameObject.Name.Crab1 || Alien.name == GameObject.Name.Crab2)
                {
                    ScenePlayer1.score2 += 20;
                }
                if (Alien.name == GameObject.Name.Octopus1 || Alien.name == GameObject.Name.Octopus2)
                {
                    ScenePlayer1.score2 += 10;
                }

            }

            
            
            // Update Score 1
            Font oldScore1 = FontManager.Find(Font.Name.ScoreBoard1);
            FontManager.Remove(oldScore1);
            Font newScore1 = FontManager.Add(Font.Name.ScoreBoard1, SpriteBatch.Name.Texts, ScenePlayer1.score1.ToString(), Glyph.Name.Consolas36pt, 180, 800);
            newScore1.SetColor(0.90f, 0.90f, 0.90f);
            // Update Score 2
            Font oldScore2 = FontManager.Find(Font.Name.ScoreBoard2);
            FontManager.Remove(oldScore2);
            Font newScore2 = FontManager.Add(Font.Name.ScoreBoard2, SpriteBatch.Name.Texts, ScenePlayer1.score2.ToString(), Glyph.Name.Consolas36pt, 730, 800);
            newScore2.SetColor(0.90f, 0.90f, 0.90f);

            // Update Max Score
            if (ScenePlayer1.score1 > ScenePlayer1.score2)
            {
                ScenePlayer1.maxScore = ScenePlayer1.score1;
            }
            else ScenePlayer1.maxScore = ScenePlayer1.score2;

            Font oldMaxScore = FontManager.Find(Font.Name.ScoreBoardMax);
            FontManager.Remove(oldMaxScore);
            Font newMaxScore = FontManager.Add(Font.Name.ScoreBoardMax, SpriteBatch.Name.Texts, ScenePlayer1.maxScore.ToString(), Glyph.Name.Consolas36pt, 460, 800);
            newMaxScore.SetColor(0.90f, 0.90f, 0.90f);


            // Remove Alien
            Alien.Remove();
            SplatRoot splat_root = (SplatRoot)GameObjectNodeManager.Find(GameObject.Name.SplatRoot);
            splat_root.SetPos(ScenePlayer1.splatX, ScenePlayer1.splatY);
            
            ScenePlayer1.killedcount++;

            GameObject parent = (GameObject)CompositeForwardIterator.GetParent(Alien);
            if ((GameObject)CompositeForwardIterator.GetChild(parent) == null)
            {
                parent.Remove();
            }
        }
    }
}
