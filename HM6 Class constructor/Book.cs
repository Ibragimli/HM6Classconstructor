using System;
using System.Collections.Generic;
using System.Text;

namespace HM6_Class_constructor
{
    class Book : Product
    {
        public Book(string genre, int no, string name, double price) : base(no, name, price)
        {
            this.Genre = genre;
        }

        
        public string Genre;

        public string getInfo()
        {
            return $"No-{this.No} Name-{this.Name} Genre-{this.Genre} Price-{this.Price} Count-{this.Count}";
        }

    }
}
