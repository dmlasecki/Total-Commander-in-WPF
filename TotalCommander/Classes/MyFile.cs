using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TotalCommander.Classes
{
    class MyFile :DiscElement
    {

        public MyFile(string path) : base(path)
        {
            FileInfo info = new FileInfo(path);
            creationDate = File.GetCreationTime(path);
            extension = getExtension(path);
            size = info.Length;
        }
        public string extension { get; }

        public long size { get; }

        public string getExtension(string path)
        {

            return path.Substring(path.LastIndexOf(@".") + 1).ToUpper();
        }

        public override string getDescription()
        {
            return Path.Substring(Path.LastIndexOf(@"\") + 1) + " " + creationDate + " <FILE>";
        }

        public override string getName()
        {
            return Path.Substring(Path.LastIndexOf(@"\") + 1);
        }

        public override bool isFile()
        {
            return true;
        }
    }
}
