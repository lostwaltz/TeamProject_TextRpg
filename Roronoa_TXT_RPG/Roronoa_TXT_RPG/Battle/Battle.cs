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
    public class Battle
    {
        //배틀중: null, true: 승리, false: 패배
        bool? isVictory = null;
        List<Monster> monsters = new List<Monster>();
        int monsterDeadCount = 0; //죽인 몬스터 수

        internal int Scene_SelectPlayerAction()
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
                Console.WriteLine($"Lv.{monsters[i].level} {monsters[i].name} HP {monsters[i].health}");
            }
            Console.WriteLine("");
            Console.WriteLine("");

            //[내정보]
            //Lv.1  Chad(전사)
            //HP 100 / 100
            Console.WriteLine("[내 정보]");
            Console.WriteLine($"Lv.{player.level} {player.name} ({player.job})");
            Console.WriteLine($"{player.curHealth}/{player.maxHealth}");
            Console.WriteLine("");

            //1.공격 
            Console.WriteLine("1. 공격");
            Console.WriteLine("");

            //원하시는 행동을 입력해주세요.
            //>>플레이어 선택지 제공 함수
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");

            return 0;
        }

        internal int Scene_SelectAttackTarget(int playerSelectNum)
        {
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
                Console.WriteLine($"{selectNumber} Lv.{monsters[i].level} {monsters[i].name} HP {monsters[i].health}");
            }
            Console.WriteLine("");
            Console.WriteLine("");

            //[내정보]
            //Lv.1  Chad(전사)
            //HP 100 / 100
            Console.WriteLine("[내 정보]");
            Console.WriteLine($"Lv.{player.level} {player.name} ({player.job})");
            Console.WriteLine($"HP {player.curHealth}/{player.maxHealth}");
            Console.WriteLine("");

            //0.취소
            Console.WriteLine("0. 취소");
            Console.WriteLine("");

            //대상을 선택해주세요.
            //>>
            Console.WriteLine("대상을 선택해주세요.");
            Console.Write(">>");

            return 0;
        }

        internal void Scene_PlayerAttackResult(int targetMonster)
        {
            Console.Clear();
            int targetCurHP = monsters[targetMonster].CurHealth;
            //Battle!!
            Console.WriteLine("Battle!!");
            Console.WriteLine("");

            //Chad 의 공격!
            //Lv.3 공허충 을(를) 맞췄습니다. [데미지: 10]
            Console.WriteLine($"{player.name}의 공격!");
            Console.WriteLine($"Lv{monsters[targetMonster].Name}을(를) 맞췄습니다. [데미지: {player.attackDamage}]");
            monsters[targetMonster].CurHealth -= player.attackDamage;

            //Lv.3 공허충
            //HP 10->Dead
            if (monsters[targetMonster].isDead)
            {
                Console.WriteLine($"Lv.{monsters[targetMonster].Level} {monsters[targetMonster].Name}");
                Console.WriteLine($"HP {monsters[targetMonster].CurHealth} -> Dead");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine($"Lv.{monsters[targetMonster].Level} {monsters[targetMonster].Name}");
                Console.WriteLine($"HP {targetCurHP} -> HP {monsters[targetMonster].CurHealth}");
                Console.WriteLine("");
            }

            //0.다음
            Console.WriteLine("0. 다음");
            Console.WriteLine("");
            //>>
            Console.Write(">>");


            //몬스터를 전부 죽였으면 win, 아니면 몬스터Phase
            foreach (Monster monster in monsters)
            {
                if (monster.isDead)
                    monsterDeadCount++;
            }
            if (monsterDeadCount == monsters.Count)
            {
                isVictory = true;
            }
        }



        public void Scene_MonsterAttackResult()
        {
            Console.Clear();
            //Battle!!
            Console.WriteLine("Battle!!");
            Console.WriteLine("");

            //Lv.2 미니언 의 공격!
            //Chad 을(를) 맞췄습니다.  [데미지: 6]
            Console.WriteLine($"Lv.{monster.level} {monster.name}의 공격!");
            Console.WriteLine($"Lv.{player.level} {player.name}을(를) 맞췄습니다. [데미지: {monster.damage}]");

            //Lv.1 Chad
            //HP 100-> 94
            Console.WriteLine($"Lv.{player.level} {player.name} ({player.job})");
            Console.WriteLine($"{player.curHealth} -> {player.curHealth-monster.damage}");
            Console.WriteLine("");

            //0.다음
            Console.WriteLine("0. 다음");
            Console.WriteLine("");
            //대상을 선택해주세요.
            //>>
            Console.WriteLine("대상을 선택해주세요.");
            Console.Write(">>");
        }

        public void Scene_BattleResult(bool? isVictory, int beforeBattlePlayerHP)
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
                Console.WriteLine($"Lv.{player.level} {player.name} ({player.job})");
                Console.WriteLine($"{beforeBattlePlayerHP} -> {player.curHealth}");
                Console.WriteLine("");

                //0.다음
                Console.WriteLine("0. 다음");
                Console.WriteLine("");
                //>>
                Console.Write(">>");

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
                Console.WriteLine($"Lv.{player.level} {player.name} ({player.job})");
                Console.WriteLine($"{beforeBattlePlayerHP} -> 0");
                Console.WriteLine("");

                //0.다음
                Console.WriteLine("0. 다음");
                Console.WriteLine("");
                //>>
                Console.Write(">>");
            }
            else
            {
                Console.WriteLine("? 이건 뭐야 미친 오류다 ㄷㄷ 여기 어떻게 왔어");
            }
        }



    }
}
