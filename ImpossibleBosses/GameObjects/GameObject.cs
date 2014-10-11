using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ImpossibleBosses.GameObjects
{
    class GameObject
    {
        public int Facing { get; set; }
        public Rectangle Position;

        public GameObject(int X, int Y)
        {
            Facing = 0;
            Position = new Rectangle(X, Y, 40, 40);
        }

        public void Move(Vector2 direction)
        { Position.Offset((int)direction.X, (int)direction.Y); }

        public GameObject TryMove(Vector2 direction)
        {
            var newObj = (GameObject)this.MemberwiseClone();
            newObj.Move(direction);
            return newObj;
        }
    }
}
