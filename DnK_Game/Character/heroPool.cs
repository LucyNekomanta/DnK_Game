using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnK_Game.Character
{
    class heroPool
    {
        //heroPool goes from 0 to 999
        private List<DnKCharacter> heroes = new List<DnKCharacter>();

        public void Add(DnKCharacter hero) => heroes.Add(hero);
        public void Remove(DnKCharacter hero) => heroes.Remove(hero);
        public System.Collections.ObjectModel.ReadOnlyCollection<DnKCharacter> List => heroes.AsReadOnly();
    }
    
}
