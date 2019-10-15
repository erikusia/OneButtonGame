﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using OneButtonGame.Device;
using Microsoft.Xna.Framework.Input;

namespace OneButtonGame.Acter
{
    
    class Player : GameObject
    {
       public static int hp;
        private IGameObjectMediator mediator;
        private GameObjectManager gameObjectManager;
        float rotate;
        float rad;
        float angle;
        Vector2 center;
        PlayerBullet bullet;

        public Player( Vector2 position,  GameDevice gameDevice, IGameObjectMediator mediator,GameObjectManager gameObjectManager) 
            : base("block", position,32,32, gameDevice)
        {
            this.position = position;
            this.mediator = mediator;
            this.gameObjectManager = gameObjectManager;
            hp = 1;
            rotate = 2.0f;
            rad = 150.0f;
            angle = 0;
            center = new Vector2(420, 600);
        }

        public Player(Player other)
            :this(other.position,other.gameDevice,other.mediator, other.gameObjectManager)
        {

        }
        public override object Clone()
        {
            return new Player(this);
        }

        public override void Hit(GameObject gameObject)
        {
            if (gameObject is Enemy)
            {
                hp -= 1;
            }

            if (hp<0)
            {
                isDeadFlag = true;
            }
        }

        public override void Update(GameTime gameTime)
        {

            //position = new Vector2((float)Math.Sin(angle)*12+position.X,
            //    (float)Math.Sin(angle * 2) * 2+position.X);
            angle += rotate;
            
            position = CalcPosition(center,angle, rad);
            mediator.AddActor(new PlayerBullet(position,
                gameDevice, mediator));
           
        }
        public Vector2 CalcPosition( Vector2 position,float angle,float radius)
        { 
            float radian = MathHelper.ToRadians(angle);
            return position+ new Vector2((float)Math.Sin(radian)*2,
                (float)Math.Sin(2*radian)) * radius;

        }

    }
}
