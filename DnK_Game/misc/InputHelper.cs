using System;


namespace DnK_Game.misc
{
    public static class InputHelper
    {
        public static char ReadChar()
        {
            ConsoleKeyInfo input = System.Console.ReadKey();
            return input.KeyChar;
        }

        public static int ReadDigit()
        {
            char inputChar = ReadChar();
            return int.Parse(inputChar.ToString());
        }
    }
}
