using Microsoft.Xna.Framework;
using OneButtonGame.Def;
using OneButtonGame.Device;
using OneButtonGame.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneButtonGame.Acter
{
    class PlayerBullet2:GameObject
    {
        private GameObjectManager gameObjectManager;
        private IGameObjectMediator mediator;
        Vector2 speed;
        Range range;
        int shotTime;
        public PlayerBullet2(Vector2 position, GameDevice gameDevice, IGameObjectMediator mediator, GameObjectManager gameObjectManager)
            : base("Bullet1", position, 16, 16, gameDevice)
        {
            this.position = position;
            this.mediator = mediator;
            this.gameObjectManager = gameObjectManager;
            speed = new Vector2(5, -30);
            shotTime = 60;
        }
        public PlayerBullet2(PlayerBullet2 other)
            : this(other.position, other.gameDevice, other.mediator, other.gameObjectManager)
        {

        }
        public override object Clone()
        {
            return new PlayerBullet2(this);
        }

        public override void Hit(GameObject gameObject)
        {
            if (gameObject is Enemy)
            {
                isDeadFlag = true;
            }
            if (gameObject is Enemy2)
            {
                isDeadFlag = true;
            }
            if(gameObject is EnemyBullet)
            {
                isDeadFlag = true;
            }
            if (gameObject is EnemyBullet2)
            {
                isDeadFlag = true;
            }
            if (gameObject is EnemyBullet3)
            {
                isDeadFlag = true;
            }
        }

        public override void Update(GameTime gameTime)
        {
            position += speed;

            range = new Range(0, Screen.Width);
            if (range.IsOutOfRange((int)position.X))
            {
                isDeadFlag = true;
            }
            range = new Range(0, Screen.Height);
            if (range.IsOutOfRange((int)position.Y))
            {
                isDeadFlag = true;

            }
        }
    }
}
