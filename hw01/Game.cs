using HW01.Chests;
using PV178.Homeworks.HW01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW01
{
    /// <summary>
    /// Main class implementing IGame interface and handling user commands
    /// </summary>
    class Game : IGame
    {
        private const int DefaultNumberOfKeys = 5;
        private const int DefaultAmountOfGold = 200;
        private const int SearchForChestCost = 60;
        private const int BuyNewKeysCost = 50;
        private const int NumberOfKeysToBuy = 5;
        private const int GoldNeededToWin = 1000;

        public PlayerActions Player { get; private set; }
        public UniversalChest Chest { get; private set; }

        public void Start()
        {
            string name = string.Empty;
            Console.WriteLine("Welcome to FI Treasure Hunting! Write your name, please:");
            while (string.IsNullOrWhiteSpace(name))
            {
                name = Console.ReadLine();
            }
            Player = new PlayerActions(name, DefaultNumberOfKeys, DefaultAmountOfGold);
            Console.WriteLine("You can use this commands: find, open, buy, info, win, surrend");
            Console.WriteLine("Keys: {0}, Gold: {1}", DefaultNumberOfKeys, DefaultAmountOfGold);
            Play();
        }

        /// <summary>
        /// Catch player commands until player wins or surrenders
        /// </summary>
        private void Play()
        {
            string command;
            Console.Write("[" + Player.Name + "]: ");
            while (!Player.PlayerWon && (command = Console.ReadLine()) != "surrend")
            {
                ParseKeyword(command.ToLower());
                Console.Write("\n[" + Player.Name + "]: ");
                if (Player.IsPlayerDead(Chest, SearchForChestCost, BuyNewKeysCost))
                {
                    Console.WriteLine("You lost!");
                    break;
                }
            }
        }

        /// <summary>
        /// Execute a command written by a player
        /// </summary>
        /// <param name="command">command</param>
        private void ParseKeyword(string command)
        {
            switch (command)
            {
                case "find":
                    if (!Player.CanFindNewChest(SearchForChestCost))
                    {
                        Console.Write("You don't have enough gold, just concede!");
                    }
                    else
                    {
                        Chest = Player.FindNewChest(SearchForChestCost);
                        Chest.PrintInfo();
                    }
                    break;
                case "open":
                    if (Chest == null)
                    {
                        Console.Write("You don't have any chest left to open, try 'find'.");
                    }
                    else if (!Player.CanOpenChest(Chest.KeysRequired))
                    {
                        Console.Write("You don't have enough keys, just concede!");
                    }
                    else
                    {
                        Player.OpenChest(Chest.KeysRequired, Chest.Gold);
                        Console.Write("You have gained {0} gold.\n", Chest.Gold);
                        Chest = null;
                        PrintPlayerInfo();
                    }
                    break;
                case "buy":
                    if (!Player.CanBuyKeys(BuyNewKeysCost))
                    {
                        Console.Write("Not enough gold.");
                    }
                    else
                    {
                        Player.BuyKeys(NumberOfKeysToBuy, BuyNewKeysCost);
                        PrintPlayerInfo();
                    }
                    break;
                case "info":
                    PrintPlayerInfo();
                    break;
                case "win":
                    if (Player.TryToWin(GoldNeededToWin))
                    {
                        Console.Write("You won!");
                    }
                    else
                    {
                        Console.Write("Not enough gold.");
                    }
                    break;
                default:
                    Console.Write("Invalid command.");
                    break;
            }
        }

        /// <summary>
        /// Print number of keys and amount of gold for current player
        /// </summary>
        private void PrintPlayerInfo()
        {
            Console.Write("Keys: " + Player.Keys + ", Gold: " + Player.Gold);
        }
    }
}
