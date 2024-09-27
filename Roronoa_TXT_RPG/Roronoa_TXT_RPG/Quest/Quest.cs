using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Roronoa_TXT_RPG.Quest;

namespace Roronoa_TXT_RPG
{
    // 퀘스트 클래스 필요한 기능
    // 1. 퀘스트 제목
    // 2. 퀘스트 스토리
    // 3. 퀘스트 달성 내용 - 비쥬얼적으로 달성 척도가 보여야 함
    // 4. 보상 정보 - 아이템도 주고, 돈도 주고, 여차하면 스텟을 줄 경우도 있음 확장성 생각. - 딕셔너리.
    //    -> 퀘스트매니저가 해당 리워드 플레이어 인터페이스 호출해서 넘겨주는걸로 해결. 딕셔너리 구조 생각해봐야함
    // 5. 수락 상태 체크

    // 딕셔너리 구조
    // - 그냥 단순하게 보상 데이터 쌓아 넣기? 근데 자료구조가 다르잖아 플레이어쪽에서 리워드 하나씩 타입 밝혀가면서 받는건 좀 그런데? c#의 딕셔너리 키, 값 해시 특성가짐 list = 벡터 특성
    // 정보를 단순 string으로 관리? 타입 키로 관리하기?
    // 플레이어쪽에서 생각해보면 아이템 들어오면 아이템에 넣는다는 구문 필요, 스텟이면 무슨 스텟인지 검사하고 맞는 스텟에 값 더한다는 구문 필요..
    // Quest에서 리워드 클래스 가지고 있기 굳이 클래스로? 걍 함수 포인터 넣자 어때?, 어플라이 리워드 함수 호출 - 플레이어 넣어주기? 이렇게 가자 ㅇㅇ
    // 리워드클래스 사용하면 명확하긴 한데 보상 종류에 따라 클래스 수가 너무 늘어남...



    internal class Quest
    {
        public Quest(List<Reward> InputRewardList)
        {
            questData.RewardList = InputRewardList;
        }

        public struct QuestData
        {
            public StringBuilder    Title;
            public StringBuilder    Story;
            public int              CurValue;
            public int              TargetValue;
            public bool             isGoal;

            public List<Reward> RewardList;
        }
        public QuestData questData;


        public void QuestUpdate()
        {
            if(questData.CurValue >= questData.TargetValue)
            {
                questData.isGoal = true;

            }

        }
    }

    public class Reward : IReward
    {
        public enum RewardType
        {
            STAT, ITEM, END
        }
        private RewardType rewardType;


        public void GiveReward(IDummyPlayerInterface playerInterface)
        {
            // 스위치문 돌려서 내 리워드 타입 검사
            // 조건에 맞는 플레이어 함수 호출

            // 플레이어는 퀘스트 완료되는 이벤트에 구독 - EventArg 클래스 하나 선언해야함 
            // Event 내부에서 생성될때 

            //리워드 생성시 아이템을 미리 들고 있게 가능 그러고나서 부모로 업캐스팅, 해당 업캐스팅으로 이벤트 발행 플레이어쪽에서는 그냥 업캐스팅의 가상함수만 호출해주면 됨, 혹은 인터페이스 함수.
        }
    }

    public interface IReward
    {
        void GiveReward(IDummyPlayerInterface playerInterface);
    }
    public interface IDummyPlayerInterface
    {
        void AddPlayerStat(int stat);

    }
}
