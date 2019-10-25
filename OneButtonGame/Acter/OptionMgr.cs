using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using OneButtonGame.Scene;

namespace OneButtonGame.Acter
{
    class OptionMgr
    {
        private List<Option> optionNumber;
        public static float angle;
        float rota;
        public OptionMgr()
        {

        }

        public void Inisialize()
        {

        }
        public void Update(GameTime gameTime)
        {
            angle +=rota;


        }
        public Vector2 CalcPosition(Vector2 center, float angle, float radius)
        {
            float radian = MathHelper.ToRadians(angle);
            return center + new Vector2((float)Math.Cos(radian),
                (float)Math.Sin(radian)) * radius;

        }
    }
}
