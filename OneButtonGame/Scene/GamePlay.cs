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
        PlayerBullet playerBullet;
        OptionItem optionItem;
        private Random rnd=new Random();
        int spawnTime=60;
        Option option;
        int optionNumber;
        GameTime tp;
        public static int Score;

        public GamePlay()         
        {
            gameObject = new GameObjectManager();
            isEnd = false;
            tp = new GameTime();
            Score = 0;
        }
        public void Draw(Renderer renderer)
        {
            renderer.Begin();
            gameObject.Draw(renderer);

            renderer.DrawNumber("number", new Vector2(150,0), Score);
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
            return Scene.Result;
        }

        public void Shutdown()
        {
           
        }

        public void Update(GameTime gameTime)
        {
            Score += gameTime.TotalGameTime.Seconds;
            spawnTime += 1;

            if ( gameTime.TotalGameTime.Seconds<= 20)
            {
                Console.WriteLine("20です");
                if (spawnTime >= 120)
                {
                    int x = rnd.Next(1, 740);
                    int y = rnd.Next(-50, 0);
                    enemy = new Enemy(new Vector2(x, y),
                        GameDevice.Instance(), gameObject);
                    gameObject.Add(enemy);
                    spawnTime = 0;
                }
            }
            else if (gameTime.TotalGameTime.Seconds <= 40)
            {
                Console.WriteLine("40です");
                if (spawnTime >= 90)
                {
                    int x = rnd.Next(1, 740);
                    int y = rnd.Next(-50, 0);
                    enemy = new Enemy(new Vector2(x, y),
                        GameDevice.Instance(), gameObject);
                    gameObject.Add(enemy);
                    spawnTime = 0;
                }
            }

            else if (gameTime.TotalGameTime.Seconds <= 60)
            {
                Console.WriteLine("60です");
                if (spawnTime >= 60)
                {
                    int x = rnd.Next(1, 740);
                    int y = rnd.Next(-50, 0);
                    enemy = new Enemy(new Vector2(x, y),
                        GameDevice.Instance(), gameObject);
                    gameObject.Add(enemy);
                    spawnTime = 0;
                }
            }

            gameObject.Update(gameTime);
        }

    }
}
