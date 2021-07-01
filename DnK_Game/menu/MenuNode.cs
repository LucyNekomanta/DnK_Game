using static System.Console;
using System.Collections.Generic;

namespace DnK_Game.menu
{
    public class MenuNode
    {
        private readonly MenuNode Parent;
        public List<MenuNode> SubNodes;
        public List<MenuAction> EndNodes;
        public string Label { get; }
        public MenuNode(string label)
        {
            Label = label;
        }

        public void show()
        {
            if ( SubNodes != null )
            foreach (MenuNode node in SubNodes)
            {
                WriteLine($"{SubNodes.IndexOf(node)}: {node.Label}");
                node.show();
            }
        }
    }
}
