using restourantManagerForm.ModelManager;
using restourantManagerForm.Models;
using restourantManagerForm.Models.PersonPartial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restourantManagerForm.DataManager
{

    public class Fake
    {
        FirebaseManger.Cloud manager = new FirebaseManger.Cloud();
        List<string> tableNames = new List<string> { "table1", "table2", "table3", "table4", "table5", "table6", };
        List<string> waiterNames = new List<string> { "Sıtkı", "Oğuz", "Utku" };
        List<string> cheffNames = new List<string> { "Cheff1", "Cheff2", "Cheff3" };
        List<string> admin = new List<string> { "admin" };
        List<string> categories = new List<string> { "Başlangıç", "Ana", "Tatlı", "İçicek" };
        List<string> category1 = new List<string> { "Domates Çorbası", "Ezo Gelin Çorbası", "Mercimek Çorbası", };
        List<string> category2 = new List<string> { "Kuru Fasulye", "Tavuk Döner", "Et Döner" };
        List<string> category3 = new List<string> { "Puding", "Şekerpare", "Halka" };
        List<string> category4 = new List<string> { "Kola", "Ayran", "Su" };
        List<string> tableIds = new List<string>();
        List<string> productIds = new List<string>();
        List<string> waiterIds = new List<string>();
        List<string> cheffIds = new List<string>();
        string waiterTypeId = "";
        string cheffTypeId = "";
        string adminTypeId = "";
        public void addAll() 
        {
            AddTables();
           PersonTypesAdd();
           PersonsAdd();
            AddCategoryAndProduct();
            AddOrder();
       }
        public void AddOrder() 
        {
            Random r = new Random();
            r.Next(0, productIds.Count);
            manager.Add(new Order { waiterId = waiterIds[r.Next(0, waiterIds.Count)],cheffId = cheffIds[r.Next(0, cheffIds.Count)]
            ,productId = productIds[r.Next(0, productIds.Count)],
            tableId = tableIds[r.Next(0, tableIds.Count)]

            });
        }
        public void PersonTypesAdd()
        {
          adminTypeId=  manager.Add(new PersonTypeManager().admin());
            cheffTypeId= manager.Add(new PersonTypeManager().cheff( ));
            waiterTypeId= manager.Add(new PersonTypeManager().waiter());

        }
        public void PersonsAdd() 
        { 
            foreach (var item in admin)
            {
                manager.Add(new Person { name = item, active = true, type = adminTypeId });
            }
            foreach (var item in cheffNames)
            {
                cheffIds.Add( manager.Add(new Person { name = item, active = true, type = cheffTypeId }));
            }
            foreach (var item in waiterNames)
            {
                waiterIds.Add( manager.Add(new Person { name = item, active = true, type = waiterTypeId }));
            }
        }
        public void AddCategoryAndProduct() 
        {
            List<List<string>> listCategories = new List<List<string>> { category1, category2, category3, category4 };
            int i = 0;
            foreach (var item in categories)
            {
                ProductAdd(manager.Add(new Category { name=item}),listCategories[i]) ;
                i++;

            }
        }
        private void ProductAdd(string categoryid,List<string > list) 
        {
            foreach (var item in list)
            {
                productIds.Add( manager.Add(new Product { categoryId=categoryid,name=item}));
            }
        }
        public void AddTables()
        {
          
            foreach (var item in tableNames)
            {
                tableIds.Add(manager.Add(new Table { name = item }));

            }

        }



    }
}
