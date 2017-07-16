using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW01.Chests
{
    /// <summary>
    /// Legendary chest
    /// </summary>
    class LegendaryChest : UniversalChest
    {
        private const int ReqKeysMin = 1;
        private const int ReqKeysMax = 5;
        private const int GoldRewardMin = 300;
        private const int GoldRewardMax = 450;

        /// <summary>
        /// Create new legendary chest with desired params
        /// </summary>
        public LegendaryChest() : base(new Random().Next(ReqKeysMin, ReqKeysMax + 1), new Random().Next(GoldRewardMin, GoldRewardMax + 1))
        {

        }

        /// <summary>
        /// Print info about this chest
        /// </summary>
        public override void PrintInfo()
        {
            Console.Write("Legendary chest. You need {0} {1} to open it.", KeysRequired, KeysRequired == 1 ? "key" : "keys");
        }
    }
}
