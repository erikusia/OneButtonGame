using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using OneButtonGame.Acter;
using OneButtonGame.Device;
using OneButtonGame.Scene;

namespace OneButtonGame.Acter
{
    class Enemy : GameObject
    {
        private GameObjectManager gameObjectManager;
        private IGameObjectMediator mediator;
        private Random rnd = new Random();
        int a;
        int shotTime;

        public Enemy(Vector2 position, GameDevice gameDevice, IGameObjectMediator mediator)
            :base("Enemy",position,32,32,gameDevice)
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
            }
        }

        private void playerBulletHit(GameObject gameObject)
        {
            //switch(rnd.Next(0,6))
            //{
            //    case 0: 
            //        break;
            //    case 1:gameObjectManager.Add(new ScoreItem(position, gameDevice, mediator));
            //        break;
            //    case 2:gameObjectManager.Add(new OptionItem(position, gameDevice, mediator));
            //        break;
            //    case 3:gameObjectManager.Add(new PowerUpItem(position, gameDevice, mediator));
            //        break;
            //    case 4:
            //        break;
            //    case 5:
            //        break;
            //}
        }

        public override void Update(GameTime gameTime)
        {

            switch (a)
            {
                case 0:position.Y += 2;
                    if (position.Y>=100)
                    {
                        a += 1;
                    }
                    break;
                case 1:position.Y -= 2;
                    break;
            }
            shotTime += 1;
            if (shotTime >= 60)
            {
                
                GamePlay.gameObject.Add(new EnemyBullet(position, gameDevice, mediator));
                shotTime = 0;
            }
        }
    }
}
