using FireCloud.Business.Interface;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restourantManagerForm.Models.PersonPartial
{[FirestoreData]


    class SpecialPersonTypeList : IFirebase
    {
        string IFirebase.table_names => "SpecialPersonTypeList";
        string IFirebase.table_Id { get => this.id; set { this.id = value; } }
        [FirestoreDocumentId]
        public string id { get; set; }
        [FirestoreProperty]
        public string name { get; set; }
        [FirestoreProperty]
        public string persontypeid{ get; set; }      
 

    }
}
