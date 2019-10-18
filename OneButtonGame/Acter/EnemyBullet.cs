﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using OneButtonGame.Device;
using OneButtonGame.Util;

namespace OneButtonGame.Acter
{
    class EnemyBullet : GameObject
    {
        private GameObjectManager gameObjectManager;
        private IGameObjectMediator mediator;
        Vector2 speed;
        Range range;
        private EnemyBullet enemyBullet;
        Vector2 playerPosition;
        Vector2 a;

        public EnemyBullet(Vector2 position, GameDevice gameDevice, IGameObjectMediator mediator)
            :base("Bullet2",position,64,64,gameDevice)
        {
            this.position = position;
            this.mediator = mediator;
            playerPosition = new Vector2(Player.playerPosition.X,Player.playerPosition.Y);
            Console.WriteLine(playerPosition);
            a = playerPosition - position;
            a.Normalize();

        }
        public EnemyBullet(EnemyBullet other)
            :this(other.position, other.gameDevice, other.mediator)
        {

        }
        public override object Clone()
        {
            return new EnemyBullet(this);
        }

        public override void Hit(GameObject gameObject)
        {
            if(gameObject is Player)
            {
                isDeadFlag = true;
            }
        }

        public override void Update(GameTime gameTime)
        {
            position += a*5;
        }
    }
}
