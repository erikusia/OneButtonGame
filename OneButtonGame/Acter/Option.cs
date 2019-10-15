﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using OneButtonGame.Device;
using OneButtonGame.Scene;
using OneButtonGame.Util;

namespace OneButtonGame.Acter
{
    class Option:GameObject
    {
        private GameObjectManager gameObjectManager;
        private IGameObjectMediator mediator;

        float rotate;
        float rad;
        float angle;
        Vector2 center;
        int hp;

        public Option(Vector2 position, GameDevice gameDevice, IGameObjectMediator mediator,GameObjectManager gameObjectManager)
            : base("player", position, 64, 64, gameDevice)
        {
            this.position = position;
            this.mediator = mediator;
            this.gameObjectManager = gameObjectManager;
            rotate = 2.0f;
            rad = 150.0f;
            angle = 0;
            center = new Vector2(420, 600);
            hp = 3;
        }

        public Option(Option other)
            : this(other.position, other.gameDevice,other.mediator,other.gameObjectManager)
        {

        }
        public override object Clone()
        {
            return new Option(this);
        }

        public override void Hit(GameObject gameObject)
        {
            if(gameObject is Enemy)
            {
                hp -= 1;
            }
            if(hp<0)
            {
                isDeadFlag = true;
            }
        }

        public override void Update(GameTime gameTime)
        {
            angle += rotate;
           position= CalcPosition(center, angle, rad);
            GamePlay.gameObject.Add(new PlayerBullet(position, gameDevice, mediator, gameObjectManager));
        }
        public Vector2 CalcPosition(Vector2 center, float angle, float radius)
        {
            float radian = MathHelper.ToRadians(angle);
            return center + new Vector2((float)Math.Cos(radian) ,
                (float)Math.Sin( radian)) * radius;

        }
    }
}