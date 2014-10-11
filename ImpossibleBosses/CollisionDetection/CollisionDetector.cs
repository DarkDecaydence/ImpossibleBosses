using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ImpossibleBosses.CollisionDetection
{
    class CollisionDetector
    {        
        public bool CheckCollision(Rectangle rect1, Rectangle rect2)
        { return rect1.Intersects(rect2); }
    }
}
