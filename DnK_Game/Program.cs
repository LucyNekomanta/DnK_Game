using DnK_Game.quests;
using DnK_Game.guild;
using static System.Console;

namespace DnK_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Starting dnk_game");


            var questBoard = new QuestPool();
            questBoard.Add(new Quest("Quest 1: Goblilns on the run!"));
            questBoard.Add(new Quest("Quest 2: How to get away with murder?"));

            foreach (var quest in questBoard.List)
            {
                WriteLine($"{quest.Name}");
            }

            var guild = new Guild("The Gamers");
            WriteLine($"Foundation of the Guild \"{guild.Name}\"");

            ReadKey(true);
        }
    }
}
