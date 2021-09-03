using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class FallZigZag : FallStrategy
    {
        // Data
        private float oldPositionX;
        private float oldPositionY;
        public FallZigZag()
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

            float targetY = oldPositionY - 1.0f * bomb.GetBoundingBoxHeight();

            if (bomb.y < targetY)
            {
                bomb.MultiplyScale(-1.0f, 1.0f);
                oldPositionY = targetY;
            }
        }
    }
}
