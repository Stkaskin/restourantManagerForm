using FireCloud.Business.Interface;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restourantManagerForm.Models.OrderPartial
{
    [FirestoreData]
    public class OrderDetail : IFirebase
    {
        string IFirebase.table_names => "OrderDetail";
        string IFirebase.table_Id { get => this.id; set { this.id = value; } }
        public string id { get; set; }
        public string orderid { get; set; }
        [FirestoreProperty]
        public string productid { get; set; }
        [FirestoreProperty]
        public int price { get; set; }
        [FirestoreProperty]
        public int count { get; set; }
        [FirestoreProperty]
        public int sum { get; set; }
        [FirestoreProperty]
        public int status { get; set; }
        public Product product { get; set; }


    }
}
