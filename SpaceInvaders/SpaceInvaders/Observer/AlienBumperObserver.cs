using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class AlienBumperObserver : CollisionObserver
    {

        public override void Notify()
        {
            AlienRoot alien_root = (AlienRoot)GameObjectNodeManager.Find(GameObject.Name.AlienRoot);

            BumperCategory Bumper = (BumperCategory)this.Subject.Object_A;

            if (Bumper.GetCategoryType() == BumperCategory.Type.Left)
            {
                if (AlienManager.instance == null)
                {
                    AlienManager.Create(alien_root);
                }
                if (alien_root.alienSpeedY < 0 && alien_root.moving_state == AlienManager.GetMoveState(AlienManager.MoveState.MoveRight))
                {
                    alien_root.alienSpeedY = 0;
                    if (ScenePlayer1.killedcount > 5 && ScenePlayer1.killedcount < 10)
                    {
                        alien_root.alienSpeedX = 20;
                    }
                    else if (ScenePlayer1.killedcount > 10)
                    {
                        alien_root.alienSpeedX = 30;
                    }
                    else
                    {
                        alien_root.alienSpeedX = 10;
                    }
                }
                else
                {
                    alien_root.SetDelta(0.0f, -20.0f);
                    alien_root.SetMoveState(AlienManager.MoveState.MoveRight);
                    Debug.WriteLine("collide left");
                }
            }
            else if (Bumper.GetCategoryType() == BumperCategory.Type.Right)
            {
                if (AlienManager.instance == null)
                {
                    AlienManager.Create(alien_root);
                }

                if (alien_root.alienSpeedY < 0 && alien_root.moving_state == AlienManager.GetMoveState(AlienManager.MoveState.MoveLeft))
                {
                    alien_root.alienSpeedY = 0;
                    if (ScenePlayer1.killedcount > 5 && ScenePlayer1.killedcount < 10)
                    {
                        alien_root.alienSpeedX = -20;
                    }
                    else if (ScenePlayer1.killedcount > 10)
                    {
                        alien_root.alienSpeedX = -30;
                    }
                    else
                    {
                        alien_root.alienSpeedX = -10;
                    }
                }
                else
                {
                    alien_root.SetDelta(0.0f, -20.0f);
                    alien_root.SetMoveState(AlienManager.MoveState.MoveLeft);
                    Debug.WriteLine("collide left");
                }
            }

        }
    }
}
