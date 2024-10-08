﻿using Roronoa_TXT_RPG;

namespace Roronoa_TXT_RPG
{
    internal class Program
    {
        public static Player player = new Player();
        public static Stage stage = new Stage();


        private static bool isRunGame = true;

        static void Main(string[] args)
        {
            Init();
       
            while (isRunGame)
            {
                Console.Clear();
                Update();
            }
        }

        static void Init()
        {
            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("원하시는 이름을 설정해주세요.");
            Console.Write($">>"); string name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"반갑습니다, {name}님!");

            Console.WriteLine("직업에 해당하는 숫자를 입력하세요.");
            Console.WriteLine("1.Warrior 2.Wizard 3.Assassin");
            
            KeyInputCheck(out int choice, 3, true);

            switch(choice)
            {
                case 1:
                    player = new Warrior(name);
                    break;
                case 2:
                    player = new Wizard(name);
                    break;
                case 3:
                    player = new Assassin(name);
                    break;

                default:
                    Console.WriteLine("잘못된 선택입니다.");
                    return;
            }
            
            SceneManager.InitSceneManager();
            EventManager.InitEventManager();
            ItemManager.InitItemManager();
            QuestManager.InitQuestManager();

        }
        static void Update()
        {
            SceneManager.instance?.SceneUpdate();
        }

        public static bool KeyInputCheck(out int selectNumber, int safeNumberRange)
        {
            string? input = Console.ReadLine();
            bool isNumber = int.TryParse(input, out int number);

            selectNumber = number;

            if (false == isNumber || safeNumberRange < selectNumber || selectNumber < 0)
            {
                Console.Write("잘못된 입력입니다.");
                Thread.Sleep(1000);
                return false;
            }
            return true;
        }

        public static bool KeyInputCheck(out int selectNumber, int safeNumberRange, bool keyCheckAgain)
        {
            string? input = Console.ReadLine();
            bool isNumber = int.TryParse(input, out int number);

            selectNumber = number;

            if (false == isNumber || safeNumberRange < selectNumber || selectNumber < 0)
            {
                Console.Write("잘못된 입력입니다.>>");
                Thread.Sleep(1000);
                if(true == keyCheckAgain)
                {
                    KeyInputCheck(out selectNumber, safeNumberRange, keyCheckAgain);
                }
                return false;
            }
            return true;
        }

        public static string PadRightForKorean(string input, int totalLength)
        {
            int length = 0;

            foreach (char c in input)
            {
                // 한글은 유니코드 범위상 2칸으로 계산
                if (char.GetUnicodeCategory(c) == System.Globalization.UnicodeCategory.OtherLetter)
                {
                    length += 2;  // 한글은 2칸으로 계산
                }
                else
                {
                    length += 1;  // 그 외 문자(영문, 숫자 등)는 1칸으로 계산
                }
            }

            // 목표 길이에서 현재 길이를 뺀 만큼 공백을 추가
            return input.PadRight(totalLength - (length - input.Length));
        }
        public static string PadLeftForKorean(string input, int totalLength)
        {
            int length = 0;

            foreach (char c in input)
            {
                // 한글은 유니코드 범위상 2칸으로 계산
                if (char.GetUnicodeCategory(c) == System.Globalization.UnicodeCategory.OtherLetter)
                {
                    length += 2;  // 한글은 2칸으로 계산
                }
                else
                {
                    length += 1;  // 그 외 문자(영문, 숫자 등)는 1칸으로 계산
                }
            }

            // 목표 길이에서 현재 길이를 뺀 만큼 공백을 추가
            return input.PadLeft(totalLength - (length - input.Length));
        }

        public static string CenterAlign(string input, int totalLength)//글자 중앙 정렬
        {
            int length = 0;
            foreach (char c in input)
            {
                // 한글은 유니코드 범위상 2칸으로 계산
                if (char.GetUnicodeCategory(c) == System.Globalization.UnicodeCategory.OtherLetter)
                {
                    length += 2;  // 한글은 2칸으로 계산
                }
                else
                {
                    length += 1;  // 그 외 문자(영문, 숫자 등)는 1칸으로 계산
                }
            }
            int padding = (totalLength - length) / 2;
            if (padding <= 0)
            {
                return input;
            }

            return input.PadLeft(input.Length + padding).PadRight(totalLength);
        }
    }

}
