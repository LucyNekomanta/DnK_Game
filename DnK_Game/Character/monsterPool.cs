using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnK_Game.Character
{
    class monsterPool
    {
        //monsterPool goes from 1000 to 1999
        private List<DnKCharacter> monsters = new List<DnKCharacter>();

        public void Add(DnKCharacter monster) => monsters.Add(monster);
        public void Remove(DnKCharacter monster) => monsters.Remove(monster);

        public System.Collections.ObjectModel.ReadOnlyCollection<DnKCharacter> List => monsters.AsReadOnly();
    }

}
