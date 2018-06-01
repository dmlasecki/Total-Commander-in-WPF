using System;

namespace TotalCommander.Classes
{
    public abstract class DiscElement
    {

        public string Path { get; }
        public DateTime creationDate { get; set; }
        public DiscElement(string path)
        {
            this.Path = path;
        }


        public abstract string getDescription();
        public abstract bool isFile();
        public abstract string getName();
    }
}
