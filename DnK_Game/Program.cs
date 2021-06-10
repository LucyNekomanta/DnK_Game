using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnK_Game.quests;
using DnK_Game.guild;

namespace DnK_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting dnk_game");

            var qp = new QuestPool();
            qp.add(new Quest());
          
            var g = new Guild();

            Console.ReadKey(true);
        }
    }
}
