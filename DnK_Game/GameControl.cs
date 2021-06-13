using DnK_Game.quests;
using DnK_Game.guild;
using static System.Console;

namespace DnK_Game
{
    public class GameControl
    {
        private Guild guild;
        private QuestPool questBoard;

        public GameControl()
        {
            // **** Quests ****
            // Create a bunch of quests and store them in a QuestPool
            questBoard = new QuestPool();
            questBoard.Add(new Quest("Quest 1: Goblilns on the run!"));
            questBoard.Add(new Quest("Quest 2: How to get away with murder?"));

            foreach (var quest in questBoard.List)
            {
                WriteLine($"{quest.Name}");
            }

            // **** Guild ****
            guild = new Guild("The Gamers");
            WriteLine($"Foundation of the Guild \"{guild.Name}\"");
        }

        public void AcceptQuest(int questIdx)
        {
            if (questBoard.List.Count < questIdx)
            {
                WriteLine($"Can't accept Quest!\nquestIdx={questIdx}\nquest.List.Count={questBoard.List.Count}");
                return;
            }

            var quest = questBoard.List[questIdx];
            questBoard.Remove(quest);
            guild.AddQuest(quest);
            WriteLine($"The Guild \"{guild.Name}\" has accepted the quest \"{quest.Name}\"");
        }
    }
}
