using FireCloud.Business.Firebase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fire_Storage_Realtime_Firebase.Business.Work
{
    public class Storage_Work
    {
        public int FireStorgeFile_Delete(string file_name)
        {
            try
            {
                new Fire_Store().Firestorage_Delete(file_name);
                return 1;
            }
            catch
            {
                return -1;
            }
        }

        public (string Url, string File_Name) FireStorgeFile_Add(string file_path)
        {

            string file_name = "file-" + DateTime.Now.Year + "-" + DateTime.Now.Day + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + ".jpg";
            return (Url: Task.Run(() => new Fire_Store().Firestorage_Add(file_path, file_name)).Result, File_Name: file_name);
        }
        public string FireStorgeFile_Update(string path, string update_file_name)
        {

            return Task.Run(() => new Fire_Store().Firestorage_Update(path, update_file_name)).Result;
        }
        public string FireStorgeFile_Change_FileName(string path, string update_file_name)
        {

            return Task.Run(() => new Fire_Store().Firestorage_Change_FileName(path, update_file_name)).Result;
        }
    }
}
