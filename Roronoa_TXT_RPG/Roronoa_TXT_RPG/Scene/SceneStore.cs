using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roronoa_TXT_RPG
{
    internal class SceneStore : Scene
    {
        public SceneStore()
        {
        }
        public override void SceneUpdate()
        {
            
            ItemManager.instance?.PrintStore();

        }
    }
}
