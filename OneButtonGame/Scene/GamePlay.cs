using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using OneButtonGame.Device;
using OneButtonGame.Acter;
using Microsoft.Xna.Framework.Input;
using OneButtonGame.Def;

namespace OneButtonGame.Scene
{
    class GamePlay : IScene
    {
        public static GameObjectManager gameObject;
        public bool isEnd;
        Player player;
        Enemy enemy;
        Enemy2 enemy2;
        PlayerBullet playerBullet;
        OptionItem optionItem;
        private Random rnd=new Random();
        int spawnTime=60;
        Option option;
        int optionNumber;
        GameTime tp;
        public static int Score;
        int highScore;
        int scoreTime;
        float seconds;
        bool spaceCheck;

        public GamePlay()         
        {
            gameObject = new GameObjectManager();
            isEnd = false;
            tp = new GameTime();
            Score = 0;
            spaceCheck = false;
        }
        public void Draw(Renderer renderer)
        {
            renderer.Begin();
            gameObject.Draw(renderer);
            if(Player.DeadFlag == false)
            {
                renderer.DrawNumber("number", new Vector2(150, 0), Score);
                
            }
            else if (Player.DeadFlag == true)
            {
                renderer.DrawTexture("ScoreBack", new Vector2(Screen.Width / 2-420, Screen.Height / 2-452));
                renderer.DrawNumber("number", new Vector2(Screen.Width / 2-16, Screen.Height / 2-16), Score);
                if (highScore < Score)
                {
                    highScore = Score;
                }
                renderer.DrawNumber("number", new Vector2(Screen.Width / 2 - 16, Screen.Height / 2 + 64), highScore);

                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    Score = 0;
                    seconds = 0;
                    isEnd = true;
                }

            }
            renderer.End();
        }

        public void Initialize()
        {
            gameObject.Initialize();
            gameObject.Add(playerBullet);
            player = new Player(new Vector2(420 , 600),
            GameDevice.Instance(), gameObject, gameObject);
            optionNumber = 0;
            gameObject.Add(player);       
            gameObject.Add(option);
         
            isEnd = false;
        }

        public bool IsEnd()
        {
            return isEnd;
        }

        public Scene Next()
        {
            return Scene.GamePlay;
        }

        public void Shutdown()
        {
           
        }

        public void Update(GameTime gameTime)
        {
            seconds += (float)gameTime.ElapsedGameTime.TotalSeconds;
            //Console.WriteLine(seconds);
            spawnTime += 1;
            scoreTime += 1;
            

            if (Keyboard.GetState().IsKeyDown(Keys.D1))
            {
                int x = rnd.Next(1, 740);
                int y = rnd.Next(-50, 0);
                enemy2 = new Enemy2(new Vector2(x, y),
                    GameDevice.Instance(), gameObject);
                gameObject.Add(enemy2);
            }
            if (scoreTime >= 20)
            {
                if(Player.DeadFlag == false)
                {
                    Score += 1;
                }
                scoreTime = 0;
            }

            if (seconds <= 10)
            {
                //Console.WriteLine("10です");
                if (spawnTime >= 120)
                {
                    int x = rnd.Next(1, 740);
                    int y = rnd.Next(-50, 0);
                    enemy = new Enemy(new Vector2(x, y),
                        GameDevice.Instance(), gameObject);
                    gameObject.Add(enemy);

                    switch (rnd.Next(0, 6))
                    {
                        case 0:
                            gameObject.Add(null);
                            break;
                        case 1:
                            gameObject.Add(new Enemy2(new Vector2(rnd.Next(1, 740), rnd.Next(-50, 0)), GameDevice.Instance(),gameObject));
                            break;
                        case 2:
                            gameObject.Add(null);
                            break;
                        case 3:
                            gameObject.Add(null);
                            break;
                        case 4:
                            gameObject.Add(null);
                            break;
                        case 5:
                            gameObject.Add(null);
                            break;
                    }
                    spawnTime = 0;
                }
            }
            else if (seconds <= 20)
            {
                //Console.WriteLine("20です");
                if (spawnTime >= 90)
                {
                    int x = rnd.Next(1, 740);
                    int y = rnd.Next(-50, 0);
                    enemy = new Enemy(new Vector2(x, y),
                        GameDevice.Instance(), gameObject);
                    gameObject.Add(enemy);

                    switch (rnd.Next(0, 5))
                    {
                        case 0:
                            gameObject.Add(null);
                            break;
                        case 1:
                            gameObject.Add(new Enemy2(new Vector2(rnd.Next(1, 740), rnd.Next(-50, 0)), GameDevice.Instance(), gameObject));
                            break;
                        case 2:
                            gameObject.Add(null);
                            break;
                        case 3:
                            gameObject.Add(null);
                            break;
                        case 4:
                            gameObject.Add(null);
                            break;
                    }
                    spawnTime = 0;
                }
            }

            else if (seconds <= 40)
            {
                //Console.WriteLine("40です");
                if (spawnTime >= 60)
                {
                    int x = rnd.Next(1, 740);
                    int y = rnd.Next(-50, 0);
                    enemy = new Enemy(new Vector2(x, y),
                        GameDevice.Instance(), gameObject);
                    gameObject.Add(enemy);
                    switch (rnd.Next(0, 4))
                    {
                        case 0:
                            gameObject.Add(null);
                            break;
                        case 1:
                            gameObject.Add(new Enemy2(new Vector2(rnd.Next(1, 740), rnd.Next(-50, 0)), GameDevice.Instance(), gameObject));
                            break;
                        case 2:
                            gameObject.Add(null);
                            break;
                        case 3:
                            gameObject.Add(null);
                            break;
                    }
                    spawnTime = 0;
                }
            }

            else if (seconds <= 60)
            {
                //Console.WriteLine("40です");
                if (spawnTime >= 30)
                {
                    int x = rnd.Next(1, 740);
                    int y = rnd.Next(-50, 0);
                    enemy = new Enemy(new Vector2(x, y),
                        GameDevice.Instance(), gameObject);
                    gameObject.Add(enemy);
                    switch (rnd.Next(0, 4))
                    {
                        case 0:
                            gameObject.Add(null);
                            break;
                        case 1:
                            gameObject.Add(new Enemy2(new Vector2(rnd.Next(1, 740), rnd.Next(-50, 0)), GameDevice.Instance(), gameObject));
                            break;
                        case 2:
                            gameObject.Add(null);
                            break;
                        case 3:
                            gameObject.Add(null);
                            break;
                    }
                    spawnTime = 0;
                }
            }
            gameObject.Update(gameTime);
        }

    }
}
