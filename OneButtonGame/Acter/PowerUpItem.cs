using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using OneButtonGame.Device;
using OneButtonGame.Util;

namespace OneButtonGame.Acter
{
    class PowerUpItem:GameObject
    {
        private GameObjectManager gameObjectManager;
        private IGameObjectMediator mediator;
        Vector2 speed;
        Range range;

        public PowerUpItem(Vector2 position, GameDevice gameDevice, IGameObjectMediator mediator)
            : base("Bulletup", position, 64, 64, gameDevice)
        {
            this.position = position;
            this.mediator = mediator;
        }

        public PowerUpItem(PowerUpItem other)
            : this(other.position, other.gameDevice, other.mediator)
        {

        }
        public override object Clone()
        {
            return new PowerUpItem(this);
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
            position.Y += 5;
        }
    }
}
