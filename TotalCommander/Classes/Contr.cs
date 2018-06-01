using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TotalCommander.Classes
{
    
    class Contr
    {
        public Contr(DiscElement ele)
        {
            Name = ele.getName();
            Path = ele.Path;
            isFile = ele.isFile();
            CreationDate = ele.creationDate;
            if (ele is MyDirectory)
            {
                MyDirectory temp = (MyDirectory)ele;
                Type = "<DIR>";


                Size = "";
            }

            else
            {
                MyFile temp = (MyFile)ele;
                Type = temp.extension;
                Size = temp.size.ToString();
            }
        }


        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime CreationDate { get; set; }
        public string Size { get; set; }
        public string Path { get; set; }
        public bool isFile { get; set; }

    }
}
