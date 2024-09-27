using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

enum BATTLE_SCENE_TYPE { PLAYER_ACTION, PLAYER_ATTACK_ACTION, ENEMY_PHASE, BATTLE_RESULT}


namespace Roronoa_TXT_RPG
{
    internal class SceneBattle : Scene
    {

        Battle _battle = new Battle();

        //배틀중: null, true: 승리, false: 패배
        bool? isVictory = null;


        //선택지 최대 개수 설정
        int _playerActionCount = 2;
        int _attackTargetCount = 4;
        int _nextCount = 1;

        //전투 시작 전 HP 저장
        int beforeBattlePlayerHP = player.Health;

        //Battle이 시작됐을 때 메인
        public override void SceneUpdate()
        {
            //선택num
            int _selectPlayerAction=0;
            int _selectAttackTarget=0;
            int _selectNext = 0;
            List<Monster> monsters = new List<Monster>();

            //플레이어행동선택Scene
            _battle.Scene_SelectPlayerAction(monsters);
            //플레이어 선택
            Program.KeyInputCheck(out _selectPlayerAction, _playerActionCount);
            switch (_selectPlayerAction)
            {
                case 0://없음
                    break;
                case 1://공격
                    //공격대상선택Scene
                    _battle.Scene_SelectAttackTarget(monsters);
                    //공격대상 선택
                    Program.KeyInputCheck(out _selectAttackTarget, _attackTargetCount);
                    break;
                case 2://선택안됨
                    break;
            }

            //0일 땐 플레이어 행동선택Scene으로 돌아간다
            if (_selectAttackTarget != 0)
            {
                //플레이어공격결과Scene
                _battle.Scene_PlayerAttackResult(monsters, _selectAttackTarget);
                //플레이어 선택
                Program.KeyInputCheck(out _selectNext, _nextCount);

                //몬스터를 전부 죽였는지? win : 몬스터Phase
                int monsterDeadCount = 0;
                foreach (Monster monster in monsters)
                {
                    if(monster.isDead)
                        monsterDeadCount++;
                }
                if (monsterDeadCount == monsters.Count)
                {
                    isVictory = true;
                }
                    
                //win이면 몬스터Phase 스낍
                if(isVictory == null)
                {
                    //몬스터공격결과Scene
                    _battle.Scene_MonsterAttackResult();
                    //플레이어 선택
                    Program.KeyInputCheck(out _selectNext, _nextCount);

                }
                else//if (isVictory != null) ==전투결과Scene
                {
                    //전투결과Scene (승리, 패배 둘 다 여기 있음)
                    _battle.Scene_BattleResult(isVictory, beforeBattlePlayerHP, monsters.Count);
                    //플레이어 선택
                    Program.KeyInputCheck(out _selectNext, _nextCount);
                }


            }

            
            

        }
    }
}
