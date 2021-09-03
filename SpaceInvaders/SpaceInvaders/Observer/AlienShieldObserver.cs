using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class AlienShieldObserver : CollisionObserver
    {
        IrrKlang.ISoundEngine sound_engine = null;
        IrrKlang.ISound sound = null;
        public override void Notify()
        {
            sound_engine = new IrrKlang.ISoundEngine();
            sound = sound_engine.Play2D("invaderkilled.wav");
            sound.Volume = 0.2f;
        }
    }
}
