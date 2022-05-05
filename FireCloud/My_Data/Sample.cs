using FireCloud.Business.Interface;
using Google.Cloud.Firestore;

namespace FireCloud.My_Data
{

    [FirestoreData]
    public class Sample : IFirebase
    {
        
        string IFirebase.table_names => "Table_Name";
        string IFirebase.table_Id { get => this.Id; set { this.Id = value; } }


        [FirestoreDocumentId]
        public string Id { get; set; }
        [FirestoreProperty]
        public string call_number { get; set; }
        [FirestoreProperty]
        public string ff { get; set; }

    }
}
