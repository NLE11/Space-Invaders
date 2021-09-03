using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class MovementCommand : Command
    {
        IrrKlang.ISoundEngine sound_engine;


        public MovementCommand(IrrKlang.ISoundEngine sound_engine)
        {
            this.sound_engine = sound_engine;
        }

        public override void Execute(float deltaTime)
        {
            AlienRoot alien_root = (AlienRoot)GameObjectNodeManager.Find(GameObject.Name.AlienRoot);
            alien_root.MoveRoot();

            // Setup Sound
            SpaceInvaders.count++;
            if (SpaceInvaders.count == 4)
            {
                SpaceInvaders.count = 0;
            }
            int count = SpaceInvaders.count;

            switch (count)
            {
                case 0:
                    sound_engine.Play2D(ScenePlayer1.soundWalk1, false, false, false);
                    break;
                case 1:
                    sound_engine.Play2D(ScenePlayer1.soundWalk2, false, false, false);
                    break;
                case 2:
                    sound_engine.Play2D(ScenePlayer1.soundWalk3, false, false, false);
                    break;
                case 3:
                    sound_engine.Play2D(ScenePlayer1.soundWalk4, false, false, false);
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }

            Debug.WriteLine("Count: {0}", count);
            TimerEventManager.AddToIndex(TimerEvent.Name.ObjectMovement, this, deltaTime);
        }
    }
}
