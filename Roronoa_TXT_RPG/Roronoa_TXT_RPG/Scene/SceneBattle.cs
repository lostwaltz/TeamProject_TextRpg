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
        public override void SceneUpdate()
        {
            
            _battle.SceneSelectPlayerAction();
            if (_battle.LastSelect() != 0) { //0이면 도망
                _battle.SceneSelectAttackTarget();
                if (_battle.LastSelect() != 0)//0이면 다시 플레이어 선택
                {
                    _battle.ScenePlayerAttackResult();
                    _battle.DequeueSelection();
                    _battle.SceneIsBattleResult(); 
                    if (_battle.LastSelect() != 0)
                    {
                        _battle.SceneMonsterAttackResult();
                        _battle.DequeueSelection();
                        _battle.SceneIsBattleResult(); 
                    }
                }
                else
                {
                    while (_battle.DequeueSelection() > -1) { }
                }
                if (_battle.DequeueSelection() == 0)
                {
                    //Program.stage.StageUp();
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
