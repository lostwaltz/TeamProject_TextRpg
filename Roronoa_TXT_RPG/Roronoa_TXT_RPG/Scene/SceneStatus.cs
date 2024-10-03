using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roronoa_TXT_RPG
{
    internal class SceneStatus : Scene
    {
        Queue<int> selectQueue = new Queue<int>();
        public SceneStatus()
        {
        }

        public override void SceneUpdate()
        {
            Program.player.DisplayStatusAndItemInfo();
        }
    }
}
