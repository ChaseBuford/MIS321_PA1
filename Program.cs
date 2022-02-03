using System;
using System.IO;
using System.Collections.Generic;

namespace MIS321_PA1
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }
        static void Menu()
        {
            List<songs> mySongs = songsFile.GetSongs();
            int userInput;
            Console.Clear();
            Console.WriteLine("1)  Show All Songs \n2)  Add A Song \n3)  Delete a Song \n4)  Exit");
            userInput = int.Parse(Console.ReadLine());
            Console.Clear();
            if (userInput == 1)
            {
                ShowAllSongs(mySongs);
            }
            if (userInput == 2)
            {
                AddSong(mySongs);
            }
            if (userInput == 3)
            {
                DeleteSong(mySongs);
            }
            if (userInput == 4)
            {
                Console.WriteLine("Goodbye");
                Environment.Exit(0);
            }
            if (userInput != 1 && userInput != 2 && userInput != 3 && userInput != 4)
            {
                Console.WriteLine("Invalid Input (press any key to continue)");
                Console.ReadKey();
                Menu();
            }
        }
        public static void ShowAllSongs(List<songs> mySongs)
        {
            mySongs.Sort();
            Console.WriteLine("Sorted by time:");
            bool isValid = true;
            foreach(songs song in mySongs)
            {
                if (isValid == song.delete)
                {
                    Console.WriteLine("Song ID: " + song.songID + "     Date Added: " + song.dateAdded + "   Title: " + song.Title + "\n");
                    Console.ReadKey();
                }
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Menu();
        }
        public static void AddSong(List<songs> mySongs)
        {
            songsFile.AddSong(mySongs);
            Menu();
        }
        public static void DeleteSong(List<songs> mySongs)
        {
            songsFile.DeleteSongData(mySongs);
            Menu();
        }
    }
}