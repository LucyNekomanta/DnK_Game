using DnK_Game.quests;
namespace DnK_Game.guild
{
    public class Guild
    {
        public Guild(string name) => Name = name;

        public string Name { get; }

        // **** Quests ****
        public void AddQuest(Quest quest) => acceptedQuests.Add(quest);
        public System.Collections.ObjectModel.ReadOnlyCollection<Quest> QuestList => acceptedQuests.List;
        private QuestPool acceptedQuests = new QuestPool();
    }
}
