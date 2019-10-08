using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using OneButtonGame.Device;

namespace OneButtonGame.Acter
{
    class Player : GameObject
    {
        public Player(string name, Vector2 position, int width, int height, GameDevice gameDevice) 
            : base(name, position, width, height, gameDevice)
        {
        }

        public override object Clone()
        {
            throw new NotImplementedException();
        }

        public override void Hit(GameObject gameObject)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
