using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ResetUFOObserver : CollisionObserver
    {
        IrrKlang.ISoundEngine sound_engine = null;
        IrrKlang.ISound music = null;
        private UFORoot UFORoot;
        public ResetUFOObserver()
        {
            this.UFORoot = null;
        }
        public ResetUFOObserver(ResetUFOObserver observer)
        {
            this.UFORoot = observer.UFORoot;
        }
        public override void Notify()
        {
            BumperCategory Bumper = (BumperCategory)this.Subject.Object_B;
            UFORoot UFORoot = (UFORoot)this.Subject.Object_A;
            if (Bumper.GetCategoryType() == BumperCategory.Type.Left)
            {
                UFORoot.UFOSpeedX = 2.0f;
            }
            else if (Bumper.GetCategoryType() == BumperCategory.Type.Right)
            {
                UFORoot.UFOSpeedX = -2.0f;
            }
            sound_engine = new IrrKlang.ISoundEngine();
            music = sound_engine.Play2D("ufo_lowpitch.wav");
            music.Volume = 0.1f;

        }
    }
}
