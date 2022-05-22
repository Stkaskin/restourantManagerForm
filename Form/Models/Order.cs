using FireCloud.Business.Interface;
using Google.Cloud.Firestore;
using restourantManagerForm.ModelManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restourantManagerForm.Models
{
    [FirestoreData]

    public class Order : IFirebase
    {
        string IFirebase.table_names => "Order";
        string IFirebase.table_Id { get => this.id; set { this.id = value; } }
        [FirestoreDocumentId]
        public string id { get; set; }
        [FirestoreProperty]
        public string waiterId { get; set; }
        [FirestoreProperty]
        public string cheffId { get; set; }
        [FirestoreProperty]
        public string note{ get; set; }
        [FirestoreProperty]
        public int status{ get; set; }
        [FirestoreProperty]
        public string datetime { get; set; }
        [FirestoreProperty]
        public int total { get; set; }


        [FirestoreProperty]
        public string tableId { get; set; }


        public Person waiter{ get; set; }
        public Person cheff{ get; set; }
        public Table table { get; set; }
        public OrderManager manager = new OrderManager();

        public Order()
        {
        }

        public Order(string id,string personId, string productId, string tableId, Product product, Person person, Table table)
        {
            this.id = id;
            //this.personId = personId;
            this.tableId = tableId;
        //    this.product = product;
           // this.person = person;
            this.table = table;
        }


    }
}
