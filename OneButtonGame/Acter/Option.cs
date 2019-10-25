using System;
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
        public float getAngle() { return angle; }

        private GameObjectManager gameObjectManager;
        private IGameObjectMediator mediator;
        private OptionMgr optionMgr;
        public static Vector2 optionPosition;
        public float rotate;
      static  float rad;
       float angle;
        float delta;
        float angle2;
        int hp;
        int shotTime;
      public static  List<Vector2> optionPositions = new List<Vector2>();

        public Option(Vector2 position, GameDevice gameDevice, IGameObjectMediator mediator,GameObjectManager gameObjectManager,  float angle)
            : base("player", position, 64, 64, gameDevice)
        {
            this.position = position;
            this.mediator = mediator;
            this.gameObjectManager = gameObjectManager;
            this.optionMgr = optionMgr;
            this.angle = angle;
            rotate = 2.0f;
            rad = 128.0f;
            hp = 3;
            shotTime = 10;
            //angle = 0;
            //angle2 = angle + 60;
            //angle3 = angle2 + 120;
            //angle4 = angle3 + 180;
            //angle5 = angle4 + rotate;
            //angle6 = angle5 + rotate;
         // position = CalcPosition(Player.playerPosition, angle, rad);
        }

        public Option(Option other)
            : this(other.position, other.gameDevice,other.mediator,other.gameObjectManager,other.angle)
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
          //  delta = 360f / optionPositions.Count; // オプション同士の間隔（角度）

            //for (int i = 0; i < optionPositions.Count; i++)
            //{
            //    angle2 = delta * i + angle;
            //    optionPositions[i] = CalcPosition(Player.playerPosition, angle2, rad);

            //    position = optionPositions[i];

            //}
            position = CalcPosition(Player.playerPosition, angle, rad);
            shotTime += 1;
            if (shotTime >= 10)
            {
                GamePlay.gameObject.Add(new PlayerBullet(new Vector2(position.X, position.Y - 64),
     gameDevice, mediator, gameObjectManager));
                shotTime = 0;
            }
        }
        public Vector2 CalcPosition(Vector2 center, float angle, float radius)
        {
            float radian = MathHelper.ToRadians(angle);
            return center + new Vector2((float)Math.Cos(radian) ,
                (float)Math.Sin( radian)) * radius;

        }
    }
}
