using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShootObserver : InputObserver
    {
        IrrKlang.ISoundEngine sound_engine = null;
        IrrKlang.ISound sound = null;
        public override void Notify()
        {
            Debug.WriteLine("\nShoot Observer - Space tapped!");
            Ship ship = ShipManager.GetShip();
            ship.ShootMissile();
            sound_engine = new IrrKlang.ISoundEngine();
            sound = sound_engine.Play2D("shoot.wav");
            sound.Volume = 0.01f;
        }
    }
}
