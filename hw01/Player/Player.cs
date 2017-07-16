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
    /// Class for handling player interaction with the game
    /// </summary>
    class Player
    {
        public string Name { get; protected set; }
        public int Keys { get; protected set; }
        public int Gold { get; protected set; }
        public bool PlayerWon { get; protected set; }

        /// <summary>
        /// Set Player with desired params
        /// </summary>
        /// <param name="name">Players name</param>
        /// <param name="keys">Number of keys</param>
        /// <param name="gold">Amount of Gold</param>
        public Player(string name, int keys, int gold)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Debug.WriteLine("[ERROR] Name of player cannot be empty.");
                name = "Player";
            }
            if (keys < 0)
            {
                Debug.WriteLine("[ERROR] You can't have negative number of keys.");
                keys = 0;
            }
            if (gold < 0)
            {
                Debug.WriteLine("[ERROR] You can't have negative amount of gold.");
                gold = 0;
            }
            Keys = keys;
            Gold = gold;
            Name = name;
        }
    }
}
