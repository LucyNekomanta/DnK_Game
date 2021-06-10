using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnK_Game.quests;

namespace DnK_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting dnk_game");

            var q = new Quest();
            var qp = new QuestPool();

            Console.ReadKey(true);
        }
    }
}
