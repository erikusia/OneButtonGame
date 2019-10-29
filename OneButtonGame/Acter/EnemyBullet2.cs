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
    class EnemyBullet2:GameObject
    {
        private GameObjectManager gameObjectManager;
        private IGameObjectMediator mediator;
        Vector2 speed;
        Range range;
        int shotTime;
        Vector2 a;
        public static int b;

        public EnemyBullet2(Vector2 position, GameDevice gameDevice, IGameObjectMediator mediator)
            : base("Bullet2", position, 16, 16, gameDevice)
        {
            this.position = position;
            this.mediator = mediator;
            speed = new Vector2(0, -30);
            shotTime = 60;
            a = position;
        }
        public EnemyBullet2(EnemyBullet2 other)
            : this(other.position, other.gameDevice, other.mediator)
        {

        }
        public override object Clone()
        {
            return new EnemyBullet2(this);
        }

        public override void Hit(GameObject gameObject)
        {
            if(gameObject is Player)
            {
                isDeadFlag = true;
            }
            if(gameObject is PlayerBullet)
            {
                isDeadFlag = true;
            }
            if (gameObject is Option)
            {
                isDeadFlag = true;
            }
        }

        public override void Update(GameTime gameTime)
        {

            position +=new Vector2(1,5);

            //画面外に出たら
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
