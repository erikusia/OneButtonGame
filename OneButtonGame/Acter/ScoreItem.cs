using Microsoft.Xna.Framework;
using OneButtonGame.Def;
using OneButtonGame.Device;
using OneButtonGame.Scene;
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
            : base("block", position, 64, 64, gameDevice)
        {
            this.position = position;
            this.mediator = mediator;
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
                GamePlay.Score += 100;
                isDeadFlag = true;
            }
        }

        public override void Update(GameTime gameTime)
        {
            position.Y += 3;

            range = new Range(0, Screen.Width);
            if (range.IsOutOfRange((int)position.X))
            {
                isDeadFlag = true;
            }
            range = new Range(0, Screen.Height);
            if (range.IsOutOfRange((int)position.Y))
            {
                isDeadFlag = true;

            }
        }
    }
}
