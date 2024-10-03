using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Roronoa_TXT_RPG.Monster;
using static System.Net.Mime.MediaTypeNames;

namespace Roronoa_TXT_RPG
{
    internal class Battle
    {
        //배틀중: null, true: 승리, false: 패배
        private bool? isVictory;

        //배틀 스테이지 몬스터 리스트
        List<Monster> monsters = new List<Monster>();
        int _monsterDeadCount; //죽인 몬스터 수

        //선택Queue
        Queue<int> selectQueue = new Queue<int>();

        //Next선택지 개수(0. 다음 )
        int _selectNextCount = 0;

        //전투 시작 전 HP 저장
        int _beforeBattlePlayerHP;
        internal Battle()
        {
            isVictory = null;
            _monsterDeadCount = 0;
            _beforeBattlePlayerHP = Program.player.curHealthPoint;

            BattleCreateMonsters();
        }

        internal void SceneSelectPlayerAction()
        {
            Console.Clear();
            Console.WriteLine("Battle!!");
            Console.WriteLine("");
            Program.stage.PrintStage(); Console.WriteLine("!");
            Console.WriteLine("");
            //Lv.2 미니언 HP 15
            //Lv.5 대포미니언 HP 25
            //LV.3 공허충 HP 10
            for (int i = 0; i < monsters.Count; i++)
            {
                monsters[i].PrintCharacterInfo();
            }
            Console.WriteLine("");
            Console.WriteLine("");

            //[내정보]
            //Lv.1  Chad(전사)
            //HP 100 / 100
            Program.player.PrintCharacterInfo();
            Console.WriteLine("");

            //1. 공격 
            //2. ...
            //원하시는 행동을 입력해주세요.
            //>>
            Program.player.BattlePlayerSelect(selectQueue);

        }

        internal void SceneSelectAttackTarget()
        {
            Console.Clear();
            Console.WriteLine("Battle!!");
            Console.WriteLine("");
            Program.stage.PrintStage(); Console.WriteLine("!");
            Console.WriteLine("");
            //1 Lv.2 미니언 HP 15
            //2 Lv.5 대포미니언 HP 25
            //3 LV.3 공허충 Dead
            for (int i = 0; i < monsters.Count; i++)
            {
                int selectNumber = i + 1;
                Console.Write($"{selectNumber} ");
                monsters[i].PrintCharacterInfo();
            }
            Console.WriteLine("");
            Console.WriteLine("");

            //[내정보]
            //Lv.1  Chad(전사)
            //HP 100 / 100
            Program.player.PrintCharacterInfo();
            Console.WriteLine("");

            Console.WriteLine("0. 취소");
            Console.WriteLine("");
            Console.WriteLine("대상을 선택해주세요.");
            Console.Write(">>");
            Program.KeyInputCheck(out int _selectTarget, monsters.Count, true);
            if (_selectTarget == 0) { }
            else if (monsters[_selectTarget - 1].isDead)//죽은 몬스터 선택 시 
            {
                do
                {
                    Console.Write("잘못된 입력입니다.>>");
                    Thread.Sleep(1000);
                    Program.KeyInputCheck(out _selectTarget, monsters.Count, true);
                    if (_selectTarget == 0) { break; }
                } while (monsters[_selectTarget - 1].isDead);
            }

            //선택 큐에 넣기
            selectQueue.Enqueue(_selectTarget);
        }

        internal void ScenePlayerAttackResult()
        {
            Console.Clear();
            Console.WriteLine("Battle!!");
            Console.WriteLine("");
            Program.stage.PrintStage(); Console.WriteLine("!");
            Console.WriteLine("");
            //Chad 의 공격!
            //Lv.3 공허충 을(를) 맞췄습니다. [데미지: 10]
            //
            //Lv.3 공허충
            //HP 10->Dead
            Program.player.BattlePlayerAction(selectQueue, monsters);

            Console.WriteLine("0. 다음");
            Console.WriteLine("");
            Console.Write(">>");
            Program.KeyInputCheck(out int _selectNext, _selectNextCount);
            //선택 큐에 넣기
            selectQueue.Enqueue(_selectNext);

            //몬스터를 전부 죽였으면 win, 아니면 몬스터Phase
            foreach (Monster monster in monsters)
            {
                if (monster.isDead)
                    _monsterDeadCount++;
            }
            if (_monsterDeadCount == monsters.Count)
            {
                isVictory = true;
            }
            _monsterDeadCount = 0;
        }

