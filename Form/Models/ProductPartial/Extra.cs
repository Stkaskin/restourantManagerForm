using FireCloud.Business.Interface;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restourantManagerForm.Models.ProductPartial
{
    [FirestoreData]
    public class Extra : IFirebase
    {
        string IFirebase.table_names => "Extra";
        string IFirebase.table_Id { get => this.id; set { this.id = value; } }
        [FirestoreDocumentId]
        public string id { get; set; }
        [FirestoreProperty]
        public string name { get; set; }
        [FirestoreProperty]
        public int type { get; set; }



    }
}
