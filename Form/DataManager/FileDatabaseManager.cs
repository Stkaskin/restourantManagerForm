using Google.Cloud.Firestore;
using Nancy.Json;
using Newtonsoft.Json;
using restourantManagerForm.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace restourantManagerForm.DataManager
{
    public class FileDatabaseManager
    {
        string filename = Application.StartupPath + @"/test.txt";
        public string setAllPropertiesToString(object itemOrjinal)
        {//'{"name":"John", "age":30, "car":null}'
            string str = "{\"" + itemOrjinal.GetType().Name + "\": {";
            foreach (var item in itemOrjinal.GetType().GetProperties())
            {
                var p = itemOrjinal.GetType().GetProperty(item.Name);
                str += "\"" + p.Name + "\": " + "\"" + p.GetValue(itemOrjinal).ToString() + "\",";
            }
            if (str.LastOrDefault() == ',')
                str=str.Substring(0,str.Length-1);
            str += "}}";
            return str;
        }
        public void Save(object obj)
        {

            FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            string a = setAllPropertiesToString(obj);
            MessageBox.Show(a);
            if (a.Length > 0)
            {
                sw.WriteLine(a);
                sw.Flush();
            }
            sw.Close();
            fs.Close();
         //   Delete(obj);
        }
        public class Root
        {
            public Person Class1 { get; set; }
            public Table Class2 { get; set; }

        }
  
        public void Update(object obj) { }
        public void Selection<T>()
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            string str = sr.ReadLine();
            while (str != null)
            {
                Console.WriteLine(str);
                str = sr.ReadLine();
            }
            Console.ReadLine();
            sr.Close();
            fs.Close();

        }
        public void Selection<T>(string id) { }


    }
}
