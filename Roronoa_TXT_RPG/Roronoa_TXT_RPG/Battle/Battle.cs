using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
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
        int _selectNextCount = 1;

        //전투 시작 전 HP 저장
        int _beforeBattlePlayerHP;
        internal Battle()
        {
            isVictory = null;
            _monsterDeadCount = 0;
            _beforeBattlePlayerHP = Program.player.curHealthPoint;
        }


        //완료
        //나오는 선택 => 플레이어 행동: 1.공격, 2. 스킬...(0없음)
        internal void SceneSelectPlayerAction()
        {
            Console.Clear();
            //Battle!!
            Console.WriteLine("Battle!!");
            Console.WriteLine("");

            //Lv.2 미니언 HP 15
            //Lv.5 대포미니언 HP 25
            //LV.3 공허충 HP 10
            for (int i = 0; i < monsters.Count; i++)
            {
                monsters[i].PrintCharactorInfo();
            }
            Console.WriteLine("");
            Console.WriteLine("");

            //[내정보]
            //Lv.1  Chad(전사)
            //HP 100 / 100
            Program.player.PrintCharactorInfo();
            Console.WriteLine("");

            //1. 공격 
            //2. ...
            //원하시는 행동을 입력해주세요.
            //>>
            Program.player.BattlePlayerSelect(selectQueue);

        }


        //완료
        //나오는 선택 => 공격할 몬스터 선택: 1 고블린, 2 오크...(0. 취소)
        internal void SceneSelectAttackTarget()
        {
            int a = 1;
            switch (a)
            {
                case 0:
                    Console.Clear();
                    //Battle!!
                    Console.WriteLine("Battle!!");
                    Console.WriteLine("");

                    //1 Lv.2 미니언 HP 15
                    //2 Lv.5 대포미니언 HP 25
                    //3 LV.3 공허충 Dead
                    for (int i = 0; i < monsters.Count; i++)
                    {
                        int selectNumber = i + 1;
                        Console.Write($"{selectNumber} ");
                        monsters[i].PrintCharactorInfo();
                    }
                    Console.WriteLine("");
                    Console.WriteLine("");

                    //[내정보]
                    //Lv.1  Chad(전사)
                    //HP 100 / 100
                    Program.player.PrintCharactorInfo();
                    Console.WriteLine("");

                    //0.취소
                    Console.WriteLine("0. 취소");
                    Console.WriteLine("");

                    //대상을 선택해주세요.
                    //>>
                    Console.WriteLine("대상을 선택해주세요.");
                    Console.Write(">>");
                    Program.KeyInputCheck(out int _selectTarget, monsters.Count+1);

                    //선택 큐에 넣기
                    selectQueue.Enqueue(_selectTarget);
                    break;
            }
        }

        //완료
        //나오는 선택 => 다음으로 넘어가기: 0. 다음...
        internal void ScenePlayerAttackResult()
        {
            Console.Clear();
            //Battle!!
            Console.WriteLine("Battle!!");
            Console.WriteLine("");

            //Chad 의 공격!
            //Lv.3 공허충 을(를) 맞췄습니다. [데미지: 10]
            //
            //Lv.3 공허충
            //HP 10->Dead
            Program.player.BattlePlayerAction(selectQueue, monsters);

            //0.다음
            Console.WriteLine("0. 다음");
            Console.WriteLine("");
            //>>
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


        //완료
        //나오는 선택 => 다음으로 넘어가기: 0. 다음...
        public void SceneMonsterAttackResult()
        {
            Console.Clear();
            //Battle!!
            Console.WriteLine("Battle!!");
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

            //0.다음
            Console.WriteLine("0. 다음");
            Console.WriteLine("");
            //>>
            Console.Write(">>");
            Program.KeyInputCheck(out int _selectNext, _selectNextCount);
            //선택 큐에 넣기
            selectQueue.Enqueue(_selectNext);

        }

        //완료
        //게임결과Scene 게임이 끝났다면 0(0. 다음)이 Queue에 담겨서 반환된다.
        //TryDequeue를 이용해 전투결과가 실행되었는지 확인할 수 있다.
        public void SceneIsBattleResult()
        {
            Console.Clear();
            if (isVictory == true)
            {
                //Battle!! - Result
                Console.WriteLine("Battle!! - Result");
                Console.WriteLine("");

                //Victory
                Console.WriteLine("Victory");
                Console.WriteLine("");

                //던전에서 몬스터 3마리를 잡았습니다.
                Console.WriteLine($"던전에서 몬스터 {monsters.Count}마리를 잡았습니다.");
                Console.WriteLine("");

                //Lv.1 Chad
                //HP 100-> 74
                Program.player.PrintCharactorInfo(_beforeBattlePlayerHP);
                Console.WriteLine("");

                //0.다음
                Console.WriteLine("0. 다음");
                Console.WriteLine("");
                //>>
                Console.Write(">>");
                Program.KeyInputCheck(out int _selectNext, _selectNextCount);
                //선택 큐에 넣기
                selectQueue.Enqueue(_selectNext);

            }
            else if (isVictory == false)
            {
                //Battle!! - Result
                Console.WriteLine("Battle!! - Result");
                Console.WriteLine("");

                //You Lose
                Console.WriteLine("You Lose");
                Console.WriteLine("");

                //Lv.1 Chad
                //HP 100-> 0
                Program.player.PrintCharactorInfo(_beforeBattlePlayerHP);
                Console.WriteLine("");

                //0.다음
                Console.WriteLine("0. 다음");
                Console.WriteLine("");
                //>>
                Console.Write(">>");
                Program.KeyInputCheck(out int _selectNext, _selectNextCount);
                //선택 큐에 넣기
                selectQueue.Enqueue(_selectNext);
            }
            else//isVictory가 null일때
            {

            }

        }

        //selectQueue의 마지막 요소 반환
        public int LastSelect()
        {
            if (selectQueue.Count == 0)//Queue가 비어있으면 -1 반환
            {
                return -1;
            }
            List<int> selectList = selectQueue.ToList();
            return selectList[selectList.Count - 1];
        }

        //selectQueue Dequeue 및 요소 반환
        public int DequeueSelection()
        {
            //selectQueue에 내용이 있으면 내용 반환
            if (selectQueue.TryDequeue(out int result))
            {
                return result;
            }
            return -1;//없으면 -1 반환
        }

    }
}
