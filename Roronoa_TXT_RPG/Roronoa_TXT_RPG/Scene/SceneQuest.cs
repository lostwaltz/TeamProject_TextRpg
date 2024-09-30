using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Roronoa_TXT_RPG.MonsterKillEventArgs;

namespace Roronoa_TXT_RPG
{
   

    internal class SceneQuest : Scene
    {
        private List<int> _questIndexList = new List<int>();

        public override void SceneUpdate()
        {
            if (null == QuestManager.instance)
                return;

            QuestManager.instance.ShowQuestList();

            EventManager.instance?.Publish<MonsterKillEventArgs>(new MonsterKillEventArgs(MonsterEventType.GOBLIN));

            Console.Write("0. 나가기\n\n원하시는 퀘스트를 선택해주세요.\n" + ">> ");

            if (false == Program.KeyInputCheck(out int selectNumber, QuestManager.instance.GetQuestCount()))
                return;
            if (0 == selectNumber)
            {
                SceneManager.instance?.SceneChange(SCENE_TYPE.SCENE_LOBY);
                return;
            }
            int questIndex = selectNumber - 1;

            Console.Clear();
            QuestManager.instance.ShowQuestInfo(questIndex);
            QuestManager.instance.SelectionProgress(questIndex);
        }
    }
}
