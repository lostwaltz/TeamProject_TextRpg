﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roronoa_TXT_RPG
{
    internal class SceneStatus : Scene
    {
        public SceneStatus()
        {
        }

        public override void SceneUpdate()
        {
            Program.player.DisplayInfo();
            Program.KeyInputCheck(out int YMCA, 666);
        }
    }
}
