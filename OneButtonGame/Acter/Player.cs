
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
        private OptionMgr optionMgr;
        float rotate;
        float rad;
        float angle;
        Vector2 center;
        int shotTime;
        int optionNumber;
        private float angle2,angle3;

        private Option prevOption = null;

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

            if (hp < 0)
            {
                isDeadFlag = true;
            }
            if (gameObject is OptionItem)
            {
                optionNumber = optionNumber + 1;

                if (optionNumber <= 6)
                {
                    float deg = 0f;
                    if (prevOption != null)
                    {
                        deg = prevOption.getAngle() + 60f;
                    }
                    var op = new Option(Vector2.Zero, gameDevice, mediator, gameObjectManager, optionMgr, deg);
                    prevOption = op;
                    GamePlay.gameObject.Add(op);
                    //switch (optionNumber)
                    //{

                    //    case 1:
                    //        Option.optionPositions.Add(position);
                    //        GamePlay.gameObject.Add(new Option(CalcPosition(position, angle2, rad), gameDevice, mediator, gameObjectManager,optionMgr));
                    //        break;
                    //    case 2:

                    //        Option.optionPositions.Add(position);
                    //        GamePlay.gameObject.Add(new Option(CalcPosition(position,angle3,rad), gameDevice, mediator, gameObjectManager,optionMgr));
                    //        break;
                    //    case 3:
                    //        Option.optionPositions.Add(position);
                    //        GamePlay.gameObject.Add(new Option(CalcPosition(position, (angle2+120), rad), gameDevice, mediator, gameObjectManager,optionMgr));
                    //         break;
                    //    case 4:
                    //        Option.optionPositions.Add(position);
                    //        GamePlay.gameObject.Add(new Option(CalcPosition(position, angle, rad), gameDevice, mediator, gameObjectManager,optionMgr));
                    //        break;
                    //    case 5:
                    //        Option.optionPositions.Add(position);
                    //        GamePlay.gameObject.Add(new Option(CalcPosition(position, angle , rad), gameDevice, mediator, gameObjectManager,optionMgr));
                    //        break;
                    //    case 6:
                    //        Option.optionPositions.Add(position);
                    //        GamePlay.gameObject.Add(new Option(CalcPosition(position, angle , rad), gameDevice, mediator, gameObjectManager,optionMgr));
                    //        break;
                    //}

                }
                }
            }
        

        public override void Update(GameTime gameTime)
        {
            if(optionNumber==1)
            {
                angle2 += 2;
                Console.WriteLine(angle2);
                angle3 = angle2 + 60;
            }

           // Console.WriteLine(angle);
            //delta = 360f / Option.optionPositions.Count; // オプション同士の間隔（角度）

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
