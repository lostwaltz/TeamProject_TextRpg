using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Roronoa_TXT_RPG
{
    public class Battle
    {

        public void Scene_SelectPlayerAction()
        {
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
            //>>
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");


        }

        public void Scene_SelectAttackTarget()
        {
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
            Console.WriteLine($"{player.curHealth}/{player.maxHealth}");
            Console.WriteLine("");

            //0.취소
            Console.WriteLine("0. 취소");
            Console.WriteLine("");

            //대상을 선택해주세요.
            //>>
            Console.WriteLine("대상을 선택해주세요.");
            Console.Write(">>");
        }

        public void PlayerAttackResult()
        {

        }

        public void MonsterAttackResult()
        {

        }

        public void BattleResult()
        {

        }



    }
}
