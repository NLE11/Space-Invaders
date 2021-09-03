using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class TimedCharFactory
    {

        // Data

        private static TimedCharFactory Instance = null;

        private TimedCharFactory()
        {
            
        }

        static public void Install(string message, float deltaTimeToTrigger, float delayTime, float xPosition, float yPosition, float red, float green, float blue)
        {
            TimedCharFactory Instance = TimedCharFactory.GetInstance();
            // future use

            TimedCharCommand command = null;

            for (int i = 0; i < message.Length; i++)
            {
                string current_char = message.Substring(0, i + 1);

                TimedCharCommand new_command = new TimedCharCommand(command, current_char, xPosition, yPosition, red, green, blue);

                float time = deltaTimeToTrigger + i * delayTime; //when will this happens
                TimerEventManager.AddToIndex(TimerEvent.Name.TimedChar, new_command, time);

                command = new_command;
            }
        }


        private static TimedCharFactory GetInstance()
        {
            if (Instance == null)
            {
                TimedCharFactory.Instance = new TimedCharFactory();
            }

            Debug.Assert(Instance != null);

            return Instance;
        }
    }
}
