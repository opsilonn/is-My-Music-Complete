using System;


namespace IsMyMusicComplete
{
    /** This Class serves to ask the user to make his choice amongs a list of proposals.
    */
    public static class Choice
    {
        public static int GetChoice(string message, string[] choices)
        {
            // We initialize our variables
            ConsoleKeyInfo input;
            int MIN = 0;
            int MAX = choices.Length - 1;
            int value = 0;


            // While the user doesn't press Enter, the loop continues
            do
            {
                // We ask the user a question
                Console.Clear();
                Console.WriteLine(message);

                // We display all our choices (and we highlight the current choice with an arrow)
                for (int index = 0; index <= MAX; index++)
                {
                    if (index == value)
                        Console.Write("     --> ");
                    else
                        Console.Write("         ");

                    Console.WriteLine(choices[index]);
                }


                // We read the input
                input = Console.ReadKey();


                // If it is a key (UP or DOWN), we modify our choice accordingly
                if (input.Key == ConsoleKey.UpArrow)
                    value--;
                if (input.Key == ConsoleKey.DownArrow)
                    value++;


                // If the value goes too low / too high, it goes to the other extreme
                if (value < MIN)
                    value = MAX;
                if (value > MAX)
                    value = MIN;
            }
            // We continue while the user does not press ENTER
            while (input.Key != ConsoleKey.Enter);


            // We return the value
            return value;
        }
    }
}
