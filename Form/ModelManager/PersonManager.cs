using restourantManagerForm.Manager;
using restourantManagerForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restourantManagerForm.ModelManager
{

    public class PersonManager
    {

        public Person getPerson(string id)
        =>getPersons().Where(x => x.id == id).FirstOrDefault() ;
        

        public List<Person> getPersons()
           => AddAllPersons();


        public void setCategory(Person item, Person itemSet)
       => new PropertyManagerService().setAllProperties(item, itemSet);
        public List<Person> setAllCategories(List<Product> items)
        {
            var list = getPersons();
            for (int y = 0; y < items.Count; y++)
                new PropertyManagerService().setAllProperties(list.Where(x => x.id == items[y].id).FirstOrDefault(), items[y]);
            return list;
        }
        private List<Person> AddAllPersons()
        {
            List<Person> persons = new List<Person>();
            //veritabanı
            persons.Add(new Person("1", "Sıtkı"));
            persons.Add(new Person("2", "Oğuz"));
            persons.Add(new Person("3", "Utku"));
            return persons;
        }
    }
}
