using Roronoa_TXT_RPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Roronoa_TXT_RPG.MonsterKillEventArgs;

namespace Roronoa_TXT_RPG
{
    internal class SceneLoby : Scene
    {
        public override void SceneUpdate()
        {
            Console.Write(
                "스파르타 던전에 오신 여러분 환영합니다.\n" +
                "이제 전투를 시작할 수 있습니다.\n\n" +
                "1. 상태 보기\n" +
                "2. 전투 시작\n\n" +
                "원하시는 행동을 입력해주세요.\n>> ");


            Program.KeyInputCheck(out int number, 10);

            switch (number)
            {
                case 1:
                    SceneManager.instance?.SceneChange(SCENE_TYPE.SCENE_STATUS);
                    break;
                case 2:
                    SceneManager.instance?.SceneChange(SCENE_TYPE.SCENE_BATTLE);
                    break;
            }
        }
    }
}
