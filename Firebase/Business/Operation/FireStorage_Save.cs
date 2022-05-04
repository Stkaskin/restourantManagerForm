﻿
using Fire_Storage_Realtime_Firebase.Business.Work;

namespace CloudFireEng.Business.Operation
{
    class FireStorage_Save
    {


        public (string Url, string File_Name) Add(object class_object) => new Storage_Work().FireStorgeFile_Add("");
        

        public void Remove(string path) => new Storage_Work().FireStorgeFile_Delete(path);

        public string Update(string path, string new_file) => new Storage_Work().FireStorgeFile_Update(path, new_file);
        public string Change_FileName(string path, string new_name) => new Storage_Work().FireStorgeFile_Change_FileName(path, new_name);

    }
}
