using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using OneButtonGame.Def;
using OneButtonGame.Device;
using OneButtonGame.Util;

namespace OneButtonGame.Acter
{
    class PlayerBullet : GameObject
    {
        private GameObjectManager gameObjectManager;
        private IGameObjectMediator mediator;
        Vector2 speed;
        Range range;

        public PlayerBullet(Vector2 position,GameDevice gameDevice,IGameObjectMediator mediator)
            :base("Bullet",position,32,32,gameDevice)
        {
            this.position = position;
            this.mediator = mediator;
            speed = new Vector2(1, 1);

        }
        public  PlayerBullet(PlayerBullet other)
            :this(other.position,other.gameDevice,other.mediator)
        {

        }
        public override object Clone()
        {
            return new PlayerBullet(this);
        }

        public override void Hit(GameObject gameObject)
        {
            if(gameObject is Enemy)
            {
                isDeadFlag = true;
            }
        }

        public override void Update(GameTime gameTime)
        {
            position *= speed;

            range = new Range(0, Screen.Width);
            if (range.IsOutOfRange((int)position.X))
            {
                if (position.X <= 0)
                {
                    if (position.X <= 0)
                    {
                        position = new Vector2(Screen.Width, position.Y);
                    }
                    else if (position.X >= Screen.Width)
                    {
                        position = new Vector2(0, position.Y);
                    }
                }
                range = new Range(0, Screen.Height);
                if (range.IsOutOfRange((int)position.Y))
                {
                    if (position.Y <= 0)
                    {
                        position = new Vector2(position.X, Screen.Height);
                    }
                    else if (position.Y >= Screen.Height)
                    {
                        position = new Vector2(position.X, 0);
                    }
                }
            }

        }
    }
}
