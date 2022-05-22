using restourantManagerForm.FormDatas;
using restourantManagerForm.Manager;
using restourantManagerForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace restourantManagerForm.ModelManager
{

    public class OrderManager
    {
        public Order getOrder(string id)
                    => getOrders().Where(x => x.id == id).FirstOrDefault();


        public List<Order> getOrders()
        {
            return AddAllOrders();
        }

        public void setCategory(Order item, Order itemSet)
         => new PropertyManagerService().setAllProperties(item, itemSet);
        public List<Order> setAllCategories(List<Order> items)
        {
            var list = getOrders();
            for (int y = 0; y < items.Count; y++)
                new PropertyManagerService().setAllProperties(list.Where(x => x.id == items[y].id).FirstOrDefault(), items[y]);
            return list;
        }
        public Order setOrderProperties(Order order, Order setOrder)
        {
            order = setOrder;
            return order;
        }

        //int id, int personId, int productId, int tableId, Product product, Person person, Table table
        private List<Order> AddAllOrders()
        {
            List<Order> orders = new List<Order>();
            //veritabanı
            orders.Add(AddOrder("1", "2", "1", "2"));
            orders.Add(AddOrder("2", "2", "1", "3"));
            orders.Add(AddOrder("3", "7", "2", "1"));

            return orders;
        }

        private Order AddOrder(string id, string productid, string personid,
                               string tableid)
        {
            return new Order(
                    id, personid, productid, tableid,
                    new ProductManager().getProduct(productid),
                    new PersonManager().getPerson(personid),
                    new TableManager().getTable(tableid));
        }
        public void infoOrder(string id, object view)
        {

            //order id personad, masasının adı,category adı,ürünün adı
            var prop = view.GetType().GetProperty("Text");
            prop.SetValue(view, "");
            foreach (Order order in getOrders())
            {

                if (order.id == id)
                {
                    // string  _text=order.person.name + " " + order.table.name + " " + order.product.category.name + " " + order.product.name;
                    //    prop.SetValue(view, _text);
                }
            }
        }
       public class OrderGrid
        {
            public string id { get; set; }
           public string table { get; set; }
            public string Waiter{ get; set; }
           public string product{ get; set; }
           public string category{ get; set; }
            public string cheff{ get; set; }
    }
        public List<OrderGrid> OrderGridView()
        {
            if (Perdurable.CategoryList.Count==0)
            {
                FirebaseOperationManager.getList("Category");      
            }
            if (Perdurable.ProductList.Count == 0)
            {
                FirebaseOperationManager.getList("Product");
            }
            if (Perdurable.PersonTypeList.Count == 0)
            {
                FirebaseOperationManager.getList("PersonType");

            }
            if (Perdurable.TableList.Count == 0)
            {
                FirebaseOperationManager.getList("Table");
            }
            if (Perdurable.PersonList.Count == 0)
            {
                FirebaseOperationManager.getList("Person");
            }
            if (Perdurable.OrderList.Count == 0)
            {
                FirebaseOperationManager.getList("Order");
            }
      
            var c = new List<OrderGrid>();


               
            foreach (var item in Perdurable.OrderList)
            {
           /*     c.Add(new OrderGrid { 
                    id = item.id,
                    category = Perdurable.CategoryList.Where(x=>x.id==Perdurable.ProductList.Where(y=>y.id==item.productId).FirstOrDefault().categoryId).FirstOrDefault().name,
                    product = Perdurable.ProductList.Where(x => x.id == item.productId).FirstOrDefault().name,
                    table = Perdurable.TableList.Where(x => x.id == item.tableId).FirstOrDefault().name, 
                    Waiter = Perdurable.PersonList.Where(x => x.id == item.waiterId).FirstOrDefault().name,
                    cheff = Perdurable.PersonList.Where(x => x.id == item.cheffId).FirstOrDefault().name,
                });*/
            }
            return c;
        }
    }
}
