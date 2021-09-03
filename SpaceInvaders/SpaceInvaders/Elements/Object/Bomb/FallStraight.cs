using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class FallStraight : FallStrategy
    {
        // Data
        private float oldPositionX;
        private float oldPositionY;
        public FallStraight()
        {
            this.oldPositionX = 0.0f;
            this.oldPositionY = 0.0f;
        }

        public override void Reset(float posX, float posY)
        {
            this.oldPositionX = posX;
            this.oldPositionY = posY;
        }

        public override void Fall(Bomb bomb)
        {
            Debug.Assert(bomb != null);
        }
    }
}
