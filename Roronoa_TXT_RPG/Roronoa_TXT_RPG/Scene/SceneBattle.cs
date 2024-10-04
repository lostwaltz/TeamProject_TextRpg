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
        Battle _battle;
        internal SceneBattle()
        {
            _battle = new Battle();
        }
        public override void SceneUpdate()
        {
            _battle.SceneSelectPlayerAction();//행동 선택
            if (_battle.LastSelect() != 0) //0이면 로비
            { 
                _battle.SceneSelectAttackTarget();//타겟 선택
                if (_battle.LastSelect() != 0) //0이면 행동 취소
                {
                    _battle.ScenePlayerAttackResult();//공격 결과
                    _battle.DequeueSelection();
                    _battle.SceneIsBattleResult(); //배틀이 끝이면 전투결과
                    if (_battle.LastSelect() != 0)
                    {
                        _battle.SceneMonsterAttackResult();//몬스터의 공격
                        _battle.DequeueSelection();
                        _battle.SceneIsBattleResult(); //배틀이 끝이면 전투결과
                    }
                }
                else
                {
                    while (_battle.DequeueSelection() > -1) { }
                }
                if (_battle.DequeueSelection() == 0) //배틀이 끝남
                {
                    Program.stage.StageUp();
                    _battle = new Battle();
                    SceneManager.instance?.SceneChange(SCENE_TYPE.SCENE_LOBY);
                }
            }
            else
            {
                _battle.DequeueSelection();
                SceneManager.instance?.SceneChange(SCENE_TYPE.SCENE_LOBY);
            }
        }
    }
}
