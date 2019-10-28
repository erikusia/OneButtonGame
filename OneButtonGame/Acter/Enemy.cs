using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using OneButtonGame.Acter;
using OneButtonGame.Def;
using OneButtonGame.Device;
using OneButtonGame.Scene;
using OneButtonGame.Util;

namespace OneButtonGame.Acter
{
    class Enemy : GameObject
    {
        private GameObjectManager gameObjectManager;
        private IGameObjectMediator mediator;
        private Random rnd = new Random();
        int a;
        int shotTime;
        Range range;


        public Enemy(Vector2 position, GameDevice gameDevice, IGameObjectMediator mediator)
            :base("Enemy",position,64,64,gameDevice)
        {
            this.position = position;
            this.mediator = mediator;
        }
        public Enemy(Enemy other)
            :this(other.position,other.gameDevice,other.mediator)
        {

        }

        public override object Clone()
        {
            return new Enemy(this);
        }

        public override void Hit(GameObject gameObject)
        {
            if(gameObject is PlayerBullet)
            {
                playerBulletHit(gameObject);
                isDeadFlag = true;
            }
            
        }

        private void playerBulletHit(GameObject gameObject)
        {
            GamePlay.Score += 10;
            switch (rnd.Next(0, 6))
            {
                case 0:
                    GamePlay.gameObject.Add(null);
                    break;
                case 1:
                    GamePlay.gameObject.Add(new PowerUpItem(position, gameDevice, mediator));
                    break;
                case 2:
                    GamePlay.gameObject.Add(new OptionItem(position, gameDevice, mediator));
                    break;
                case 3:
                      GamePlay.gameObject.Add(null);
                    break;
                case 4:
                    GamePlay.gameObject.Add(null);
                    break;
                case 5:
                    GamePlay.gameObject.Add(null);
                    break;
            }
        }

        public override void Update(GameTime gameTime)
        {
            //移動
            switch (a)
            {
                case 0:position.Y += (float)2.5;
                    if (position.Y>=150)
                    {
                        a += 1;
                    }
                    break;
                case 1:position.Y -= 2;
                    break;
            }

            //弾
            shotTime += 1;
            if (shotTime >= 70)
            {
                GamePlay.gameObject.Add(new EnemyBullet(position, gameDevice, mediator));
                shotTime = 0;
            }

            //画面外に出たら死ぬ
            range = new Range(0, Screen.Width);
            if (range.IsOutOfRange((int)position.X))
            {
                isDeadFlag = true;
            }
            range = new Range(-100, Screen.Height);
            if (range.IsOutOfRange((int)position.Y))
            {
                isDeadFlag = true;
            }
        }
    }
}
