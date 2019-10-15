using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using OneButtonGame.Device;


namespace OneButtonGame.Acter
{
    enum Direction
    {
        Top, Bottom, Left, Right
    };
    abstract class GameObject : ICloneable
    {
        protected string name;
        protected Vector2 position;
        protected int width;
        protected int height;
        protected bool isDeadFlag;
        protected GameDevice gameDevice;
       


        public GameObject(string name, Vector2 position, int width, int
            height, GameDevice gameDevice)
        {
            this.name = name;
            this.position = position;
            this.width = width;
            this.height = height;
            this.gameDevice = gameDevice;
        }

        protected GameObject(string name, Vector2 position, GameDevice gameDevice)
        {
            this.name = name;
            this.position = position;
            this.gameDevice = gameDevice;
        }

        public void SetPosition(Vector2 position)
        {
            this.position = position;
        }

        public Vector2 GetPosition()
        {
            return position;
        }

        public int GetWidth()
        {
            return width;
        }

        public int GetHeight()
        {
            return height;
        }

        public abstract object Clone();
        public abstract void Update(GameTime gameTime);
        public abstract void Hit(GameObject gameObject);

        public virtual void Draw(Renderer renderer)
        {
            renderer.DrawTexture(name, position + gameDevice.GetDisplayModify());
        }

        public bool IsDead()
        {
            return isDeadFlag;
        }

        public Rectangle getRectangle()
        {
            Rectangle area = new Rectangle();

            area.X = (int)position.X;
            area.Y = (int)position.Y;
            area.Height = height;
            area.Width = width;

            return area;
        }

        public bool IsCollision(GameObject otherObj)
        {
            return this.getRectangle().Intersects(otherObj.getRectangle());
        }

        public Direction CheckDirecton(GameObject otherObj)
        {
            Point thisCenter = this.getRectangle().Center;
            Point otherCenter =
                otherObj.getRectangle().Center;

            Vector2 dir =
                new Vector2(thisCenter.X, thisCenter.Y) -
                new Vector2(otherCenter.X, otherCenter.Y);

            if (Math.Abs(dir.X) > Math.Abs(dir.Y))
            {
                if (dir.X > 0)
                {
                    return Direction.Right;//後で修正
                }
                return Direction.Left;//後で修正
            }

            if (dir.Y > 0)
            {
                return Direction.Bottom;//後で修正
            }

            return Direction.Top;
        }

        public virtual void CorrectPosition(GameObject other)
        {
            //当たった面の取得
            Direction dir = this.CheckDirecton(other);

            if (dir == Direction.Top)
            {
                position.Y = other.getRectangle().Top - this.height;
            }
            else if (dir == Direction.Right)
            {
                position.X = other.getRectangle().Right;
            }
            else if (dir == Direction.Left)
            {
                position.X = other.getRectangle().Left - this.width;
            }
            else if (dir == Direction.Bottom)
            {
                position.Y = other.getRectangle().Bottom;
            }

        }



    }
}
