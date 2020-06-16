using System;
using System.IO;


namespace IsMyMusicComplete
{
    /** This Class serves to store all variables we may need in the program.
    * It contains variables that the user may need to change, and others that are just fine.
    */
    static class Util
    {
        // TO MODIFY

        // Where the music is stored
        public static string PATH_READ_MUSIC = @"E:\Musique\ma Musique";


        // DON'T MODIFY THE REST, PLEASE :)

        // Where to write the .txt file listing your music
        public static string PATH_WRITE_MUSIC = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "/log - list of my music.txt";
        // Where to write the .txt file listing is your music is complete
        public static string PATH_WRITE_COMPLETE = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "/log - is my music complete.txt";

        public static StreamWriter file;

        public static string PATH_BAND() { return string.Concat(PATH_READ_MUSIC, "\\", CURRENT_BAND); }
        public static string PATH_ALBUM() { return string.Concat(PATH_BAND(), "\\", CURRENT_ALBUM); }


        public static string CURRENT_BAND = " ";
        public static string CURRENT_ALBUM = " ";




        /// <summary> Prints a message both in the console AND in the text file </summary> 
        /// <param name="message"> Message displayed </param> 
        public static void Write(string message)
        {
            file.WriteLine(message);
            Console.WriteLine(message);
        }


        /// <summary> prints a given message in a given color </summary>
        /// <param name="color"> Color in which the message is displayed </param> 
        /// <param name="message"> Message displayed </param> 
        public static void PrintColored(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
