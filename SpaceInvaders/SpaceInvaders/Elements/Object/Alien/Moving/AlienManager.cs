using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class AlienManager
    {
        // Data
        public static AlienManager instance = null;

        // Active
        private AlienRoot AlienRoot;

        // Reference

        private AlienMoveLeft StateMoveLeft;
        private AlienMoveRight StateMoveRight;


        public enum MoveState
        {
            MoveRight,
            MoveLeft,
            MoveUp,
            MoveDown
        }

        private AlienManager(AlienRoot alien_root)
        {
            // Store the states
            this.StateMoveRight = new AlienMoveRight();
            this.StateMoveLeft = new AlienMoveLeft();

            // set active
            this.AlienRoot = alien_root;
        }

        public static void Create(AlienRoot alien_root)
        {
            // make sure its the first time
            Debug.Assert(instance == null);

            // Do the initialization
            if (instance == null)
            {
                instance = new AlienManager(alien_root);
            }

            Debug.Assert(instance != null);

            // Stuff to initialize after the instance was created
            instance.AlienRoot.SetMoveState(AlienManager.MoveState.MoveRight);
        }

        private static AlienManager GetInstance()
        {
            Debug.Assert(instance != null);

            return instance;
        }

        public static AlienMoveState GetMoveState(MoveState state)
        {
            AlienManager manager = AlienManager.GetInstance();
            Debug.Assert(manager != null);

            AlienMoveState alien_move_state = null;

            switch (state)
            {
                case AlienManager.MoveState.MoveLeft:
                    alien_move_state = manager.StateMoveLeft;
                    break;

                case AlienManager.MoveState.MoveRight:
                    alien_move_state = manager.StateMoveRight;
                    break;

                default:
                    Debug.Assert(false);
                    break;
            }

            return alien_move_state;
        }
    }
}