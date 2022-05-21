using FireCloud.Business.Interface;
using Google.Cloud.Firestore;
using restourantManagerForm.ModelManager;

namespace restourantManagerForm.Models
{
    [FirestoreData]

    public class Table:IFirebase
    {
        string IFirebase.table_names => "Table";
        string IFirebase.table_Id { get => this.id; set { this.id = value; } }
        [FirestoreDocumentId]
        public string id { get; set; }
        [FirestoreProperty]
        public string name { get; set; }
        [FirestoreProperty]
        public int diplayRank { get; set; }

        [FirestoreProperty]
        public int status { get; set; }

        public TableManager manager = new TableManager();
        public Table() { }
        public Table(string id,string name)
        {
            this.id = id;
            this.name = name;
        }

    }
}
