using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using OneButtonGame.Device;

namespace OneButtonGame.Acter
{
    class Player : GameObject
    {
       public static int hp;
        private IGameObjectMediator mediator;
        private GameObjectManager gameObjectManager;
        float angle=0,
         baseX, baseY;
        int flame = 0;
        

        public Player( Vector2 position,  GameDevice gameDevice, IGameObjectMediator mediator,GameObjectManager gameObjectManager) 
            : base("block", position,32,32, gameDevice)
        {
            this.position = position;
            this.mediator = mediator;
            this.gameObjectManager = gameObjectManager;
            hp = 1;
       
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
           //if(gameObject is Enemy)
           // {
           //     hp -= 1;
           // }

           if(hp<0)
            {
                isDeadFlag = true;
            }
        }

        public override void Update(GameTime gameTime)
        {
            //angle *= (float)Math.PI / 180;
          


            position.X += 100+ 100 + (float)Math.Sin(angle);
            position.Y +=100+  200 + (float)Math.Sin(2*angle);

        }


    }
}
