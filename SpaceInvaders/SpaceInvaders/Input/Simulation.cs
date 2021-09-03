using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class Simulation
    {
        private static Simulation Instance;

        private State state;

        private float stopWatch_tic;
        private float stopWatch_toc;
        private float totalWatch;
        private float timeStep;

        private const int SIM_NUM_WAKE_CYCLES = 0;
        private const float SIM_SINGLE_TIME_STEP = 0.016666f;

        private static bool oldKey = false;
        public enum State
        {
            Realtime,
            FixedStep,
            SingleStep,
            Pause
        };

        // Retrieve Instance to use
        private static Simulation GetInstance()
        {
            // Safety - this forces users to call Create() first before using class
            Debug.Assert(Instance != null);
            return Instance;
        }

        public static void Create()
        {
            // Start the singleton
            Debug.Assert(Instance == null);

            // Do the initialization
            if (Instance == null)
            {
                Instance = new Simulation(); //Set up default singleton
            }
        }

        public static void Update(float systemTime)
        {
            Simulation simulation = Simulation.GetInstance();
            Debug.Assert(simulation != null);

            // update input
            simulation.ProcessInput();

            // Time update.
            //      Get the time that has passed.
            //      Feels backwards, but its not, need to see how much time has passed
            simulation.stopWatch_toc = systemTime - simulation.stopWatch_tic;
            simulation.stopWatch_tic = systemTime;

            if (simulation.GetState() == State.FixedStep)
            {
                simulation.timeStep = SIM_SINGLE_TIME_STEP;
            }
            else if (simulation.GetState() == State.Realtime)
            {
                simulation.timeStep = simulation.stopWatch_toc;
            }
            else if (simulation.GetState() == State.SingleStep)
            {
                simulation.timeStep = SIM_SINGLE_TIME_STEP;
                simulation.SetCurrentState(State.Pause); // After step then pause
            }
            else //  pSim->getState() == SimulationEnum::Pause
            {
                simulation.timeStep = 0.0f;
            }

            simulation.totalWatch += simulation.timeStep;

        }


        // *** Simulation controls ***
        //   Key S - single step
        //   Key D - repeat step while holding
        //   Key G - start simulation fixed step
        //   Key H - start simulation realtime stepping
        private void ProcessInput()
        {
            //  SIMULATION Controls 

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_G) == true)
            {
                this.SetCurrentState(State.FixedStep);
            }
            else if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_H) == false)
            {
                this.SetCurrentState(State.Realtime);
            }
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_S) && oldKey == false)
            {
                // Step once
                this.SetCurrentState(State.SingleStep);
            }
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_D) == true)
            {
                // Repeat the step when holding key D
                this.SetCurrentState(State.SingleStep);
            }

            oldKey = Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_S);

        }

        // Get / Set State

        private void SetCurrentState(State simulation_state)
        {
            this.state = simulation_state;
        }
        private State GetState()
        {
            return this.state;
        }
        public static void SetThisState(State simulation_state)
        {
            Simulation simulation = Simulation.GetInstance();
            Debug.Assert(simulation != null);

            simulation.SetCurrentState(simulation_state);
        }
        public static State GetCurrentState()
        {
            Simulation simulation = Simulation.GetInstance();
            Debug.Assert(simulation != null);

            return simulation.GetState();
        }
        public static float GetTimeStep()
        {
            Simulation simulation = Simulation.GetInstance();
            Debug.Assert(simulation != null);
            return simulation.timeStep;
        }
        public static float GetTotalTime()
        {
            Simulation simulation = Simulation.GetInstance();
            Debug.Assert(simulation != null);
            return simulation.totalWatch;
        }

        private Simulation()
        {
            this.state = State.SingleStep;

            this.timeStep = 0.0f;
            this.totalWatch = 0.0f;
            this.stopWatch_tic = 0.0f;
            this.stopWatch_toc = 0.0f;
        }
    }
}
