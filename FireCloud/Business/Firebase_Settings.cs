using System;


namespace FireCloud.Business
{
  public  class Firebase_Settings
    {
      public  class Firebase
        {

            //public string File_Location = AppDomain.CurrentDomain.BaseDirectory + @"cloudfire.json";
            public string File_Location = @"C:\Users\Askin\source\repos\RestourantManager\restourantManagerForm\FireCloud\My_Data\Firebase\cloudfire.json";
            public string Firebase_Name = "restourantmanager-89b1e";
            //Default
            public string EnviromentValue = "GOOGLE_APPLICATION_CREDENTIALS";
        }

        public class Storage
        {
            public string ApiKey = "x";
            public string Bucket = "f-x-x.xx.com";
            public string Auth_Mail = "xx@xx.com";
            public string Auth_Pass = "xx.qQ";
            public string File_Child = "files";
        }
        //storge
     
    
    }
}
