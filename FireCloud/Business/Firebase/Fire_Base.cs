using FireCloud.Business.Operation;
using Google.Cloud.Firestore;
using Newtonsoft.Json;
using System ;
using System.Collections.Generic;

namespace FireCloud.Business.Firebase
{
   public class Fire_Base
    {
        FirestoreDb database;
        public FirestoreDb Connection()
        {

            Firebase_Settings.Firebase settings = new Firebase_Settings.Firebase();
            string path = settings.File_Location;
            
            Environment.SetEnvironmentVariable(settings.EnviromentValue, path);
            return FirestoreDb.CreateAsync(settings.Firebase_Name).Result;
        }
        
        public QuerySnapshot Selection(string collection, string docCol, string docSearch)
        {
            database = Connection();
            Query Qref;
            if (docCol == "" || docSearch == "") { Qref = database.Collection(collection);                
            }
            else { Qref = database.Collection(collection).WhereEqualTo(docCol, docSearch); }

            return Qref.GetSnapshotAsync().Result;
          
        }
        public int Delete(string table_name, string table_row_id)
        {
            database = Connection();
            DocumentReference docref = database.Collection(table_name).Document(table_row_id);
            try
            {
    
                docref.DeleteAsync();
              
                return 1;
            }
            catch
            {
                return -1;
            }
        }
   
        public int  Update(string table_name, string table_row_id, object pairsget)
        {
            database = Connection();
            DocumentReference docref = database.Collection(table_name).Document(table_row_id);
            DocumentSnapshot snap =  docref.GetSnapshotAsync().Result;
            var dictionary =new Data_Converter().ToDictionary<object>(pairsget);
            
            if (snap.Exists)
            {
           
                try 
                {
                    docref.UpdateAsync(dictionary);
                    return 1;
                    
                }
                catch
                {
                    return -1;
                }
             
            }
            return -1;

        }
        public  string Add(string table_name, object new_row_object)
        {
            database = Connection();
            CollectionReference coll = database.Collection(table_name);
            try 
            {
                return  coll.AddAsync(new_row_object).Result.Id;
                  
            }
            catch
            {
                return "";
            }
            
        }
    }
}
