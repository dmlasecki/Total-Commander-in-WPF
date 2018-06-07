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
        DiscElement ele;
        public Contr(DiscElement ele)
        {
            this.ele = ele;
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
                IntSize = temp.size;
            }
        }


        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime CreationDate { get; set; }
        public string Size { get; set; }
        public double IntSize { get; set; }
        public string Path { get; set; }
        public bool isFile { get; set; }
        public string Extension { get; set; }
        public DiscElement Ele
        {
            get
            {
                return ele;
            }
        }
    }
}
