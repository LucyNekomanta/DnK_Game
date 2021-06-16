using System;
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
    }
}
