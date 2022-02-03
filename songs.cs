using System;
using System.IO;
using System.Collections.Generic;
namespace MIS321_PA1
{
    public class songs  :   IComparable<songs>
    {
        public int songID {get; set;}
        public string Title {get; set;}
        public DateTime dateAdded {get; set;}
        public int count {get; set;}
        public bool delete {get; set;}
        public int CompareTo(songs temp)
        {
            return this.dateAdded.CompareTo(temp.dateAdded);
        }
    }
}