using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using OneButtonGame.Device;
using OneButtonGame.Util;
using OneButtonGame.Scene;

namespace OneButtonGame.Acter
{
    class OptionItem : GameObject
    {
        private GameObjectManager gameObjectManager;
        private IGameObjectMediator mediator;
        Vector2 speed;
        Range range;
        int optionNumber;
        public OptionItem(Vector2 position, GameDevice gameDevice, IGameObjectMediator mediator)
            : base("block", position, 64, 64, gameDevice)
        {
            this.position = position;
            this.mediator = mediator;
            speed = new Vector2(0, 1);
            optionNumber = 0;
        }

        public OptionItem(OptionItem other)
            : this(other.position, other.gameDevice, other.mediator)
        {

        }
        public override object Clone()
        {
            return new OptionItem(this);
        }

        public override void Hit(GameObject gameObject)
        {
            if (gameObject is Player)
            {
                optionNumber = optionNumber+ 1;
               
                if (optionNumber <= 5)

                {
                    Console.WriteLine(optionNumber);
                    GamePlay.gameObject.Add(new Option(Player.playerPosition, gameDevice, mediator, gameObjectManager));
                    isDeadFlag = true;
                }
                else
                {
                    isDeadFlag = true;
                }
                
            }

        }

        public override void Update(GameTime gameTime)
        {
            
            position += speed;
        }
    }
}
