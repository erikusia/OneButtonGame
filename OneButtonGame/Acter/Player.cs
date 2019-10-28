
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
        private Option prevOption = null;
        private GameObjectManager gameObjectManager;
        float rotate;
        float rad;
        float angle;
        Sound sound;
        Vector2 center;
        int shotTime;
     public static int optionNumber;
        int powerUpCount;
        public static bool DeadFlag;

        public Player( Vector2 position,  GameDevice gameDevice, IGameObjectMediator mediator,GameObjectManager gameObjectManager) 
            : base("player", position,64,64, gameDevice)
        {
            this.position = position;
            this.mediator = mediator;
            this.gameObjectManager = gameObjectManager;
            hp = 1;
            rotate = 2.0f;
            rad = 180.0f;
            angle = 0;
            center = new Vector2(385, 600);
            shotTime = 10;
            DeadFlag = false;
            var game = GameDevice.Instance();
            sound = game.GetSound();
            optionNumber = 0;
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

            if(gameObject is EnemyBullet)
            {
                hp -= 1;
            }

            if (gameObject is OptionItem)
            {
                optionNumber = optionNumber + 1;

                if (optionNumber < 6)
                {
                    sound.PlaySE("aura");
                    float deg = 0f;
                    if (prevOption != null)
                    {
                        deg = prevOption.getAngle() + 60f;
                    }
                    var op = new Option(Vector2.Zero, gameDevice, mediator, gameObjectManager,  deg,hp);
                    prevOption = op;
                    GamePlay.gameObject.Add(op);

                }
            }

            if(gameObject is PowerUpItem)
            {
                powerUpCount += 1;
                sound.PlaySE("bulletup");
            }

            if(gameObject is ScoreItem)
            {
                sound.PlaySE("scoreup");
                GamePlay.Score += 100;
            }
        }

        private void clonePowerUp(GameObject gameObject)
        {

        }

        public override void Update(GameTime gameTime)
        {
            playerPosition = this.position;
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                angle += rotate;
                position = CalcPosition(center, angle, rad);

            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                if (optionNumber < 6)
                {
                    optionNumber += 1;
                    float deg = 0f;
                    if (prevOption != null)
                    {
                        deg = prevOption.getAngle() + 60f;
                    }
                    var op = new Option(Vector2.Zero, gameDevice, mediator, gameObjectManager, deg, hp);
                    prevOption = op;
                    GamePlay.gameObject.Add(op);
                }
            }

            shotTime += 1;
            if (shotTime >= 10)
            {
                GamePlay.gameObject.Add(new PlayerBullet(new Vector2(playerPosition.X + 24, playerPosition.Y - 30),
                gameDevice, mediator, gameObjectManager));
                shotTime = 0;
                sound.PlaySE("shot");
                if (powerUpCount>=1)
                {
                    GamePlay.gameObject.Add(new PlayerBullet2(new Vector2(position.X + 50, position.Y + 32), gameDevice, mediator, gameObjectManager));
                }
                if (powerUpCount >= 2)
                {
                    GamePlay.gameObject.Add(new PlayerBullet3(new Vector2(position.X-1, position.Y + 32), gameDevice, mediator, gameObjectManager));
                }
            }

            if (hp <= 0)
            {
                sound.PlaySE("playerdie");
                DeadFlag = true;
                isDeadFlag = true;
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
