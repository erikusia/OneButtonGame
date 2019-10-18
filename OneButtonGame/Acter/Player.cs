
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using OneButtonGame.Device;
using Microsoft.Xna.Framework.Input;
using OneButtonGame.Scene;

namespace OneButtonGame.Acter
{
    
    class Player : GameObject
    {
        public static int hp;
        public static Vector2 playerPosition;
        private IGameObjectMediator mediator;
        private GameObjectManager gameObjectManager;
        float rotate;
        float rad;
        float angle;
        Vector2 center;
        int shotTime;

        public Player( Vector2 position,  GameDevice gameDevice, IGameObjectMediator mediator,GameObjectManager gameObjectManager) 
            : base("player", position,64,64, gameDevice)
        {
            this.position = position;
            this.mediator = mediator;
            this.gameObjectManager = gameObjectManager;
            hp = 1;
            rotate = 2.0f;
            rad = 150.0f;
            angle = 0;
            center = new Vector2(420, 600);
            shotTime = 10;
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
            playerPosition = this.position;
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                angle += rotate;
                position = CalcPosition(center, angle, rad);

            }
            shotTime += 1;
            if (shotTime >= 10)
            {
                GamePlay.gameObject.Add(new PlayerBullet(new Vector2(playerPosition.X, playerPosition.Y - 64),
     gameDevice, mediator, gameObjectManager));
                shotTime = 0;
            }

        }
        public Vector2 CalcPosition( Vector2 position,float angle,float radius)
        { 
            float radian = MathHelper.ToRadians(angle);
            return position+ new Vector2((float)Math.Sin(radian)*2,
                (float)Math.Sin(2*radian)) * radius;

        }

    }
}
