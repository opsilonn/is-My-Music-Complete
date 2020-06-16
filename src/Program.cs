using System;
using System.IO;

namespace IsMyMusicComplete
{
    class Program
    {
        /** This Class serves as the "launcher" of the application, since it contains the Main function
        */
        static void Main(string[] args)
        {
            // First, we check that the path given by the user exists
            if (!Directory.Exists(Util.PATH_READ_MUSIC))
            {
                // If not, display an error...
                Util.PrintColored(ConsoleColor.Red, "\n\n\n It seems like the path where your music is stored is incorrect");

                // ...and end the program here
                return;
            }


            // If the path is valid, we ask the user what he wants to do

            // 1 - The message to display when launching the program
            string message = "Please choose an action : ";

            // 2 - The choices the user has when launching the program
            string[] choices =
            {
                "Print my music",
                "Check if my music is complete"
            };


            // Depending on the user's input
            switch (Choice.GetChoice(message, choices))
            {
                case 0:
                    MusicWrite.Start();
                    break;

                case 1:
                    MusicComplete.Start();
                    break;

                default:
                    Util.PrintColored(ConsoleColor.Red, "\n\n\n choice not found, to be continued");
                    break;
            }
        }
    }
}
