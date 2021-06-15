using System;

namespace DnK_Game
{
    [Serializable]
    public class DnKCharacter
    {
        //prop tab tab
        public string Name { get; set; }
        public int ID { get; set; }
        public int HP { get; set; }
        public int atk { get; set; }
        public int def { get; set; }
        public int speed { get; set; }
        public Array trait { get; set; }
        public Array race { get; set; }

    }
}