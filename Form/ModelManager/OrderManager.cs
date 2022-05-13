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
            prop.SetValue(view,"");
            foreach (Order order in getOrders())
            {

                if (order.id == id) {
                   // string  _text=order.person.name + " " + order.table.name + " " + order.product.category.name + " " + order.product.name;
                //    prop.SetValue(view, _text);
                } 
            }
        }
    }
}
