using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class BombShipObserver : CollisionObserver
    {
        IrrKlang.ISoundEngine sound_engine = null;
        IrrKlang.ISound sound = null;
        private GameObject ship1;
        private GameObject ship2;
        private GameObject ship3;
        public BombShipObserver()
        {
            this.ship1 = null;
            this.ship2 = null;
            this.ship3 = null;
        }
        public BombShipObserver(BombShipObserver observer)
        {
            this.ship1 = observer.ship1;
            this.ship2 = observer.ship2;
            this.ship3 = observer.ship3;
        }
        public override void Notify()
        {
            sound_engine = new IrrKlang.ISoundEngine();
            sound = sound_engine.Play2D("explosion.wav");
            sound.Volume = 0.3f;
            GameObject ShipMiniRoot = GameObjectNodeManager.Find(GameObject.Name.ShipMiniRoot);
            GameObject child = (GameObject)CompositeForwardIterator.GetChild(ShipMiniRoot);
            if (child != null)
            {
                child.Remove();

                
                SceneState state = SpaceInvaders.SceneContext.GetState();
                if (state == SpaceInvaders.SceneContext.ScenePlayer1)
                {
                    ScenePlayer1.lives1--;
                    Debug.WriteLine("Player1's lives: {0}", ScenePlayer1.lives1);
                    if (ScenePlayer1.lives2 != 0)
                    {
                        SpaceInvaders.Intro2 = true;
                    }
                    else SpaceInvaders.GameOver = true;
                }
                if (state == SpaceInvaders.SceneContext.ScenePlayer2)
                {
                    ScenePlayer1.lives2--;
                    Debug.WriteLine("Player1's lives: {0}", ScenePlayer1.lives1);
                    if (ScenePlayer1.lives1 != 0)
                    {
                        SpaceInvaders.Intro1 = true;
                    }
                    else SpaceInvaders.GameOver = true;

                }
            }
        }
    }
}
