using FireCloud.Business.Interface;
using Google.Cloud.Firestore;
using restourantManagerForm.Interfaces;
using restourantManagerForm.ModelManager;

namespace restourantManagerForm.Models
{
    [FirestoreData]

    public class Product:IFirebase,IImage
    {
        string IFirebase.table_names => "Product";
      //  string IFirebase.table_names => this.GetType().Name;
        string IFirebase.table_Id { get => this.id; set { this.id = value; } }
        [FirestoreDocumentId]
        public string id { get; set; }
        [FirestoreProperty]
        public string name { get; set; }
        [FirestoreProperty]
        public string description { get; set; }
        [FirestoreProperty]
        public string categoryId { get; set; }
        [FirestoreProperty]
        public string imageid { get; set; }
        [FirestoreProperty]
        public int  status{ get; set; }
        [FirestoreProperty]
        public string extraSpeacialListId { get; set; }
        [FirestoreProperty]
        public int diplayRank { get; set; }


        public Category category { get; set; }
        public ProductManager manager = new ProductManager();
        public Product()
        {
        }

        public Product(string id,string name, string categoryId)
        {
            this.id = id;
            this.name = name;
            this.categoryId = categoryId;
        }
        public Product(string id,string name, string categoryId, Category category)
        {
            this.id = id;
            this.name = name;
            this.categoryId = categoryId;
            this.category = category;
        }

    }
}
