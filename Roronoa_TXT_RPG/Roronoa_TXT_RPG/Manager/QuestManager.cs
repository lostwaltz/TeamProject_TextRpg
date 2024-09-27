using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roronoa_TXT_RPG
{
    internal class QuestManager
    {
        public static QuestManager? instance { get; private set; }

        public static void InitQuestManager()
        {
            if (instance == null)
            {
                instance = new QuestManager();
            }
        }
    }
}
