using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImpossibleBosses.LevelGenerator;

namespace ImpossibleBossesTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestLevelSerializer()
        {
            String levelString = "";
            int[] dimensions = LevelSerializer.ReadDebug(out levelString);

            Assert.Inconclusive(levelString + "\n[" + dimensions[0] + ";" + dimensions[1] + "]");
        }
    }
}
