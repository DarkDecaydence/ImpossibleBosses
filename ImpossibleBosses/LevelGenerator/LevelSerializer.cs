using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ImpossibleBosses.LevelGenerator
{
    public class LevelSerializer
    {
        public static int[] ReadDebug(out String levelString)
        {
            String rawLevel = "";
            String curLine = "";
            int width = 0, height = 0;

            StreamReader file = new StreamReader(@"C:\Users\Zander\Documents\Visual Studio 2012\Projects\ImpossibleBosses\ImpossibleBosses\RawContent\debug3.board");

            while ((curLine = file.ReadLine()) != null)
            {
                rawLevel += curLine;
                width = curLine.Length;
                height++;
            }

            levelString = rawLevel;

            file.Close();
            return new int[] { width, height };
        }
    }
}
