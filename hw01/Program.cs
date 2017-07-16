using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PV178.Homeworks.HW01;

namespace HW01
{
    /// <summary>
    /// Program for a small CLI minigame
    /// </summary>
    class TreasureHunting
    {
        /// <summary>
        /// Start a new game
        /// </summary>
        /// <param name="args">args</param>
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
        }
    }
}
