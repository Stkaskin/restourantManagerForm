using restourantManagerForm.Models;
using restourantManagerForm.Models.PersonPartial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restourantManagerForm.FormDatas
{

    public static class Perdurable
    {
        public static Person Person = new Person();
        public static Product Product = new Product();
        public static Order Order = new Order();
        public static Category Category = new Category();
        public static Table Table= new Table();
        public static PersonType PersonType = new PersonType();

        public static List<object> classList = new List<object> {Person,Product,Order,Table,Category,PersonType };
        public static List<Person> PersonList = new List<Person>();
        public static List<Order> OrderList = new List<Order>();
        public static List<Product> ProductList = new List<Product>();
        public static List<Table> TableList = new List<Table>();
        public static List<Category> CategoryList = new List<Category>();
        public static List<PersonType> PersonTypeList = new List<PersonType>();
        public static object ff() 
        {

            return classList.Where(x => x.GetType().Name.ToString() =="Person").FirstOrDefault();

        }

    }
}
