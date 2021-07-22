using static System.Console;
using DnK_Game.menu;
using DnK_Game.misc;

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
            mainMenu.AddAction("New Game", gc.NewGame);
            mainMenu.AddAction("Start", gc.Run);
            mainMenu.AddAction("Exit", null);

            MenuNode settingsMenu = mainMenu.AddSubNode("Settings");
            settingsMenu.AddSubNode("Audio");
            settingsMenu.AddSubNode("Graphics");

            do
            {
                mainMenu.Show();
            } while (mainMenu.Select(InputHelper.ReadDigit()));

            gc.Teardown();
        }
    }
}
