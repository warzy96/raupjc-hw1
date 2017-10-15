using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    class CollisionDetector
    {
        public static bool Overlaps(IPhysicalObject2D a, IPhysicalObject2D b)
        {
            Ball ball = (Ball)a;
            if (b.ToString().Contains("Wall"))
            {
                Wall wall = (Wall)b;
                if (wall.X != 0)
                {
                    if (wall.X < 0)
                    {
                        if ((ball.X - 5f) <= 0) return true;
                    }
                    else
                    {
                        if ((wall.X - ball.X) <= 20f) return true;
                    }
                }

                else
                {
                    if (wall.Y < 0)
                    {
                        if (ball.Y - float.Epsilon + 20f <= 0) return true;
                    }
                    else
                    {
                        if (900f - ball.Y <= float.Epsilon) return true;
                    }
                }
            }
            else
            {
                Paddle paddle = (Paddle)b;
                if (((paddle.X + paddle.Width) >= ball.X && (paddle.X) <= ball.X) && paddle.Name.Equals("PaddleTop") && ball.Y - 20f <= 0) return true; 
                if ((paddle.X + paddle.Width >= ball.X && paddle.X <= ball.X) && paddle.Name.Equals("PaddleBottom") && 840f-ball.Y <= 0) return true; 
            }
            return false;
        }
    }
}
