using Roronoa_TXT_RPG.Monster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

enum BATTLE_SCENE_TYPE { PLAYER_ACTION, PLAYER_ATTACK_ACTION, ENEMY_PHASE, BATTLE_RESULT}

namespace Roronoa_TXT_RPG
{
    internal class SceneBattle : Scene
    {

        Battle battle = new Battle();


        //Battle이 일하는 곳
        public override void SceneUpdate()
        {
            



            Program.KeyInputCheck(out int number, 10);


        }
    }
}
