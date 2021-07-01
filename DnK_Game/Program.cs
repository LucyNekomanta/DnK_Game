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

            MenuNode mainMenu = new MenuNode("Main");
            mainMenu.AddAction("Start", null);
            mainMenu.AddAction("Exit", null);

            MenuNode settingsMenu = mainMenu.AddSubNode("Settings");
            settingsMenu.AddSubNode("Audio");
            settingsMenu.AddSubNode("Graphics");

            mainMenu.Show();

            gc.Teardown();
        }
    }
}
