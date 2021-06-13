using static System.Console;

namespace DnK_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Starting dnk_game");

            GameControl gc = new GameControl() ;

            gc.Init();

            gc.Run();

            gc.Teardown();
        }
    }
}
