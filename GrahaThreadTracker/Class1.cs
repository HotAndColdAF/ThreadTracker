using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrahaThreadTracker
{
    public class Chara
    {
        public string name;
        public string bullet;
        public string header;
        public string normal;
        public string op;

        public Chara(string name, string bullet, string header, string normal, string op)
        {
            this.name = name;
            this.bullet = bullet;
            this.header = header;
            this.normal = normal;
            this.op = op;
        }
    }
}
