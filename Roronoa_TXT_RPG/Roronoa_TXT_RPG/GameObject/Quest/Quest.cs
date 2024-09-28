using Roronoa_TXT_RPG.GameObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Roronoa_TXT_RPG.MonsterKillEventArgs;
using static Roronoa_TXT_RPG.Quest;

namespace Roronoa_TXT_RPG
{
    public interface IRenderReward
    {
        void RenderReward();
    }

    public class Quest : IRenderReward
    {
        public Quest(string presetName)
        {
            CreateQuestPreset(presetName);
        }

        public struct QuestStruct
        {
            public StringBuilder    Title;
            public StringBuilder    Story;
            public StringBuilder    Progress;
            public int              CurValue;
            public int              TargetValue;

            public List<IReward> IRewardList;
        }
        

        public QuestStruct QuestData { get; private set; }

        public void RenderReward()
        {
            foreach(IReward reward in QuestData.IRewardList)
            {
                reward.PrintReward();
            }
        }
        public void ApplyReward(IDummyPlayerInterface playerInterface)
        {
            for(int i = 0; i < QuestData.IRewardList.Count; i++)
            {
                QuestData.IRewardList[i].GiveReward(playerInterface);
            }
        }

        public bool GetIsGoal()
        {
            return QuestData.CurValue >= QuestData.TargetValue;
        }

        private void CreateQuestPreset(string presetName)
        {
            QuestStruct tempData = QuestData;
            List<Item> itemList = new List<Item>();

            switch (presetName)
            {
                case "마을을 위협하는 미니언 처치":
                    tempData.Title = new StringBuilder(presetName);
                    tempData.Story = new StringBuilder("이봐! 마을 근처에 미니언들이 너무 많아졌다고 생각하지 않나?\n마을주민들의 안전을 위해서라도 저것들 수를 좀 줄여야 한다고!\n모험가인 자네가 좀 처치해주게!");
                    tempData.Progress = new StringBuilder("- 미니언 5마리 처치");

                    tempData.CurValue = 5;
                    tempData.TargetValue = 5;

                    tempData.IRewardList = new List<IReward>();
                    itemList.Add(new Item("낡은 검"));

                    IReward? iReward = new RewardFactory().CreateReward(itemList);
                    if(null != iReward)
                        tempData.IRewardList.Add(iReward);

                    EventManager.instance?.Subscribe<MonsterKillEventArgs>((MonsterType) =>
                    {
                        if (MonsterEventType.END == MonsterType.MonsterType)
                        {
                            QuestStruct tempData = QuestData;
                            tempData.CurValue = Math.Min(tempData.TargetValue, tempData.CurValue + 1);
                            QuestData = tempData;
                        }
                    });
                    break;
                case "장비를 장착 해보기":
                    tempData.Title = new StringBuilder(presetName);
                    tempData.Story = new StringBuilder("검을 쥐는법을 아는가?");
                    tempData.Progress = new StringBuilder("- 장비 장착");

                    tempData.CurValue = 0;
                    tempData.TargetValue = 5;

                    tempData.IRewardList = new List<IReward>();
                    itemList.Add(new Item("청동 도끼"));
                    itemList.Add(new Item("청동 도끼"));

                    tempData.IRewardList.Add(new RewardItem(itemList));

                    EventManager.instance?.Subscribe<MonsterKillEventArgs>((MonsterType) =>
                    {
                        if (MonsterEventType.GOBLIN == MonsterType.MonsterType)
                        {
                            QuestStruct tempData = QuestData;
                            tempData.CurValue = Math.Min(tempData.TargetValue, tempData.CurValue + 1);
                            QuestData = tempData;
                        }
                    });
                    break;
            }

            QuestData = tempData;
        }
    }

    public interface IDummyPlayerInterface
    {
        void AddPlayerStat(int stat);

    }
}
