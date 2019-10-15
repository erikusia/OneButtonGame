using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using OneButtonGame.Device;
using OneButtonGame.Acter;
using Microsoft.Xna.Framework.Input;

namespace OneButtonGame.Scene
{
    class GamePlay : IScene
    {

        GameObjectManager gameObject;
        public bool isEnd;
        Player player;
        Option option;
        public GamePlay()
            
        {
            gameObject = new GameObjectManager();
            isEnd = false;
        }
        public void Draw(Renderer renderer)
        {
            renderer.Begin();
            gameObject.Draw(renderer);
            renderer.End();
        }

        public void Initialize()
        {
            gameObject.Initialize();
            player = new Player(new Vector2(420 , 600),
    GameDevice.Instance(), gameObject, gameObject);
            gameObject.Add(player);
            //option = new Option(player.GetPosition(),
            //    GameDevice.Instance(), gameObject,gameObject);
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
            
            gameObject.Update(gameTime);
        }
    }
}
