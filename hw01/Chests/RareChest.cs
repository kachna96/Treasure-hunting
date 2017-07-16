using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW01.Chests
{
    /// <summary>
    /// Rare chest
    /// </summary>
    class RareChest : UniversalChest
    {
        private const int ReqKeys = 3;
        private const int GoldReward = 170;

        /// <summary>
        /// Create new common chest with desired params
        /// </summary>
        public RareChest() : base(ReqKeys, GoldReward)
        {

        }

        /// <summary>
        /// Print info about this chest
        /// </summary>
        public override void PrintInfo()
        {
            Console.Write("Rare chest. You need {0} keys to open it.", KeysRequired);
        }
    }
}
