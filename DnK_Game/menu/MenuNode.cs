using System;
using static System.Console;
using System.Collections.Generic;

namespace DnK_Game.menu
{
    public class MenuNode
    {
        private readonly string Label;
        private readonly MenuNode Parent = null;
        private MenuNode current = null;
        private List<MenuNode> SubNodes = new List<MenuNode>();
        private List<MenuAction> EndNodes = new List<MenuAction>();
        public int EntryCount => SubNodes.Count + EndNodes.Count;

        public MenuNode(string label)
        {
            Label = label;
            current = this;
        }

        public MenuNode(string label, MenuNode parent)
        {
            Label = label;
            Parent = parent;
            current = this;
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
            WriteLine($"# {current.Label}");

            int menuIdx = 1;

            foreach (MenuAction action in current.EndNodes)
            {
                WriteLine($"{menuIdx++}: {action.Label}");
            }

            foreach (MenuNode node in current.SubNodes)
            {
                WriteLine($"{menuIdx++}: > {node.Label}");
            }

            if (current.Parent != null)
            {
                WriteLine($"0: Back <");
            }
        }

        public bool Select(int selection)
        {
            if ( selection < 0)
            {
                throw new ArgumentOutOfRangeException("selection",
                    "The selected menu item index must not be negative");
            }

            if ( selection > current.EntryCount)
            {
                throw new ArgumentOutOfRangeException("selection",
                                    "The selected menu item index exceeds the number of entries");
            }

            if ( selection == 0 && current.Parent == null)
            {
                throw new ArgumentOutOfRangeException("selection",
                        "This is node does not have a parent node");
            }

            if ( selection == 0 ) { 
                current = current.Parent;
            } else if ( selection <= current.EndNodes.Count)
            {
                current.EndNodes[selection - 1].Function?.Invoke();
                return false;
            }
            else
            {
                current = current.SubNodes[selection - 1 - current.EndNodes.Count];
            }

            return true;
        }
    }
}
