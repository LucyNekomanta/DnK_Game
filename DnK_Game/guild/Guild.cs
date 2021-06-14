using DnK_Game.quests;
using System;
using System.Collections.Generic;

namespace DnK_Game.guild
{
    [Serializable]
    public class Guild
    {
        public Guild(string name) => Name = name;

        public string Name { get; }

        // **** Quests ****
        private QuestPool acceptedQuests = new QuestPool();
        public void AddQuest(Quest quest) => acceptedQuests.Add(quest);
        public System.Collections.ObjectModel.ReadOnlyCollection<Quest> QuestList => acceptedQuests.List;

        // **** Heroes ****
        [NonSerialized] private List<DnKCharacters> heroes = new List<DnKCharacters>();
        public void AddHero(DnKCharacters hero)
        {
            if (heroes == null)
            {
                heroes = new List<DnKCharacters>() { hero };
            }
            else
            {
                heroes.Add(hero);
            }
        }
    }
}
