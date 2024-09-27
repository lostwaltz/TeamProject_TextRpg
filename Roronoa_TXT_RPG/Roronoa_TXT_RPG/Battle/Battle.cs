using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roronoa_TXT_RPG.Battle
{
    internal class Battle : Scene
    {

        //플레이어 턴
        //플레이어의 공격
        //적의 턴
        //적의 공격

        public void PlayBattle()
        {
            while(true)
            {

            }
        }


        //몬스터들과 캐릭터의 정보 필요
        public override void SceneUpdate()
        {
            ////등장하는 몬스터들의 class 내부 정보가 필요
            //Console.WriteLine("Battle!");
            //Console.WriteLine("");
            //Console.WriteLine($"1 Lv.{level} {name} HP {health}");
            //Console.WriteLine("");

            ////플레이어 캐릭터의 정보가 필요
            //Console.WriteLine("[내 정보]");
            //Console.WriteLine($"Lv.{level} {name} ({job})");
            //Console.WriteLine($"{curHealth}{maxHealth}");
            //Console.WriteLine("");

            //Console.WriteLine("0. 취소");
            //Console.WriteLine("");

            //Console.WriteLine("대상을 선택해주세요.");
            //Console.Write(">>");
        }

        //public void GetAppearedMonster(List<Monster> monster)
        //{
            
        //}
    }
}
