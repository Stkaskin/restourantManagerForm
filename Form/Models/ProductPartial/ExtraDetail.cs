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
    public class ExtraDetail : IFirebase
    {
        string IFirebase.table_names => "ExtraDetail";
        string IFirebase.table_Id { get => this.id; set { this.id = value; } }
        [FirestoreDocumentId]
        public string id { get; set; }
        [FirestoreProperty]
        public string extraId { get; set; }
        [FirestoreProperty]
        public string specialExtraListId { get; set; }
        [FirestoreProperty]
        public bool active { get; set; }
        [FirestoreProperty]
        public string imageId { get; set; }
        [FirestoreProperty]
        public int displayRank { get; set; }


    }
}
