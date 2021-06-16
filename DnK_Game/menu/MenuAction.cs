using System;
namespace DnK_Game.menu
{
    public class MenuAction
    {
        public string Label { get; }
        public Action Function { get; }

        public MenuAction(string label, Action fn)
        { 
            Label = label; 
            Function = fn; 
        }
    }
}
