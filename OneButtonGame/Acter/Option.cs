﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using OneButtonGame.Device;
using OneButtonGame.Util;

namespace OneButtonGame.Acter
{
    class Option:GameObject
    {
        private GameObjectManager gameObjectManager;
        private IGameObjectMediator mediator;
        Vector2 speed;
        Range range;

        public Option(Vector2 position, GameDevice gameDevice, IGameObjectMediator mediator)
            : base("PowerUp", position, 64, 64, gameDevice)
        {
            this.position = position;
            this.mediator = mediator;
        }

        public Option(Option other)
            : this(other.position, other.gameDevice,other.mediator)
        {

        }
        public override object Clone()
        {
            return new Option(this);
        }

        public override void Hit(GameObject gameObject)
        {

        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
