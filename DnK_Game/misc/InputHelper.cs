using System;


namespace DnK_Game.misc
{
    public static class InputHelper
    {
        public static char ReadChar()
        {
            ConsoleKeyInfo input = System.Console.ReadKey(true);
            return input.KeyChar;
        }

        public static int ReadDigit()
        {
            int outDigit = 0;
            char inputChar = '\0';

            do
            {   
                inputChar = ReadChar();
            } while (!int.TryParse(inputChar.ToString(), out outDigit));

            return outDigit;
        }
    }
}
