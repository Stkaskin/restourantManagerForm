using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restourantManagerForm.Models
{
    public class Table
    {
        int id{ get; set; }
        string ad{ get; set; }
        public Table() { }
        public Table(int id, string ad)
        {
            this.id = id;
            this.ad = ad;
        }
        public int getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public string getAd()
        {
            return ad;
        }

        public void setAd(string ad)
        {
            this.ad = ad;
        }
    }
}
