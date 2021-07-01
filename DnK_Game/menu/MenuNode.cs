using System;
using static System.Console;
using System.Collections.Generic;

namespace DnK_Game.menu
{
    public class MenuNode
    {
        private readonly MenuNode Parent = null;
        public List<MenuNode> SubNodes = new List<MenuNode>();
        public List<MenuAction> EndNodes = new List<MenuAction>();
        public string Label { get; }

        public MenuNode(string label)
        {
            Label = label;
        }

        public MenuNode(string label, MenuNode parent)
        {
            Label = label;
            Parent = parent;
        }

        public MenuNode AddSubNode(string label)
        {
            MenuNode subNode = new MenuNode(label, this);
            SubNodes.Add(subNode);
            return subNode;
        }

        public void AddAction(string label, Action fn)
        {
            MenuAction action = new MenuAction(label, fn);
            EndNodes.Add(action);
        }

        public void Show()
        {
            WriteLine($"# {Label}");

            int menuIdx = 1;

            foreach (MenuAction action in EndNodes)
            {
                WriteLine($"{menuIdx++}: {action.Label}");
            }

            foreach (MenuNode node in SubNodes)
            {
                WriteLine($"{menuIdx}: > {node.Label}");
            }

            if (Parent != null)
            {
                WriteLine($"0: Back <");
            }
        }
    }
}
