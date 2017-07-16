using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW01.Chests
{
    /// <summary>
    /// Universal chest
    /// </summary>
    class UniversalChest
    {
        public int KeysRequired { get; private set; }
        public int Gold { get; private set; }

        /// <summary>
        /// Create new universal chest
        /// </summary>
        public UniversalChest()
        {

        }

        /// <summary>
        /// Create new universal chest with desired params
        /// </summary>
        /// <param name="numberOfKeys">Number of keys needed to open the chest</param>
        /// <param name="gold">Amount of gold hidden inside</param>
        public UniversalChest(int numberOfKeys, int gold)
        {
            if (numberOfKeys < 0)
            {
                Debug.WriteLine("[ERROR] Number of keys needed to open the chest cannot be below zero.");
                numberOfKeys = int.MaxValue;
            }
            if (gold < 0)
            {
                Debug.WriteLine("[ERROR] Amount of gold stored inside the chest cannot be lower than zero.");
                gold = 0;
            }
            KeysRequired = numberOfKeys;
            Gold = gold;
        }

        /// <summary>
        /// Print info about this chest
        /// </summary>
        public virtual void PrintInfo()
        {
            Console.Write("Universal chest, you need {0} {1} to open it.", KeysRequired, KeysRequired == 1 ? "key" : "keys");
        }
    }
}
