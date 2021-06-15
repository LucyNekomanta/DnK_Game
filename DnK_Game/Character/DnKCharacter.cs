using System;

namespace DnK_Game
{
    [Serializable]
    public class DnKCharacter
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public double HP { get; set; }
        public double Atk { get; set; }

    }
}