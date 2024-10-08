﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roronoa_TXT_RPG
{
    public interface IReward
    {
        void GiveReward();
        void PrintReward();
    }

    internal class RewardItem : IReward
    {
        public RewardItem(List<Item> inputItemList)
        {
            for(int i = 0; i < inputItemList.Count; i++)
            {
                string itemName = inputItemList[i].ItemData.Name.ToString();
                if(false == rewardItem.ContainsKey(itemName))
                {
                    rewardItem[itemName] = new List<Item> { inputItemList[i] };
                }
                else
                    rewardItem[itemName].Add(inputItemList[i]);
            }
        }
        Dictionary<string, List<Item>> rewardItem = new Dictionary<string, List<Item>>();

        public void GiveReward()
        {
            foreach (KeyValuePair<string, List<Item>> keyValuePair in rewardItem)
            {
                foreach(Item item in keyValuePair.Value)
                {
                    Program.player.GetItem(item);
                }
            }
        }
        public void PrintReward()
        {
            foreach (KeyValuePair<string, List<Item>> keyValuePair in rewardItem)
            {
                Console.WriteLine(keyValuePair.Key + " x " +keyValuePair.Value.Count);
            }
        }
    }

    public class RewardStat : IReward
    {
        public RewardStat(/*플레이어 구조체 받기*/)
        {
            //플레이어 구조체로 멤버변수 구조체 초기화
        }

        // 멤버변수 플레이어 스텟 정보 구조체 변수 선언.
        public void GiveReward()
        {
            // 플레이어 스텟 증가 코드
        }

        public void PrintReward()
        {

        }
    }
}
