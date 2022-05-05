using FireCloud.Business.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restourantManagerForm.DataManager
{
    public class Firebase
    {
        public class Cloud
        {
            public string Add(object obj) => new Firebase_Save().Add(obj);
            public int Update(object obj)
            {
                new Firebase_Save().Update(obj);
                return 1;

            }

            public int Update(object obj, string newId) => new Firebase_Save().Update(obj, newId);
            public int Delete(object obj) => new Firebase_Save().Remove(obj);

            public List<T> Selection<T>(T obj) => (List<T>)new Firebase_Save().Selection(obj);
            public List<T> Selection<T>(T obj, string documentName, string searchValue) => (List<T>)new Firebase_Save().Selection(obj, searchValue, documentName);

        }
        public class Strorage 
        {
            FireStorage_Save save = new FireStorage_Save();
            public (string url,string fileName) Add(string filePath) => new FireStorage_Save().Add(filePath);
            public string Update(string path , string newFilePath) => new FireStorage_Save().Update(path, newFilePath);
            public int Delete(string path) => new FireStorage_Save().Remove(path);
        }
    }
}
