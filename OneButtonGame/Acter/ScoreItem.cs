using Microsoft.Xna.Framework;
using OneButtonGame.Device;
using OneButtonGame.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneButtonGame.Acter
{
    class ScoreItem:GameObject
    {
        private GameObjectManager gameObjectManager;
        private IGameObjectMediator mediator;
        Vector2 speed;
        Range range;
        private Option powerUpItem;

        int score;
        public ScoreItem(Vector2 position, GameDevice gameDevice, IGameObjectMediator mediator)
            : base("ScoreItem", position, 64, 64, gameDevice)
        {
            this.position = position;
            this.mediator = mediator;
            score = 0;
        }

        public ScoreItem(ScoreItem other)
            : this(other.position, other.gameDevice, other.mediator)
        {

        }
        public override object Clone()
        {
            return new ScoreItem(this);
        }

        public override void Hit(GameObject gameObject)
        {
            if(gameObject is Player)
            {
                score += 2000;
                isDeadFlag = true;
                
            }
        }

        public override void Update(GameTime gameTime)
        {
            
        }
    }
}
