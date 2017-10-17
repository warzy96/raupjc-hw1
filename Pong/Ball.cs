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

            public float XCoordinate { get; }
            public float YCoordinate { get; } 
            public Direction Course { get; }
            public MyVector (Direction direction)
            {
                switch(direction)
                {
                    case Direction.NorthEast:
                        {
                            XCoordinate = 1f;
                            YCoordinate = -1f;
                            break;
                        }
                    case Direction.NorthWest:
                        {
                            XCoordinate = -1f;
                            YCoordinate = -1f;
                            break;
                        }
                    case Direction.SouthEast:
                        {
                            XCoordinate = 1f;
                            YCoordinate = 1f;
                            break;
                        }
                    case Direction.SouthWest:
                        {
                            XCoordinate = -1f;
                            YCoordinate = 1f;
                            break;
                        }
                }
                Course = direction;

            }

           public static Vector2 operator *(MyVector vector, float f)
            {
                return new Vector2(f * vector.XCoordinate, f * vector.YCoordinate);
            }
            public static Vector2 operator *(MyVector vector, Vector2 vector2)
            {
                return new Vector2(vector.XCoordinate * vector2.X, vector.YCoordinate * vector2.Y);
            }
        }
    }
}
