using FireCloud.Business.Interface;
using  Google.Cloud.Firestore;
using restourantManagerForm.ModelManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restourantManagerForm.Models
{
    [FirestoreData]
   
    public class Person:IFirebase
    {
        string IFirebase.table_names => "Person";
        string IFirebase.table_Id { get => this.id; set { this.id = value; } }
        [FirestoreDocumentId]
        public string id { get; set; }
        [FirestoreProperty]
        public string name { get; set; }
        [FirestoreProperty]
        public string type{ get; set; }
        [FirestoreProperty]
        public int status { get; set; }
        [FirestoreProperty]
        public string  imageid { get; set; }
        [FirestoreProperty]
        public int diplayRank { get; set; }

        public PersonManager manager = new PersonManager();

        public Person(string id,string name)
        {
            this.id = id;
            this.name = name;
        }

        public Person()
        {
        }
        
        



    }
}
