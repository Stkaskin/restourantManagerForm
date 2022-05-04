using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restourantManagerForm.Models
{
    public class Person
    {
       public int id{ get; set; }
         public string name{ get; set; }
        public Person(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public Person()
        {
        }
        public int getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public string getName()
        {
            return name;
        }

        public void setName(string name)
        {
            this.name = name;
        }


    }
}
