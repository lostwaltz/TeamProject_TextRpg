﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roronoa_TXT_RPG
{
    internal class SceneLoby : Scene
    {
        public override void SceneUpdate()
        {
            Program.KeyInputCheck(out int number, 10);
        }
    }
}
