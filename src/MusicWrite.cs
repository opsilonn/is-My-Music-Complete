using System;
using System.IO;


namespace IsMyMusicComplete
{
    /** This Class serves to write the full music library in a text file.
    * The destination is specified in the Class Settings.
    */
    static class MusicWrite
    {
        public static void Start()
        {
            // We open the StreamWriter (we save our result in a text file)
            Util.file = new StreamWriter(Util.PATH_WRITE_MUSIC);


            // We go through all the bands
            string[] bands = Directory.GetDirectories(Util.PATH_READ_MUSIC);
            foreach (string band in bands)
            {
                WriteBand(band);
            }


            // We close the file
            Util.file.Close();

            // We tell the user where the file is located
            Console.WriteLine("\n\nMusic written at {0} !", Util.PATH_WRITE_MUSIC);
        }


        /// <summary> For a given Band, prints all its data </summary> 
        /// <param name="pathBand"> Path leading to the Band we are analysing </param>
        private static void WriteBand(string pathBand)
        {
            // We set and write the current Band
            Util.CURRENT_BAND = pathBand.Remove(0, Util.PATH_READ_MUSIC.Length + 1);
            Util.Write(Util.CURRENT_BAND);

            // We go through all the band's Albums
            string[] albums = Directory.GetDirectories(pathBand);
            foreach (string album in albums)
            {
                WriteAlbum(album);
            }


            Util.Write("\n");
        }


        /// <summary> For a given Album, prints all its data </summary> 
        /// <param name="pathAlbum"> Path leading to the Album we are analysing </param>
        private static void WriteAlbum(string pathAlbum)
        {
            // We set and write the current Album
            Util.CURRENT_ALBUM = pathAlbum.Remove(0, Util.PATH_BAND().Length + 1);
            Util.Write("   " + Util.CURRENT_ALBUM);


            // We go through all the album's Songs
            string[] album = Directory.GetFiles(Util.PATH_ALBUM(), "*.mp3", SearchOption.AllDirectories);

            for (int i = 0; i < album.Length; i++)
            {
                // We extract the song's name
                string song = Path.GetFileNameWithoutExtension(album[i]);

                // We save the file
                Util.Write("       " + song);
            }


            Util.Write("\n");
        }
    }
}