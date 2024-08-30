using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexers
{
    class Website
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    class Websites
    {
        public Website[] _data { get; set; }

        public Website this[int index]
        {
            get => _data[index];
            set
            {
                _data[index] = value;
            }


        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
                var websites = new Websites();
                websites[0] = new Website() { Name = "Web1" , Url = "dhdhd.com"};

        }
    }
}
