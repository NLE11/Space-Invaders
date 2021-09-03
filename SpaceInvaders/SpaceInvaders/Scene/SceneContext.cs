using System;

namespace SpaceInvaders
{
    public class SceneContext
    {
        public SceneState SceneState;
        public SceneSelect SceneSelect;
        public SceneGameOver SceneGameOver;
        public ScenePlayer1 ScenePlayer1;
        public ScenePlayer2 ScenePlayer2;
        public SceneIntro1 SceneIntro1;
        public SceneIntro2 SceneIntro2;

        public enum Scene
        {
            Select,
            Player1,
            Player2,
            GameOver,
            Intro1,
            Intro2,
        }
        public SceneContext()
        {
            // reserve the states
            this.SceneSelect = new SceneSelect();
            this.ScenePlayer1 = new ScenePlayer1();
            this.ScenePlayer2 = new ScenePlayer2();
            this.SceneIntro1 = new SceneIntro1();
            this.SceneIntro2 = new SceneIntro2();
            this.SceneGameOver = new SceneGameOver();

            // initialize to the select state
            this.SceneState = this.SceneSelect;
            this.SceneState.Entering();
        }

        public SceneState GetState()
        {

            return this.SceneState;
        }
        public void SetState(Scene eScene)
        {
            switch (eScene)
            {
                case Scene.Select:
                    this.SceneState.Leaving();
                    this.SceneState = this.SceneSelect;
                    this.SceneState.Entering();
                    break;

                case Scene.Player1:
                    this.SceneState.Leaving();
                    this.SceneState = this.ScenePlayer1;
                    this.SceneState.Entering();
                    break;

                case Scene.Player2:
                    this.SceneState.Leaving();
                    this.SceneState = this.ScenePlayer2;
                    this.SceneState.Entering();
                    break;

                case Scene.GameOver:
                    this.SceneState.Leaving();
                    this.SceneState = this.SceneGameOver;
                    this.SceneState.Entering();
                    break;

                case Scene.Intro1:
                    this.SceneState.Leaving();
                    this.SceneState = this.SceneIntro1;
                    this.SceneState.Entering();
                    break;

                case Scene.Intro2:
                    this.SceneState.Leaving();
                    this.SceneState = this.SceneIntro2;
                    this.SceneState.Entering();
                    break;

            }
        }
    }
}