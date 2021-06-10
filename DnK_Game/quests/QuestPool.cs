using System.Collections.Generic;

namespace DnK_Game.quests
{
    public class QuestPool
    {
        private List<Quest> quests = new List<Quest>();

        public void Add(Quest quest) => quests.Add(quest);

        public System.Collections.ObjectModel.ReadOnlyCollection<Quest> List => quests.AsReadOnly();
    }
}
