using Roronoa_TXT_RPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roronoa_TXT_RPG.GameObject
{
    internal class RewardFactory
    {
        public IReward? CreateReward(object typeObject)
        {
            if(typeObject is Item)
            {
                return new RewardItem(new List<Item>() {(Item)typeObject} );
            }
            else if(typeObject is List<Item>)
            {
                return new RewardItem((List<Item>)typeObject);
            }

            return null;
        }
    }
}