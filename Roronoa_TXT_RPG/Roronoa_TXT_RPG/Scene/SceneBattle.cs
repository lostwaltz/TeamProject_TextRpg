using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

enum BATTLE_SCENE_TYPE { PLAYER_ACTION, PLAYER_ATTACK_ACTION, ENEMY_PHASE, BATTLE_RESULT}
enum PLAYER_ACTION { ATTACK = 1 }

namespace Roronoa_TXT_RPG
{
    internal class SceneBattle : Scene
    {

        Battle _battle = new Battle();
        int selectNum = 0;
        int selectBattleEnd = -1;
        Queue<int> selectQueue = new Queue<int>();

        //Battle이 시작됐을 때 메인
        public override void SceneUpdate()
        {
            
            _battle.Scene_SelectPlayerAction();

            _battle.Scene_SelectAttackTarget();

            //마지막 선택이 0(0. 취소)일 때, 맨 처음으로 돌아가기
            
            if (_battle.LastSelect() != 0)
            {//>>속행

                _battle.Scene_PlayerAttackResult();

                _battle.Scene_BattleResult(); //조건을 충족하면 Battle종료, Queue에 0(0. 다음)이 담김.

                //마지막 선택이 0(0. 다음)일 때, 배틀 종료
                if (_battle.LastSelect() != 0)
                {//>>배틀 속행
                    _battle.Scene_MonsterAttackResult();
                    _battle.DequeueSelection();// 0 (0. 다음)

                    _battle.Scene_BattleResult(); //조건을 충족하면 Battle종료, Queue에 0(0. 다음)이 담김.
                    //마지막 선택이 0(0. 다음)일 때, 배틀 종료
                }
                //>>배틀 종료
            }
            else//>>플레이어 선택으로 돌아가기
            {
                //selectQueue 비우기
                while (_battle.DequeueSelection() > -1)
                {

                }
            }
            
            //>>배틀 종료 0(0. 다음) Dequeue
            if (_battle.DequeueSelection() == 0)
            {
                SceneManager.instance?.SceneChange(SCENE_TYPE.SCENE_LOBY);
            }


        }
    }
}
