﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roronoa_TXT_RPG.Manager;

namespace Roronoa_TXT_RPG
{
    internal class SceneStore : Scene
    {
        public SceneStore()
        {
        }
        public override void SceneUpdate()
        {
            
            ItemManager.instance?.PrintStore(STORE_ACTION_TYPE.WATCH);

        }
    }
}
