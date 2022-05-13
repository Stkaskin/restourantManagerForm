using Google.Cloud.Firestore;

namespace FireCloud.Business.Interface
{

    public interface IFirebase 
    {
        string table_names { get; }
        string table_Id { get; set; }
     
        
    }
}
