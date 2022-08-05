using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project
{
    public class Items
    {
        public string Itemno { get; set; }
        public string Name { get; set; }

        public Items(string Itemno, string Name)
        {
            this.Itemno = Itemno;
            this.Name = Name;
        }
        public Items()
        {

        }
    }

}