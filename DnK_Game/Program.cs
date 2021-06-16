using static System.Console;
using DnK_Game.menu;
using System.Collections.Generic;

namespace DnK_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Starting dnk_game");

            GameControl gc = new GameControl();
            gc.Init();

            Menu m = new Menu()
            {
                Nodes = new List<MenuNode> {
                             new MenuNode("Main")
                             {
                                 SubNodes = new List<MenuNode> {
                                     new MenuNode("Settings")
                                 },
                                 EndNodes = new List<MenuAction>
                                 {
                                     new MenuAction("Start", gc.Run),
                                     new MenuAction("Exit", null)
                                 }
                             }
                         }
            };

            m.show();

            gc.Teardown();
        }
    }
}
