using DnK_Game.quests;
using DnK_Game.guild;
using System;
using System.IO;
using static System.Console;
using System.Runtime.Serialization.Json;
using System.Collections.Generic;

namespace DnK_Game
{
    [Serializable]
    public class GameControl
    {
        [NonSerialized] private static readonly string saveGameFileName = "Game1.save";

        private Guild guild;
        private QuestPool questBoard;
        private List<DnKCharacter> heroPool;
        private List<DnKCharacter> monsterPool;

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
                    heroPool = cp.heroPool;
                }
                catch (Exception e)
                {
                    WriteLine($"Could not read from file because: {e.Message}");
                }
                saveGame.Close();
            }

            SetupGuild();
            SetupQuests();
            SetupHeroes();
        }

        private void SetupGuild()
        {
            // **** Guild ****
            if (guild == null)
            {
                guild = new Guild("The Gamers");
                WriteLine($"Foundation of the Guild \"{guild.Name}\"");
            }
        }

        private void SetupQuests()
        {
            if (questBoard == null)
            {             // **** Quests ****
                          // Create a bunch of quests and store them in a QuestPool
                questBoard = new QuestPool();
                questBoard.Add(new Quest("Quest 1: Goblilns on the run!"));
                questBoard.Add(new Quest("Quest 2: How to get away with murder?"));

                foreach (var quest in questBoard.List)
                {
                    WriteLine($"{quest.Name}");
                }
            }
        }

        private void SetupHeroes()
        {
            if (heroPool == null)
            {
                heroPool = new List<DnKCharacter>
                {
                    new DnKCharacter() { Name = "Muro", ID = 0, HP = 10, atk = 10 },
                    new DnKCharacter() { Name = "Nekomanta", ID = 1, HP = 10, atk = 10 }
                };

                foreach (var hero in heroPool)
                {
                   WriteLine($"{hero.Name}");
                }
            }
        }
        private void SetupMonsters()
        {
            if (monsterPool == null)
            {
                monsterPool = new List<DnKCharacter>
                {
                    new DnKCharacter() { Name = "Slime", ID = 1000, HP = 10, atk = 10 },
                    new DnKCharacter() { Name = "Goblin", ID = 1001, HP = 10, atk = 10 }
                };

                foreach (var monster in monsterPool)
                {
                    WriteLine($"{monster.Name}");
                }
            }
        }
        public void Run()
        {
            AcceptQuest(0);
            RecruitHero(0);
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
            if ( questBoard.List.Count == 0)
            {
                WriteLine("There are no quests on this board.");
                return;
            }

            if (questBoard.List.Count <= questIdx)
            {
                WriteLine($"Can't accept Quest! Index out of bound! \nquestIdx={questIdx}\nquest.List.Count={questBoard.List.Count}");
                return;
            }

            var quest = questBoard.List[questIdx];
            questBoard.Remove(quest);
            guild.AddQuest(quest);
            WriteLine($"The Guild \"{guild.Name}\" has accepted the quest \"{quest.Name}\"");
        }

        private void RecruitHero(int heroIdx)
        {
            if (heroPool.Count == 0)
            {
                WriteLine("There are no heroes available.");
                return;
            }

            if (heroPool.Count <= heroIdx)
            {
                WriteLine($"Can't accept Quest! Index out of bound! \nquestIdx={heroIdx}\nquest.List.Count={heroPool.Count}");
                return;
            }

            var hero = heroPool[heroIdx];
            heroPool.Remove(hero);
            guild.AddHero(hero);
            WriteLine($"\"{hero.Name}\" has joined the guild \"{guild.Name}\"");
        }

        private void fight()
        {
            
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
