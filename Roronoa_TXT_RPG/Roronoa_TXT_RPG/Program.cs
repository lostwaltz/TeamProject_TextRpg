﻿using Roronoa_TXT_RPG;

namespace Roronoa_TXT_RPG
{
    internal class Program
    {
        public static Player player = new Player();

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
            SceneManager.InitSceneManager();
            EventManager.InitEventManager();
            QuestManager.InitQuestManager();
            player = new Wizard();

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
                Thread.Sleep(1500);
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
                Console.Write("잘못된 입력입니다.");
                Thread.Sleep(1500);
                if(true == keyCheckAgain)
                {
                    KeyInputCheck(out selectNumber, safeNumberRange, keyCheckAgain);
                }
                return false;
            }
            return true;
        }
    }
}
