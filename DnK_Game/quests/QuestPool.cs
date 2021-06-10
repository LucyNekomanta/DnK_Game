using System;
using System.Collections.Generic;

namespace DnK_Game.quests
{
    public class QuestPool
    {
        private List<Quest> quests = new List<Quest>();

        public QuestPool()
        {
            Console.WriteLine("Create QuestPool");
        }

        public void add(Quest quest)
        {
            Console.WriteLine("QuestPool append Quest");
            quests.Add(quest);
        }
    }
}
