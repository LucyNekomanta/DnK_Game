using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnK_Game
{
    public class DnKCharacters
    {
        public string heroName { get; set; }
        public int heroID { get; set; }
        public void Hero(string name, int id)
        {
            heroName = name;
            heroID = id;

        }
        public string monsterName { get; set; }
        public int monsterID { get; set; }
        public void Monster(string name, int id)
        {
            monsterName = name;
            monsterID = id;

        }
    }
}
