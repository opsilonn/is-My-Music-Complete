using System;
using System.IO;
using System.Collections.Generic;

namespace IsMyMusicComplete
{
    /** The goal of this Class is to ensure that your music library is complete.
    * In other words, it checks if each albums contains the accurate number of tracks.
    */
    static class MusicComplete
    {
        private static int CPT_BANDS = 0;
        private static int CPT_ALBUMS = 0;
        private static int CPT_ALBUMS_COMPLETE = 0;
        private static List<string> albumsIncomplete = new List<string>();
        private static List<string> albumsUnknown = new List<string>();


        static public void Start()
        {
            // Initial message     
            Console.Clear();
            Console.WriteLine("We are here to check if your music is complete !\n\n\n");


            // We scan all folders located at our path
            string[] bands = Directory.GetDirectories(Util.PATH_READ_MUSIC);
            CPT_BANDS = bands.Length;


            // For each band, we launch the function analyseBand
            foreach (string band in bands)
            {
                Util.CURRENT_BAND = band.Remove(0, Util.PATH_READ_MUSIC.Length + 1);
                analyseBand();
            }


            // We open the StreamWriter (we save our result in a text file)
            Util.file = new StreamWriter(Util.PATH_WRITE_COMPLETE);


            // We display the final results (counters)
            Util.Write("Number of bands : " + CPT_BANDS);
            Util.Write("Number of albums : " + CPT_ALBUMS);
            Util.Write("Number of albums being complete : " + CPT_ALBUMS_COMPLETE);

            Util.Write("\n");

            Util.Write("Number of incomplete albums : " + albumsIncomplete.Count);
            foreach (string album in albumsIncomplete)
                Util.Write(album);

            Util.Write("\n");

            Util.Write("Number of albums with unknown results : " + albumsUnknown.Count);
            foreach (string album in albumsUnknown)
                Util.Write(album);


            // We close the StreamWriter
            Util.file.Close();
            
            // We tell the user where the file is located
            Console.WriteLine("\n\nMusic written at {0} !", Util.PATH_WRITE_COMPLETE);
        }



        /// <summary> Analyses the current band, and launches the function analyseAlbum for each album of the band </summary> 
        private static void analyseBand()
        {
            // We count all its albums
            string[] albums = Directory.GetDirectories(Util.PATH_BAND());
            int numberOfAlbums = albums.Length;
            CPT_ALBUMS += numberOfAlbums;


            // We display the name of the band & number of albums
            Util.PrintColored(ConsoleColor.Blue, Util.CURRENT_BAND + " <" + numberOfAlbums + " albums>");


            // For each album, we launch the function analyseAlbum
            foreach (string album in albums)
            {
                Util.CURRENT_ALBUM = album.Remove(0, Util.PATH_BAND().Length + 1);
                analyseAlbum();
            }


            Console.Write("\n\n");
        }


        /// <summary> Analyses the current album from the current band.
        /// Displays the name of the album, and whether it is complete or not </summary> 
        private static void analyseAlbum()
        {
            String status = "  complete";
            ConsoleColor color = ConsoleColor.White;

            // We count all its songs (= all the "mp3" files)
            string[] album = Directory.GetFiles(Util.PATH_ALBUM(), "*.mp3", SearchOption.AllDirectories);
            int numberOfSongs = album.Length;


            // If the album does not contain any song, it is considered incomplete
            // Otherwise, we iterate a loop
            if (numberOfSongs == 0)
            {
                status = "incomplete";
            }
            else
            {
                // We iterate through all the songs in the album
                foreach (string song in album)
                {
                    // We initialize some variables
                    string nameOfTheSong = Path.GetFileNameWithoutExtension(song);
                    int number;

                    // If the song's name can be analysed (contains a space) and its number can be read 
                    if (nameOfTheSong.Contains(" ") && Int32.TryParse(nameOfTheSong.Substring(0, nameOfTheSong.IndexOf(' ')), out number))
                    {
                        // We check if the result is coherent (by default, we assume it is)
                        if (numberOfSongs < number)
                        {
                            status = "incomplete";
                        }
                    }
                    // Something went wrong with the computation
                    else
                    {
                        status = "   unknown";
                    }
                }
            }



            // According to the message, we change the Console Color accordingly
            // Green : the album is complete
            // Red : the album is incomplete
            // Yellow : we cannot know (error somewhere)
            // Magenta : something unpredicted happened...
            switch (status)
            {
                case "  complete":
                    color = ConsoleColor.Green;
                    CPT_ALBUMS_COMPLETE++;
                    break;

                case "incomplete":
                    color = ConsoleColor.Red;
                    albumsIncomplete.Add("  " + Util.CURRENT_BAND + " - " + Util.CURRENT_ALBUM);
                    break;

                case "   unknown":
                    color = ConsoleColor.Yellow;
                    albumsUnknown.Add("  " + Util.CURRENT_BAND + " - " + Util.CURRENT_ALBUM);
                    break;

                default:
                    color = ConsoleColor.Magenta;
                    status = "Could not decipher";
                    break;
            }


            // We display the name of the band and whether it is complete or not
            Util.PrintColored(color, "     " + status + " - <" + numberOfSongs.ToString("D3") + "> - " + Util.CURRENT_ALBUM);
        }
    }
}
