using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roronoa_TXT_RPG
{
    internal class SceneQuest : Scene
    {
        public override void SceneUpdate()
        {
            Console.Write(
                "Quest!!\n\n" +
                "1. 마을을 위협하는 미니언 처치\n" +
                "2. 장비를 장착해보자\n" +
                "3. 더욱 더 강해지기!\n\n\n" +
                "원하시는 퀘스트를 선택해주세요.\n" +
                ">>");

            Program.KeyInputCheck(out int selectNumber, 10);
        }
    }
}
