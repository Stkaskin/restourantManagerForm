using restourantManagerForm.ModelManager;
using restourantManagerForm.Models;
using restourantManagerForm.Models.OrderPartial;
using restourantManagerForm.Models.PersonPartial;
using restourantManagerForm.Models.ProductPartial;
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
        List<string> extraList1 = new List<string> { "Tuz", "Pul biber", "Soğan", "Nane" };
        List<string> extraList2 = new List<string> { "Ketcap", "Mayonez", "Special Sauce" };
       
        List<string> extraList3 = new List<string> { "Çeviz", "Antep Fıstığı" };
        List<string> extraList4 = new List<string> { "Açık", "Kapalı", "Köpüklü" };
        List<string> SpecialPersonTypeListNames = new List<string> { "Admin", "Waiter", "Cheff" };

        List<string> tableIds = new List<string>();
        List<string> productIds = new List<string>();
        List<string> waiterIds = new List<string>();
        List<string> cheffIds = new List<string>();
        List<List<string>> extraListwithIds = new List<List<string>>();
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
            // = ,
            Random r = new Random();
            r.Next(0, productIds.Count);
            var order = new Order
            {
                waiterId = waiterIds[r.Next(0, waiterIds.Count)],
                cheffId = cheffIds[r.Next(0, cheffIds.Count)],
                total = 0,
                datetime = DateTime.Now,
                status = r.Next(0, 3),
                note = "myNote " + r.Next(300, 499),
                tableId = tableIds[r.Next(0, tableIds.Count)]


            };

            string id_ = manager.Add(order);
            int total = 0;
            for (int i = 0; i < r.Next(1, 5); i++)
            {
                int price = r.Next(20, 30);
                int count = r.Next(1, 6);
                total += price * count;
                manager.Add(new OrderDetail { count = count, orderid = id_, price = price, productid = productIds[r.Next(0, productIds.Count)], status = 1, sum = (price * count) });

            }
            order.id = id_;
            order.total = total;
            manager.Update(order);

        }
        public void PersonTypesAdd()
        {
            string getid = manager.Add(new SpecialPersonTypeList { name = "admin", persontypeid = "" });
            adminTypeId = manager.Add(new PersonTypeManager().admin(getid));
            manager.Update(new SpecialPersonTypeList { id = getid, name = "admin", persontypeid = adminTypeId });
            getid = manager.Add(new SpecialPersonTypeList { name = "cheff", persontypeid = "" });
            cheffTypeId = manager.Add(new PersonTypeManager().cheff(getid));
            manager.Update(new SpecialPersonTypeList { id = getid, name = "cheff", persontypeid = cheffTypeId });
            getid = manager.Add(new SpecialPersonTypeList { name = "waiter", persontypeid = "" });
            waiterTypeId = manager.Add(new PersonTypeManager().waiter(getid));
            manager.Update(new SpecialPersonTypeList { id = getid, name = "cheff", persontypeid = waiterTypeId });

        }
        public void PersonsAdd()
        {
            foreach (var item in admin)
            {
                manager.Add(new Person { name = item, status = 1, type = adminTypeId });
            }
            foreach (var item in cheffNames)
            {
                cheffIds.Add(manager.Add(new Person { name = item, status= new Random().Next(0,3), type = cheffTypeId }));
            }
            foreach (var item in waiterNames)
            {
                waiterIds.Add(manager.Add(new Person { name = item, status = new Random().Next(0, 3), type = waiterTypeId }));
            }
        }
        public void AddCategoryAndProduct()
        {
            extrasAdd();
            List<List<string>> listCategories = new List<List<string>> { category1, category2, category3, category4 };
      
            int i = 0;
   
            foreach (var item in categories)
            {
                ProductAdd(manager.Add(new Category { name = item ,status=1,diplayRank=i,imageid=""}), listCategories[i]);
                i++;

            }
        }
        List<string> specialExtrNamesIds = new List<string> ();
        private void extrasAdd()
        {
            
            List<List<string>> extraList = new List<List<string>> { extraList1, extraList2, extraList3, extraList4 };
            foreach (var item in extraList)
            {
                int typeo = 0;
                List<string> list = new List<string>();
                foreach (var item_in in item)
                {
                    list.Add(manager.Add(new Extra { type = typeo++, name = item_in }));
                }
                extraListwithIds.Add(list) ;

            }
            int typecode = 0; //basl,ana,tatli,içicek
            List<string> extralisttypes = new List<string> { "Ara yemek","Ana yemek","Tatlı","İçicek"};
            foreach (var item in extralisttypes)
            {
            string id_   = manager.Add(new SpecialExtraList { displayRank = typecode, status =1 ,name=item }) ;
                specialExtrNamesIds.Add(id_);
                int displayrank_ = 0;
                foreach (var item_in in extraList[typecode])
                {
                    manager.Add(new ExtraDetail {displayRank= displayrank_++,active=true,extraId=item_in,specialExtraListId=id_,imageId=""});
                }
                typecode++;
            }

        }
        private void ProductAdd(string categoryid, List<string> list)
        {
           
            int i = 0;
            foreach (var item in list)
            {
                productIds.Add(manager.Add(new Product { extraSpeacialListId = specialExtrNamesIds[i], diplayRank = i, imageid = "", status = new Random().Next(0, 2), description = "", categoryId = categoryid, name = item }));
                i++;
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
