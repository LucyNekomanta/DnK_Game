using DnK_Game.quests;
using DnK_Game.guild;
using System;
using System.IO;
using static System.Console;
using System.Runtime.Serialization.Json;


namespace DnK_Game
{
    [Serializable]
    public class GameControl
    {
        [NonSerialized] private static readonly string saveGameFileName = "Game1.save";
        [NonSerialized] private Guild guild;
        [NonSerialized] private QuestPool questBoard;

        public void Init()
        {
            GameControl cp = null;

            // Try to load from a save game file if one exists.
            if (File.Exists(saveGameFileName))
            {
                FileStream saveGame = new FileStream(saveGameFileName, FileMode.Open);

                try
                {
                    cp = DeSerialize(saveGame);
                    guild = cp.guild;
                    questBoard = cp.questBoard;
                }
                catch (Exception e)
                {
                    WriteLine($"Could not read from file because: {e.Message}");
                }
                saveGame.Close();
            }

            SetupGuild();
            SetupQuests();
        }

        private void SetupGuild()
        {
            // **** Guild ****
            guild = new Guild("The Gamers");
            WriteLine($"Foundation of the Guild \"{guild.Name}\"");
        }

        private void SetupQuests()
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
        }

        public void Run()
        {
            AcceptQuest(0);
        }

        public void Teardown()
        {
            // Try to save the game state in a file as JSON.
            FileStream saveGame = new FileStream(saveGameFileName, FileMode.Create);
            try
            {
                Serialize(this, saveGame);
            }
            catch (Exception e)
            {
                WriteLine($"Could not write to file because: {e.Message}");
            }
            saveGame.Close();
        }

        private void AcceptQuest(int questIdx)
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

        public static void Serialize(GameControl obj, Stream stream)
        {
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(GameControl));
            js.WriteObject(stream, obj);
        }

        public static GameControl DeSerialize(Stream stream)
        {
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(GameControl));
            return (GameControl)js.ReadObject(stream);
        }
    }
}
