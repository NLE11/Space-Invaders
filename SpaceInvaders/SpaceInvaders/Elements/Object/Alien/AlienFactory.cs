using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class AlienFactory
    {
        // Data:
        private SpriteBatch SpriteBatch;
        private SpriteBatch CollisionSpriteBatch;
        private Composite Tree;
        private static AlienFactory Instance = null;
        GameObjectNodeManager MANAGER = GameObjectNodeManager.GetInstance();

        private AlienFactory()
        {
            this.SpriteBatch = null;
            this.CollisionSpriteBatch = null;
            this.Tree = null;
        }
        public void Set(SpriteBatch.Name spriteBatchName, SpriteBatch.Name collisionSpriteBatch, Composite Tree)
        {
            this.SpriteBatch = SpriteBatchManager.Find(spriteBatchName);
            Debug.Assert(this.SpriteBatch != null);

            this.CollisionSpriteBatch = SpriteBatchManager.Find(collisionSpriteBatch);
            Debug.Assert(this.CollisionSpriteBatch != null);

            Debug.Assert(Tree != null);
            this.Tree = Tree;
        }
        public void SetParent(GameObject ParentNode)
        {
            // OK being null
            Debug.Assert(ParentNode != null);
            this.Tree = (Composite)ParentNode;
        }
        ~AlienFactory()
        {
            
        }
        public GameObject Create(AlienCategory.Type type, GameObject.Name gameName, float posX = 0.0f, float posY = 0.0f)
        {
            GameObject alien = null;

            GameObjectNode game_node = GhostManager.Find(gameName);
            if (game_node != null)
            {
                Debug.WriteLine("Recycling Root");
                alien = game_node.GameObject;
                GhostManager.Remove(game_node);
                //GhostManager.Dump();

                switch (type)
                {
                    case AlienCategory.Type.Squid1:
                        ((Squid1)alien).Resurrect(posX, posY);
                        break;
                    case AlienCategory.Type.Squid2:
                        ((Squid2)alien).Resurrect(posX, posY);
                        break;
                    case AlienCategory.Type.Crab1:
                        ((Crab1)alien).Resurrect(posX, posY);
                        break;
                    case AlienCategory.Type.Crab2:
                        ((Crab2)alien).Resurrect(posX, posY);
                        break;
                    case AlienCategory.Type.Crab3:
                        ((Crab1)alien).Resurrect(posX, posY);
                        break;
                    case AlienCategory.Type.Crab4:
                        ((Crab2)alien).Resurrect(posX, posY);
                        break;
                    case AlienCategory.Type.Octopus1:
                        ((Octopus1)alien).Resurrect(posX, posY);
                        break;
                    case AlienCategory.Type.Octopus2:
                        ((Octopus2)alien).Resurrect(posX, posY);
                        break;
                    case AlienCategory.Type.Octopus3:
                        ((Octopus1)alien).Resurrect(posX, posY);
                        break;
                    case AlienCategory.Type.Octopus4:
                        ((Octopus2)alien).Resurrect(posX, posY);
                        break;

                    case AlienCategory.Type.AlienColumn:
                        ((AlienColumn)alien).Resurrect(posX, posY); ;
                        break;

                    default:
                        // something is wrong
                        Debug.Assert(false);
                        break;
                } 
            }
            else
            {
                switch (type)
                {
                    case AlienCategory.Type.Squid1:
                        alien = new Squid1(Sprite.Name.Squid1, posX, posY);
                        break;

                    case AlienCategory.Type.Squid2:
                        alien = new Squid2(Sprite.Name.Squid2, posX, posY);
                        break;

                    case AlienCategory.Type.Crab1:
                        alien = new Crab1(Sprite.Name.Crab1, posX, posY);
                        break;

                    case AlienCategory.Type.Crab2:
                        alien = new Crab2(Sprite.Name.Crab2, posX, posY);
                        break;

                    case AlienCategory.Type.Crab3:
                        alien = new Crab1(Sprite.Name.Crab3, posX, posY);
                        break;

                    case AlienCategory.Type.Crab4:
                        alien = new Crab2(Sprite.Name.Crab4, posX, posY);
                        break;

                    case AlienCategory.Type.Octopus1:
                        alien = new Octopus1(Sprite.Name.Octopus1, posX, posY);
                        break;

                    case AlienCategory.Type.Octopus2:
                        alien = new Octopus2(Sprite.Name.Octopus2, posX, posY);
                        break;

                    case AlienCategory.Type.Octopus3:
                        alien = new Octopus1(Sprite.Name.Octopus3, posX, posY);
                        break;

                    case AlienCategory.Type.Octopus4:
                        alien = new Octopus2(Sprite.Name.Octopus4, posX, posY);
                        break;

                    case AlienCategory.Type.AlienColumn:
                        alien = new AlienColumn(gameName, Sprite.Name.Null_Object, SpriteBox.Name.Null_Object, posX, posY);
                        alien.SetCollisionColor(1.0f, 0.0f, 0.0f);
                        break;

                    default:
                        // something is wrong
                        Debug.Assert(false);
                        break;
                }
            }
            

            // add to the tree
            this.Tree.Add(alien);

            // Attached to Group
            alien.ActivateSprite(this.SpriteBatch);
            alien.ActivateCollisionSprite(this.CollisionSpriteBatch);

            return alien;
        }

        private static AlienFactory GetInstance()
        {
            if (Instance == null)
            {
                AlienFactory.Instance = new AlienFactory();
            }

            Debug.Assert(Instance != null);

            return Instance;
        }

        public static AlienRoot NewAlienRoot()
        {
            GameObjectNodeManager MANAGER = GameObjectNodeManager.GetInstance();
            AlienFactory AF = AlienFactory.GetInstance();
            AlienRoot alien_root = null;
            
            GameObjectNode game_node = GhostManager.Find(GameObject.Name.AlienRoot);
            //GhostManager manager = GhostManager.GetInstance();

            if(game_node == null)
            {
                alien_root = new AlienRoot(GameObject.Name.AlienRoot, Sprite.Name.Null_Object, SpriteBox.Name.Null_Object, 0.0f, 0.0f);
                GhostManager.Attach(alien_root);
                GameObjectNodeManager.Attach(alien_root);
            }
            else
            {
                alien_root = (AlienRoot)game_node.GameObject;
            }

            
            AF.Set(SpriteBatch.Name.Aliens, SpriteBatch.Name.Boxes, alien_root);
            

            int j = 0;

            GameObject Column;

            AF.SetParent(alien_root);
            Column = AF.Create(AlienCategory.Type.AlienColumn, GameObject.Name.AlienColumn_0 + j++);
            GameObjectNodeManager.Attach(Column);

            AF.SetParent(Column);

            float start_x = 150.0f;
            float start_y = 400.0f;
            float off_x = 0;
            float width = 50.0f;
            float height = 50.0f;

            AF.Create(AlienCategory.Type.Octopus1, GameObject.Name.Octopus2, start_x, start_y);
            AF.Create(AlienCategory.Type.Octopus1, GameObject.Name.Octopus1, start_x, start_y + height);
            AF.Create(AlienCategory.Type.Crab1, GameObject.Name.Crab2, start_x, start_y + 2 * height);
            AF.Create(AlienCategory.Type.Crab1, GameObject.Name.Crab1, start_x, start_y + 3 * height);
            AF.Create(AlienCategory.Type.Squid1, GameObject.Name.Squid1, start_x, start_y + 4 * height);


            AF.SetParent(alien_root);
            Column = AF.Create(AlienCategory.Type.AlienColumn, GameObject.Name.AlienColumn_0 + j++);
            GameObjectNodeManager.Attach(Column);

            AF.SetParent(Column);

            off_x += width + 10;
            AF.Create(AlienCategory.Type.Octopus1, GameObject.Name.Octopus2, start_x + off_x, start_y);
            AF.Create(AlienCategory.Type.Octopus1, GameObject.Name.Octopus1, start_x + off_x, start_y + height);
            AF.Create(AlienCategory.Type.Crab1, GameObject.Name.Crab2, start_x + off_x, start_y + 2 * height);
            AF.Create(AlienCategory.Type.Crab1, GameObject.Name.Crab1, start_x + off_x, start_y + 3 * height);
            AF.Create(AlienCategory.Type.Squid1, GameObject.Name.Squid1, start_x + off_x, start_y + 4 * height);

            AF.SetParent(alien_root);
            Column = AF.Create(AlienCategory.Type.AlienColumn, GameObject.Name.AlienColumn_0 + j++);
            GameObjectNodeManager.Attach(Column);

            AF.SetParent(Column);

            off_x += width + 10;
            AF.Create(AlienCategory.Type.Octopus1, GameObject.Name.Octopus2, start_x + off_x, start_y);
            AF.Create(AlienCategory.Type.Octopus1, GameObject.Name.Octopus1, start_x + off_x, start_y + height);
            AF.Create(AlienCategory.Type.Crab1, GameObject.Name.Crab2, start_x + off_x, start_y + 2 * height);
            AF.Create(AlienCategory.Type.Crab1, GameObject.Name.Crab1, start_x + off_x, start_y + 3 * height);
            AF.Create(AlienCategory.Type.Squid1, GameObject.Name.Squid1, start_x + off_x, start_y + 4 * height);

            AF.SetParent(alien_root);
            Column = AF.Create(AlienCategory.Type.AlienColumn, GameObject.Name.AlienColumn_0 + j++);
            GameObjectNodeManager.Attach(Column);

            AF.SetParent(Column);

            off_x += width + 10;
            AF.Create(AlienCategory.Type.Octopus1, GameObject.Name.Octopus2, start_x + off_x, start_y);
            AF.Create(AlienCategory.Type.Octopus1, GameObject.Name.Octopus1, start_x + off_x, start_y + height);
            AF.Create(AlienCategory.Type.Crab1, GameObject.Name.Crab2, start_x + off_x, start_y + 2 * height);
            AF.Create(AlienCategory.Type.Crab1, GameObject.Name.Crab1, start_x + off_x, start_y + 3 * height);
            AF.Create(AlienCategory.Type.Squid1, GameObject.Name.Squid1, start_x + off_x, start_y + 4 * height);

            AF.SetParent(alien_root);
            Column = AF.Create(AlienCategory.Type.AlienColumn, GameObject.Name.AlienColumn_0 + j++);
            GameObjectNodeManager.Attach(Column);

            AF.SetParent(Column);

            off_x += width + 10;
            AF.Create(AlienCategory.Type.Octopus1, GameObject.Name.Octopus2, start_x + off_x, start_y);
            AF.Create(AlienCategory.Type.Octopus1, GameObject.Name.Octopus1, start_x + off_x, start_y + height);
            AF.Create(AlienCategory.Type.Crab1, GameObject.Name.Crab2, start_x + off_x, start_y + 2 * height);
            AF.Create(AlienCategory.Type.Crab1, GameObject.Name.Crab1, start_x + off_x, start_y + 3 * height);
            AF.Create(AlienCategory.Type.Squid1, GameObject.Name.Squid1, start_x + off_x, start_y + 4 * height);

            AF.SetParent(alien_root);
            Column = AF.Create(AlienCategory.Type.AlienColumn, GameObject.Name.AlienColumn_0 + j++);
            GameObjectNodeManager.Attach(Column);

            AF.SetParent(Column);

            off_x += width + 10;
            AF.Create(AlienCategory.Type.Octopus1, GameObject.Name.Octopus2, start_x + off_x, start_y);
            AF.Create(AlienCategory.Type.Octopus1, GameObject.Name.Octopus1, start_x + off_x, start_y + height);
            AF.Create(AlienCategory.Type.Crab1, GameObject.Name.Crab2, start_x + off_x, start_y + 2 * height);
            AF.Create(AlienCategory.Type.Crab1, GameObject.Name.Crab1, start_x + off_x, start_y + 3 * height);
            AF.Create(AlienCategory.Type.Squid1, GameObject.Name.Squid1, start_x + off_x, start_y + 4 * height);

            AF.SetParent(alien_root);
            Column = AF.Create(AlienCategory.Type.AlienColumn, GameObject.Name.AlienColumn_0 + j++);
            GameObjectNodeManager.Attach(Column);

            AF.SetParent(Column);

            off_x += width + 10;
            AF.Create(AlienCategory.Type.Octopus1, GameObject.Name.Octopus2, start_x + off_x, start_y);
            AF.Create(AlienCategory.Type.Octopus1, GameObject.Name.Octopus1, start_x + off_x, start_y + height);
            AF.Create(AlienCategory.Type.Crab1, GameObject.Name.Crab2, start_x + off_x, start_y + 2 * height);
            AF.Create(AlienCategory.Type.Crab1, GameObject.Name.Crab1, start_x + off_x, start_y + 3 * height);
            AF.Create(AlienCategory.Type.Squid1, GameObject.Name.Squid1, start_x + off_x, start_y + 4 * height);

            AF.SetParent(alien_root);
            Column = AF.Create(AlienCategory.Type.AlienColumn, GameObject.Name.AlienColumn_0 + j++);
            GameObjectNodeManager.Attach(Column);

            AF.SetParent(Column);

            off_x += width + 10;
            AF.Create(AlienCategory.Type.Octopus1, GameObject.Name.Octopus2, start_x + off_x, start_y);
            AF.Create(AlienCategory.Type.Octopus1, GameObject.Name.Octopus1, start_x + off_x, start_y + height);
            AF.Create(AlienCategory.Type.Crab1, GameObject.Name.Crab2, start_x + off_x, start_y + 2 * height);
            AF.Create(AlienCategory.Type.Crab1, GameObject.Name.Crab1, start_x + off_x, start_y + 3 * height);
            AF.Create(AlienCategory.Type.Squid1, GameObject.Name.Squid1, start_x + off_x, start_y + 4 * height);

            AF.SetParent(alien_root);
            Column = AF.Create(AlienCategory.Type.AlienColumn, GameObject.Name.AlienColumn_0 + j++);
            GameObjectNodeManager.Attach(Column);

            AF.SetParent(Column);

            off_x += width + 10;
            AF.Create(AlienCategory.Type.Octopus1, GameObject.Name.Octopus2, start_x + off_x, start_y);
            AF.Create(AlienCategory.Type.Octopus1, GameObject.Name.Octopus1, start_x + off_x, start_y + height);
            AF.Create(AlienCategory.Type.Crab1, GameObject.Name.Crab2, start_x + off_x, start_y + 2 * height);
            AF.Create(AlienCategory.Type.Crab1, GameObject.Name.Crab1, start_x + off_x, start_y + 3 * height);
            AF.Create(AlienCategory.Type.Squid1, GameObject.Name.Squid1, start_x + off_x, start_y + 4 * height);

            AF.SetParent(alien_root);
            Column = AF.Create(AlienCategory.Type.AlienColumn, GameObject.Name.AlienColumn_0 + j++);
            GameObjectNodeManager.Attach(Column);

            AF.SetParent(Column);

            off_x += width + 10;
            AF.Create(AlienCategory.Type.Octopus1, GameObject.Name.Octopus2, start_x + off_x, start_y);
            AF.Create(AlienCategory.Type.Octopus1, GameObject.Name.Octopus1, start_x + off_x, start_y + height);
            AF.Create(AlienCategory.Type.Crab1, GameObject.Name.Crab2, start_x + off_x, start_y + 2 * height);
            AF.Create(AlienCategory.Type.Crab1, GameObject.Name.Crab1, start_x + off_x, start_y + 3 * height);
            AF.Create(AlienCategory.Type.Squid1, GameObject.Name.Squid1, start_x + off_x, start_y + 4 * height);

            AF.SetParent(alien_root);
            Column = AF.Create(AlienCategory.Type.AlienColumn, GameObject.Name.AlienColumn_0 + j++);
            GameObjectNodeManager.Attach(Column);

            AF.SetParent(Column);

            off_x += width + 10;
            AF.Create(AlienCategory.Type.Octopus1, GameObject.Name.Octopus2, start_x + off_x, start_y);
            AF.Create(AlienCategory.Type.Octopus1, GameObject.Name.Octopus1, start_x + off_x, start_y + height);
            AF.Create(AlienCategory.Type.Crab1, GameObject.Name.Crab2, start_x + off_x, start_y + 2 * height);
            AF.Create(AlienCategory.Type.Crab1, GameObject.Name.Crab1, start_x + off_x, start_y + 3 * height);
            AF.Create(AlienCategory.Type.Squid1, GameObject.Name.Squid1, start_x + off_x, start_y + 4 * height);

            return alien_root;
        }
    }
}
