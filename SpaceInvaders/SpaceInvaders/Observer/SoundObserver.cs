using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SoundObserver : CollisionObserver
    {
        // Data
        IrrKlang.ISoundEngine sound_engine;
        public SoundObserver(IrrKlang.ISoundEngine engine)
        {
            Debug.Assert(engine != null);
            this.sound_engine = engine;
        }
        public override void Notify()
        {
            Debug.WriteLine("*** Sound Observer: {0} <-> {1}", this.Subject.Object_A.name, this.Subject.Object_B.name);

            sound_engine.SoundVolume = 0.2f;
            IrrKlang.ISound pSnd = sound_engine.Play2D("fastinvader1.wav");
        }

        
    }
}