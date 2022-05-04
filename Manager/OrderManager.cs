using restourantManagerForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace restourantManagerForm.Manager
{

    public class OrderManager
    {

        public List<Order> getOrders()
        {
            return AddAllOrders();
        }

        public Order setOrder(Order order, Order setOrder)
        {
            return setOrderProperties(order, setOrder);
        }


        public List<Order> setAllOrders(List<Order> orders)
        {
            List<Order> list = getOrders();
            for (int y = 0; y < orders.Count; y++)
                for (int i = 0; i < list.Count; i++)
                    if (list[i].getId() == orders[y].getId())
                        list[i]= setOrderProperties(list[i], orders[y]);
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
            orders.Add(AddOrder(1, 2, 1, 2));
            orders.Add(AddOrder(2, 2, 1, 3));
            orders.Add(AddOrder(3, 7, 2, 1));

            return orders;
        }

        private Order AddOrder(int id, int productid, int personid,
                               int tableid)
        {
            return new Order(
                    id, personid, productid, tableid,
                    new ProductManager().getProduct(productid),
                    new PersonManager().getPerson(personid),
                    new TableManager().getTable(tableid));
        }
        public void infoOrder(int id, TextBox view)
        {

            //order id personad, masasının adı,category adı,ürünün adı
            view.Text="";
            foreach (Order order in getOrders())
            {
                if (order.getId() == id)
                    view.Text+=order.getPerson().getName() + " " + order.getTable().getAd() + " " + order.getProduct().getCategory().getName() + " " + order.getProduct().getName();
            }
        }
    }
}