        public void SceneMonsterAttackResult()
        {
            Console.Clear();
            Console.WriteLine("Battle!!");
            Console.WriteLine("");
            Program.stage.PrintStage(); Console.WriteLine("!");
            Console.WriteLine("");

            //모든 몬스터 공격~
            //Lv.2 미니언 의 공격!
            //Chad 을(를) 맞췄습니다.  [데미지: 6]
            //
            //Lv.1 Chad
            //HP 100-> 94
            foreach (Monster monster in monsters)
            {
                //죽지 않은 몬스터만 공격
                if (!monster.isDead)
                {
                    //몬스터 공격 구현부
                    //만약 몬스터 스킬이 생기면 몬스터 클래스에 공격 메커니즘을 만들어야 할 듯하다.
                    monster.Attack(Program.player);
                }
            }

            if (Program.player.isDead)
            {
                isVictory = false;
            }

            Console.WriteLine("0. 다음");
            Console.WriteLine("");
            Console.Write(">>");
            Program.KeyInputCheck(out int _selectNext, _selectNextCount);
            //선택 큐에 넣기
            selectQueue.Enqueue(_selectNext);

        }

        //Battle이 끝인지? 끝이면 승리Scene과 패배Scene을 출력한다
        public void SceneIsBattleResult()
        {
            Console.Clear();
            if (isVictory == true)
            {
                Console.WriteLine("Battle!! - Result");
                Console.WriteLine("Victory");
                Console.WriteLine("");
                Program.stage.PrintStage(); Console.WriteLine(" Clear!");
                Console.WriteLine("");
                Console.WriteLine($"던전에서 몬스터 {monsters.Count}마리를 잡았습니다.");
                Console.WriteLine("");

                //Lv.1 Chad
                //HP 100-> 74
                Program.player.PrintCharacterInfo(_beforeBattlePlayerHP);
                Console.WriteLine("");

                Console.WriteLine("0. 다음");
                Console.WriteLine("");
                Console.Write(">>");
                Program.KeyInputCheck(out int _selectNext, _selectNextCount);
                //선택 큐에 넣기
                selectQueue.Enqueue(_selectNext);

            }
            else if (isVictory == false)
            {
                Console.WriteLine("Battle!! - Result");
                Console.WriteLine("You Lose");
                Console.WriteLine("");
                Program.stage.PrintStage(); Console.WriteLine(" Fail!");
                //Lv.1 Chad
                //HP 100-> 0
                Program.player.PrintCharacterInfo(_beforeBattlePlayerHP);
                Console.WriteLine("");

                Console.WriteLine("0. 다음");
                Console.WriteLine("");
                Console.Write(">>");
                Program.KeyInputCheck(out int _selectNext, _selectNextCount);
                //선택 큐에 넣기
                selectQueue.Enqueue(_selectNext);
            }
            else { }
        }





        public int LastSelect()//Queue가 비어있으면 -1 반환
        {
            if (selectQueue.Count == 0)
            {
                return -1;
            }
            List<int> selectList = selectQueue.ToList();
            return selectList[selectList.Count - 1];
        }


        public int DequeueSelection()//Queue가 비어있으면 -1 반환
        {
            if (selectQueue.TryDequeue(out int result))
            {
                return result;
            }
            return -1;
        }


        public void BattleCreateMonsters()//각 Stage별 몬스터를 가져온다
        {
            List<MONSTER_TYPE> monstersTypeList = Program.stage.TakeMostersTypeForEachStage();
            for (int i = 0; i < monstersTypeList.Count; i++)
            {
                switch (monstersTypeList[i])
                {
                    case MONSTER_TYPE.SLIME:
                        monsters.Add(new Slime());
                        break;
                    case MONSTER_TYPE.GOBLIN:
                        monsters.Add(new Goblin());
                        break;
                    case MONSTER_TYPE.ELF:
                        monsters.Add(new Elf());
                        break;
                    case MONSTER_TYPE.ORC:
                        monsters.Add(new Orc());
                        break;
                    case MONSTER_TYPE.DRAGON:
                        monsters.Add(new Dragon());
                        break;
                }
            }
        }


    }
}
