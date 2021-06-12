using DnK_Game.quests;
using DnK_Game.guild;
using static System.Console;

namespace DnK_Game
{
    class Program
    {
        static public void AcceptQuest(Guild guild, QuestPool quests, int questIdx)
        {
            if (quests.List.Count < questIdx)
            {
                WriteLine($"Can't accept Quest!\nquestIdx={questIdx}\nquest.List.Count={quests.List.Count}");
                return;
            }

            var quest = quests.List[questIdx];
            quests.Remove(quest);
            guild.AddQuest(quest);
            WriteLine($"The Guild \"{guild.Name}\" has accepted the quest \"{quest.Name}\"");
        }

        static void Main(string[] args)
        {
            WriteLine("Starting dnk_game");

            // **** Quests ****
            // Create a bunch of quests and store them in a QuestPool
            var questBoard = new QuestPool();
            questBoard.Add(new Quest("Quest 1: Goblilns on the run!"));
            questBoard.Add(new Quest("Quest 2: How to get away with murder?"));
            // Create a quest dummy to test the Remove method of the QuestPool
            questBoard.Add(new Quest("Quest 3: This will be removed"));
            questBoard.Remove(questBoard.List[2]);

            // only Quest 1 and 2 should remain in the QuestPool
            foreach (var quest in questBoard.List)
            {
                WriteLine($"{quest.Name}");
            }

            // **** Guild ****
            var guild = new Guild("The Gamers");
            WriteLine($"Foundation of the Guild \"{guild.Name}\"");

            // **** Accepting a Quest ****
            AcceptQuest(guild, questBoard, 0);

            ReadKey(true);
        }
    }
}
