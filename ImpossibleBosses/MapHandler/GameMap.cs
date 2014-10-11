using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ImpossibleBosses.GameObjects;
using ImpossibleBosses.CollisionDetection;

namespace ImpossibleBosses.MapHandler
{
    class GameMap
    {
        public Vector2 Dimensions { get; set; }
        private String levelString = "";
        private List<GameObject> gameObjects = new List<GameObject>();
        private CollisionDetector collider = new CollisionDetector();


        public GameMap()
        {
            int[] dimensions = LevelGenerator.LevelSerializer.ReadDebug(out levelString);
            Dimensions = new Vector2(dimensions[0], dimensions[1]);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < Dimensions.Y; i++)
                for (int j = 0; j < Dimensions.X; j++)
                {
                    int wall = 0;
                    if (i * (int)Dimensions.X + j < levelString.Length &&
                        Int32.TryParse(levelString.Substring(i * (int)Dimensions.X + j, 1), out wall))
                    {
                        if (wall == 0)
                        {
                            var curPos = new Vector2(j * 40, i * 40);
                            spriteBatch.Draw(TileHandler.GetTileSet("basic"), curPos, new Rectangle(0, 0, 40, 40), Color.White);
                            gameObjects.Add(new GameObject((int)curPos.X, (int)curPos.Y));
                        }
                    }
                }
        }

        public bool isFree(GameObject gObj)
        {
            foreach (GameObject curObj in gameObjects)
            {
                if (curObj.Equals(gObj)) { continue; }
                if (collider.CheckCollision(curObj.Position, gObj.Position)) { return false; }
            }
            return true;
        }
    }
}
