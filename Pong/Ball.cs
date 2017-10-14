using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    
    /// <summary >
    /// Game ball object representation
    /// </ summary >
    public class Ball : Sprite
    {
        /// <summary >
        /// Defines current ball speed in time .
        /// </ summary >
        public float Speed { get; set; }
        public float BumpSpeedIncreaseFactor { get; set; }
        /// <summary >
        /// Defines ball direction .
        /// Valid values ( -1 , -1) , (1 ,1) , (1 , -1) , ( -1 ,1).
        /// Using Vector2 to simplify game calculation . Potentially
        /// dangerous because vector 2 can swallow other values as well .
        /// OPTIONAL TODO : create your own , more suitable type
        /// </ summary >
        public MyVector Direction { get; set; }
        public Ball(int size, float speed, float
        defaultBallBumpSpeedIncreaseFactor) : base(size, size)
        {
            Speed = speed;
            BumpSpeedIncreaseFactor = defaultBallBumpSpeedIncreaseFactor;
            // Initial direction
            Direction = new MyVector(MyVector.Direction.SouthEast);
        }

        public class MyVector
        {
            public enum Direction
            {
                NorthEast,
                NorthWest,
                SouthEast,
                SouthWest
            };

            private float xCoordinate;
            private float yCoordinate;
            public MyVector ()
            {
                xCoordinate = 0f;
                yCoordinate = 0f;
            }
            public MyVector (Direction direction)
            {
                switch(direction)
                {
                    case Direction.NorthEast:
                        {
                            xCoordinate = 1f;
                            yCoordinate = -1f;
                            break;
                        }
                    case Direction.NorthWest:
                        {
                            xCoordinate = -1f;
                            yCoordinate = -1f;
                            break;
                        }
                    case Direction.SouthEast:
                        {
                            xCoordinate = 1f;
                            yCoordinate = 1f;
                            break;
                        }
                    case Direction.SouthWest:
                        {
                            xCoordinate = -1f;
                            yCoordinate = 1f;
                            break;
                        }
                }
            }
            
            public static Vector2 operator *(MyVector v1, Vector2 v2)
            {
                return new Vector2(v1.xCoordinate * v2.X, v1.yCoordinate * v2.Y);
            }
        }
    }
}
