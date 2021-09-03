using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class InputManager
    {
        // Data

        private static InputManager Instance = null;
        private bool PreviousSpaceKey;

        private InputSubject ArrowRightSubject;
        private InputSubject ArrowLeftSubject;
        private InputSubject SpaceSubject;
        private InputManager()
        {
            this.ArrowLeftSubject = new InputSubject();
            this.ArrowRightSubject = new InputSubject();
            this.SpaceSubject = new InputSubject();

            this.PreviousSpaceKey = false;
        }

        private static InputManager GetInstance()
        {
            if (Instance == null)
            {
                Instance = new InputManager();
            }
            Debug.Assert(Instance != null);

            return Instance;
        }

        public static InputSubject GetArrowRightSubject()
        {
            InputManager input_manager = InputManager.GetInstance();
            return input_manager.ArrowRightSubject;
        }

        public static InputSubject GetArrowLeftSubject()
        {
            InputManager input_manager = InputManager.GetInstance();
            return input_manager.ArrowLeftSubject;
        }

        public static InputSubject GetSpaceSubject()
        {
            InputManager input_manager = InputManager.GetInstance();
            return input_manager.SpaceSubject;
        }

        public static void Update()
         {
            InputManager input_manager = InputManager.GetInstance();


            // LeftKey: (no history) -----------------------------------------------------------
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ARROW_LEFT) == true)
            {
                input_manager.ArrowLeftSubject.Notify();
            }

            // RightKey: (no history) -----------------------------------------------------------
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ARROW_RIGHT) == true)
            {
                input_manager.ArrowRightSubject.Notify();
            }

            // SpaceKey: (with key history) -----------------------------------------------------------
            bool spaceKeyCurrent = Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_SPACE);
            if (spaceKeyCurrent == true && input_manager.PreviousSpaceKey == false)
            {
                input_manager.SpaceSubject.Notify();
            }

            input_manager.PreviousSpaceKey = spaceKeyCurrent;

        }
    }
}