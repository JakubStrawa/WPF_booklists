using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWPF
{
    public class Book : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string surname;
        public string Surname
        {
            get { return surname; }
            set { surname = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Surname")); }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name")); }
        }

        private uint index;
        public uint Index
        {
            get { return index; }
            set { index = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Index")); }
        }

        private string group;
        public string Group
        {
            get { return group; }
            set { group = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Group")); }
        }

        public Book( string surname, string name, uint index, string group)
        {
            Surname = surname;
            Name = name;
            Index = index;
            Group = group;
        }
    }
}