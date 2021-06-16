using static System.Console;
using System.Collections.Generic;

namespace DnK_Game.menu
{
    public class Menu
    {
        public List<MenuNode> Nodes;

        public void show()
        {
            foreach (MenuNode node in Nodes)
            {
                WriteLine($"{Nodes.IndexOf(node)}: {node.Label}");
            }
        }
    }
}
