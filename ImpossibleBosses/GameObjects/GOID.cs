using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImpossibleBosses.GameObjects
{
    struct GOID
    {
        int primaryID;
        int secondaryID;

        public GOID(int prim, int sec)
        { primaryID = prim; secondaryID = sec; }
    }
}
