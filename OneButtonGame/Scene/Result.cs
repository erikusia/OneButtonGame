using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using OneButtonGame.Device;

namespace OneButtonGame.Scene
{
    class Result : IScene
    {
        private bool isEnd;
        public void Draw(Renderer renderer)
        {
            
        }

        public void Initialize()
        {
            
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
            
        }
    }
}
