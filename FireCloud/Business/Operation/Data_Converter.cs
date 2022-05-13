using Google.Cloud.Firestore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;


namespace FireCloud.Business.Operation
{
    public class Data_Converter
    {
        public  Dictionary<string, TValue> ToDictionary<TValue>(object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, TValue>>(json);
            return dictionary;
        }
        public object FRealTime_Converter<T>(string a)
        {

            var data = JsonConvert.DeserializeObject<Dictionary<string, T>>(value: a.ToString()).Values.ToList();
            return data;
        }
        public object Firebase_Converter<T>(object datas)
        {
 
            return (IReadOnlyDocumentsConvertListDocumentSnapshot((QuerySnapshot)datas)).ConvertAll(x => x.ConvertTo<T>());
        }
        private List<DocumentSnapshot> IReadOnlyDocumentsConvertListDocumentSnapshot(QuerySnapshot documents)
        {
            List<DocumentSnapshot> snapshots = new List<DocumentSnapshot>();
            foreach (var item in documents.Documents)
                snapshots.Add(item);
            return snapshots;
        }
    }
}
