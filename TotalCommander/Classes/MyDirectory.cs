using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TotalCommander.Classes
{
    class MyDirectory :DiscElement
    {
        public MyDirectory(string path) : base(path)
        {
            creationDate = Directory.GetCreationTime(path);

        }

        public override string getDescription()
        {
            return Path.Substring(Path.LastIndexOf(@"\") + 1) + ' ' + creationDate + " <DIR>";
        }

        public override string getName()
        {
            return Path.Substring(Path.LastIndexOf(@"\") + 1);
        }

        public override bool isFile()
        {
            return false;
        }

        public List<DiscElement> GetSubElements()
        {
            List<DiscElement> elements = new List<DiscElement>();
            string[] dirs = Directory.GetDirectories(Path);
            string[] files = Directory.GetFiles(Path);

            foreach (var item in dirs)
            {
                elements.Add(new MyDirectory(item));
            }

            foreach (var item in files)
            {
                elements.Add(new MyFile(item));
            }


            return elements;

        }
        public List<DiscElement> getGetAllSubDirectories()
        {
            List<DiscElement> elements = new List<DiscElement>();
            string[] dirs = Directory.GetDirectories(Path);
            foreach (var i in dirs)
            {
                elements.Add(new MyDirectory(i));

            }

            return elements;
        }


    }
}

