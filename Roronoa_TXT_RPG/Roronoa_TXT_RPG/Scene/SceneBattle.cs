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

        Battle _battle = new Battle();

        //선택지 개수 설정
        int _playerActionCount = 2;
        int _attackTargetCount = 4;

        //Battle이 시작됐을 때 메인
        public override void SceneUpdate()
        {

            //플레이어 행동선택Scene
            _battle.Scene_SelectPlayerAction();

            //플레이어 행동선택
            Program.KeyInputCheck(out int selectPlayerAction, _playerActionCount);
            switch (selectPlayerAction)
            {
                case 0://없음
                    break;
                case 1://공격
                    _battle.Scene_SelectAttackTarget();
                    Program.KeyInputCheck(out int selectAttackTarget, _attackTargetCount);
                    break;
                case 2://선택안됨
                    break;
            }

        }
    }
}
