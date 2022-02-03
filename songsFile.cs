using System;
using System.IO;
using System.Collections.Generic;
namespace MIS321_PA1
{
    public class songsFile
    {
        public static List<songs> GetSongs()
        {
            List<songs> mySongs = new List<songs>();
            StreamReader inFile = null;
            try
            {
                inFile = new StreamReader("songs.txt");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Something went wrong {0}", e);
                Console.ReadKey();
                return mySongs;
            }
            string line = inFile.ReadLine();
            while (line != null)
            {
                string[] temp= line.Split('#');
                int songID = int.Parse(temp[0]);
                string Title = temp[1];
                DateTime dateAdded = DateTime.Parse(temp[2]);
                bool delete = bool.Parse(temp[3]);
                mySongs.Add(new songs(){songID = songID, Title = Title, dateAdded = dateAdded, delete = delete});
                line = inFile.ReadLine();
            }
            inFile.Close();
            return mySongs;
        }
        public static void AddSong(List<songs> mySongs)
        {
            int songID = 0;
            Random rand1 = new Random();
            songID = rand1.Next(999)+1;
            string Title = "";
            DateTime dateAdded;
            bool delete = true;
            Console.WriteLine("What is the Title?");
            Title = Console.ReadLine();
            Console.WriteLine("What is the Date of the Addition?");
            dateAdded = DateTime.Now;
            StreamWriter outFile = new StreamWriter("songs.txt", true);
            string line = songID + "#" + Title + "#" + dateAdded + "#" + delete;
            outFile.WriteLine(line);
            outFile.Close();
        }
        public static void DeleteSongData(List<songs> mySongs)
        {
            int temp = 0;
            bool isFound = true;
            int count = 0;
            Console.WriteLine("What is the SongID");
            temp = int.Parse(Console.ReadLine());
            foreach(songs song in mySongs)
            {
                if(temp == song.songID)
                {
                    isFound = false;
                    Console.Clear();
                    Console.WriteLine("Song Deleted");
                    songsFile.GetSongs();
                    StreamWriter outFile = new StreamWriter("songs.txt");
                    song.delete = false;
                foreach(songs songs in mySongs)
                {
                    outFile.WriteLine(songs.songID + "#" + songs.Title + "#" + songs.dateAdded + "#" + songs.delete);
                    count++;
                }
                    outFile.Close();
                }
            }
            foreach(songs songz in mySongs)
            {
                if (isFound == true)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Input");
                }
            }
            Console.ReadKey();
        }
    }
}