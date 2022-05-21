using FireCloud.Business.Interface;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restourantManagerForm.Models.PersonPartial
{
    [FirestoreData]
    public class PersonType : IFirebase
    {
        string IFirebase.table_names => "PersonType";
        string IFirebase.table_Id { get => this.id; set { this.id = value; } }
        [FirestoreDocumentId]
        public string id { get; set; }
        [FirestoreProperty]
        public string SpecialPersonTypeListid { get; set; }
        [FirestoreProperty]
        public bool PersonAdd { get; set; }
        [FirestoreProperty]
        public bool PersonUpdate { get; set; }
        [FirestoreProperty]
        public bool PersonDelete { get; set; }
        [FirestoreProperty]
        public bool CategoryAdd { get; set; }
        [FirestoreProperty]
        public bool CategoryDelete { get; set; }
        [FirestoreProperty]
        public bool CategoryUpdate { get; set; }
        [FirestoreProperty]
        public bool ProductAdd { get; set; }
        [FirestoreProperty]
        public bool ProductDelete { get; set; }
        [FirestoreProperty]
        public bool ProductUpdate { get; set; }
        [FirestoreProperty]
        public bool TableAdd { get; set; }
        [FirestoreProperty]
        public bool TableDelete { get; set; }
        [FirestoreProperty]
        public bool TableUpdate { get; set; }
        [FirestoreProperty]
        public bool OrderAdd { get; set; }
        [FirestoreProperty]
        public bool OrderDelete { get; set; }
        [FirestoreProperty]
        public bool OrderUpdate { get; set; }
        [FirestoreProperty]
        public bool TypeAdd { get; set; }
        [FirestoreProperty]
        public bool TypeDelete { get; set; }
        [FirestoreProperty]
        public bool TypeUpdate { get; set; }


    }
}
