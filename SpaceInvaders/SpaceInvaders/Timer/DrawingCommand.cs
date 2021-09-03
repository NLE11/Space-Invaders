using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class DrawingCommand : Command
    {
        private GameObject game_object;
        private SpriteBatch batch;

        public DrawingCommand(GameObject game_object, SpriteBatch batch)
        {
            this.game_object = GameObjectNodeManager.Find(game_object.name);
            this.batch = batch;
            Debug.Assert(this.game_object != null);
        }

        public override void Execute(float deltaTime)
        {
            this.game_object.ActivateSprite(this.batch);
        }
    }
}
