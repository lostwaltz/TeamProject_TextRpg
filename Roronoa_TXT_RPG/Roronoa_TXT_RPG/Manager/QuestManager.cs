using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Roronoa_TXT_RPG.Quest;

namespace Roronoa_TXT_RPG
{
    public class QuestPair
    {
        public QuestPair(Quest inputQuest)
        {
            quest = inputQuest;
            isSelect = false;
        }
        public Quest quest;
        public bool isSelect;
    }

    internal class QuestManager
    {
        private List<QuestPair> questPairList = new List<QuestPair>();

        public static QuestManager? instance { get; private set; }

        public static void InitQuestManager()
        {
            if (instance == null)
            {
                instance = new QuestManager();

                instance.questPairList.Add(new QuestPair(new Quest("마을을 위협하는 미니언 처치")));
                instance.questPairList.Add(new QuestPair(new Quest("장비를 장착 해보기")));
                
            }
        }

        public void ShowQuestList()
        {
            int index = 1;

            Console.Write("Quest!!\n\n");

            foreach (QuestPair pair in questPairList)
            {
                Console.WriteLine(index + ". " + pair.quest.QuestData.Title.ToString());
                index++;
            }

        }

        public void ShowQuestInfo(int index)
        {
            if (false == CheckIndex(index))
                return;

            Console.Write("Quest!!\n\n");

            QuestStruct questData = questPairList[index].quest.QuestData;

            Console.WriteLine(questData.Title + "\n");
            Console.WriteLine(questData.Story + "\n");
            Console.WriteLine(questData.Progress + " (" + questData.CurValue + "/" + questData.TargetValue + ")");

            Console.WriteLine("\n- 보상 -\n");

            PrintQuestReward(index);
        }

        public void SelectionProgress(int index)
        {
            if (false == CheckIndex(index))
                return;

            QuestPair pair = questPairList[index];

            if (false == pair.isSelect)
            {
                Console.Write("1.수락\n0.돌아가기\n>> ");
                Program.KeyInputCheck(out int selectNumber, 1);

                if (1 == selectNumber)
                    pair.isSelect = true;
                else if (0 == selectNumber)
                    return;
            }
            else if(true == pair.isSelect)
            {
                if(true == pair.quest.GetIsGoal())
                {
                    Console.Write("1.보상받기\n0.돌아가기\n>> ");
                    Program.KeyInputCheck(out int selectNumber, 1);

                    if(1 == selectNumber)
                    {
                        //pair.quest.ApplyReward()
                        questPairList.Remove(pair);
                    }
                    else if (0 == selectNumber)
                        return;

                }
                else if(false == pair.quest.GetIsGoal())
                {
                    Console.Write("아무 키로 돌아가기\n>> ");
                    Console.ReadLine();
                    return;
                }
            }
        }

        public bool CheckIndex(int index)
        {
            if (0 <= index && index < questPairList.Count)
                return true;

            return false;
        }

        private void PrintQuestReward(int index)
        {
            questPairList[index].quest.RenderReward();
        }

        public int GetQuestCount()
        {
            return questPairList.Count;
        }

        public bool IsQuestClear(int index)
        {
            return questPairList[index].quest.GetIsGoal();
        }

        public void ApplyReward(int index)
        {
            if (false == IsQuestClear(index))
                return;

            // 플레이어 인터페이스 받아서 호출
            // questList[index].ApplyReward(IDummyPlayerInterface);

            questPairList.RemoveAt(index);
        }
    }
}
