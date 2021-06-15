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
        private List<DnKCharacter> heroes = new List<DnKCharacter>();
        public void AddHero(DnKCharacter hero)
        {
            if (heroes == null)
            {
                heroes = new List<DnKCharacter>() { hero };
            }
            else
            {
                heroes.Add(hero);
            }
        }
    }
}
