using System;

namespace DnK_Game
{
    [Serializable]
    public class DnKCharacter
    {
        //prop tab tab
        public string Name { get; set; }
        public int ID { get; set; }
        public int lvl { get; set; }
        public int exp { get; set; }
        public int HP { get; set; }
        public int atk { get; set; }
        public int def { get; set; }
        public int vit { get; set; }
        public int dodge { get; set; }
        public int block { get; set; }
        public int speed { get; set; }
        public int critChance { get; set; }
        public int critDmg { get; set; }
        public Array trait { get; set; }
        public Array race { get; set; }
        public int luck { get; set; }
        public int bigDickEnergy { get; set; }
        public Array status { get; set; }
        //public int drunkness { get; set; }
    }
}