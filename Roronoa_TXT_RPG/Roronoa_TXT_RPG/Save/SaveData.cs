using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roronoa_TXT_RPG.Save
{
    public abstract class SaveData
    {

        public abstract SaveData Save();
    }

    public class PlayerSaveData : SaveData
    {

        public override SaveData Save()
        {
            SaveData test = new PlayerSaveData;

            return test;
        }
    }



}
