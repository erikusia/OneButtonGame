﻿using System;
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
        public OptionItem(Vector2 position, GameDevice gameDevice, IGameObjectMediator mediator)
            : base("optionitem", position, 64, 64, gameDevice)
        {
            this.position = position;
            this.mediator = mediator;
            speed = new Vector2(0, 3);
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
            if(gameObject  is Player)
            {
                isDeadFlag = true;
            }

        }

        public override void Update(GameTime gameTime)
        {
            position += speed;
        }
    }
}
