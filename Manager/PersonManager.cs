using restourantManagerForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restourantManagerForm.Manager
{

    public class PersonManager
    {

        public Person getPerson(int id)
        {
            foreach (Person person in getPersons())
                if (id == person.getId())
                    return person;

            return null;
        }

        public List<Person> getPersons()
        {
            return AddAllPersons();
        }

        public Person setPerson(Person person, Person setPerson)
        {
            return setPersonProperties(person, setPerson);
        }


        public List<Person> setAllPersons(List<Person> persons)
        {
            List<Person> list = getPersons();
            for (int y = 0; y < persons.Count; y++)
                for (int i = 0; i < list.Count; i++)
                    if (list[i].getId() == persons[y].getId())
                        list[i]= setPersonProperties(list[i], persons[y]);
            return list;
        }
        public Person setPersonProperties(Person person, Person setPerson)
        {
            person = setPerson;
            /*  person.setId(temp.getId());
              person.setAd(temp.getAd());*/
            return person;
        }
        private List<Person> AddAllPersons()
        {
            List<Person> persons = new List<Person>();
            //veritabanı
            persons.Add(new Person(1, "Sıtkı"));
            persons.Add(new Person(2, "Oğuz"));
            persons.Add(new Person(3, "Utku"));
            return persons;
        }
    }
}
