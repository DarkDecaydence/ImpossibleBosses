using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace ImpossibleBosses
{
    class TileHandler
    {
        private static Dictionary<String, Texture2D> tileSets = new Dictionary<string, Texture2D>();

        public static void AddTileSet(String setName, Texture2D tileSet)
        { tileSets.Add(setName, tileSet); }

        public static Texture2D GetTileSet(String setName)
        {
            Texture2D tileSet;
            if (tileSets.TryGetValue(setName, out tileSet))
            { return tileSet; }
            else { throw new Exception("No such tile set!!"); }
        }
    }
}
