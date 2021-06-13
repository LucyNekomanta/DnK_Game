using System;


namespace DnK_Game.quests
{
    [Serializable]
    public class Quest
    {
        public Quest(string name) => Name = name;

        public string Name { get; }
    }
}
