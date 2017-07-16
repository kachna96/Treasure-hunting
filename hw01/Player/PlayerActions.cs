using HW01.Chests;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW01
{
    /// <summary>
    /// Class for managing player interactions with the game
    /// </summary>
    class PlayerActions : Player
    {
        /// <summary>
        /// Call predecessor with these params
        /// </summary>
        /// <param name="name">Players name</param>
        /// <param name="keys">Number of keys</param>
        /// <param name="gold">Amount of Gold</param>
        public PlayerActions(string name, int keys, int gold) : base(name, keys, gold)
        {
        }

        /// <summary>
        /// Determine if player can afford to find a new chest
        /// </summary>
        /// <param name="gold">Cost of finding a new chest</param>
        /// <returns>True if player can afford it, false otherwise</returns>
        public bool CanFindNewChest(int gold)
        {
            return Gold >= gold;
        }

        /// <summary>
        /// Determine if player has enough keys to open the chest
        /// </summary>
        /// <param name="keys">Number of keys needed to open the chest</param>
        /// <returns>True if player can do it, false otherwise</returns>
        public bool CanOpenChest(int keys)
        {
            return Keys >= keys;
        }

        /// <summary>
        /// Determine of player has enough gold to buy more keys
        /// </summary>
        /// <param name="cost">Cost of buying more keys</param>
        /// <returns>True if player can afford it, false otherwise</returns>
        public bool CanBuyKeys(int cost)
        {
            return Gold >= cost;
        }

        /// <summary>
        /// Open a chest, adjust player stats
        /// </summary>
        /// <param name="keysRequired">Keys required to open this chest</param>
        /// <param name="gold">Amount of gold hidden inside this chest</param>
        public void OpenChest(int keysRequired, int gold)
        {
            Keys -= keysRequired;
            Gold += gold;
        }

        /// <summary>
        /// Buy keys needed for opening chests
        /// </summary>
        /// <param name="keys">Desired number of keys (5 in current solution)</param>
        /// <param name="gold">Cost of the operation in gold (50 in current solution)</param>
        public void BuyKeys(int keys, int gold)
        {
            if (keys < 0)
            {
                Debug.WriteLine("[ERROR] You can't buy negative number of keys.");
                keys = 0;
            }
            if (gold < 0)
            {
                Debug.WriteLine("[ERROR] You sadly can't pay for keys with negative amount of gold.");
                gold = 0;
            }
            Keys += keys;
            Gold -= gold;
        }

        /// <summary>
        /// Method for winning the game if player has more gold than minimum (1000 in current solution)
        /// </summary>
        /// <param name="minimum">Minimum of gold needed for successfuly winning the game</param>
        /// <returns>true if player has enough gold to win, false otherwise</returns>
        public bool TryToWin(int minimum)
        {
            if (Gold >= minimum)
            {
                PlayerWon = true;
            }
            return PlayerWon;
        }

        /// <summary>
        /// Checks if player can no longer win
        /// </summary>
        /// <param name="currentChest">Current chest</param>
        /// <param name="chestCost">Cost of opening chest</param>
        /// <param name="keysCost">Cost of buying keys</param>
        /// <returns>True if player can no longer win/false otherwise</returns>
        public bool IsPlayerDead(UniversalChest currentChest, int chestCost, int keysCost)
        {
            if (currentChest == null && chestCost > Gold)
            {
                return true;
            }
            if (currentChest != null && currentChest.KeysRequired > Keys && keysCost > Gold)
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// Find new Chest an adjust players amount of gold
        /// </summary>
        /// <param name="searchForChestCost">Cost of the operation in gold</param>
        /// <returns>Return new Common/Rare/Legendary chest with probability 6:3:1</returns>
        public UniversalChest FindNewChest(int searchForChestCost)
        {
            Gold -= searchForChestCost;
            int i = new Random().Next(0, 10);
            if (i <= 5)
            {
                return new CommonChest();
            }
            else if (i <= 8)
            {
                return new RareChest();
            }
            else
            {
                return new LegendaryChest();
            }
        }
    }
}
