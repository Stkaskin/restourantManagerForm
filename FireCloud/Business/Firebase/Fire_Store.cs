using System;
using System.IO;
using System.Threading.Tasks;
using Firebase.Auth;
using Firebase.Storage;
namespace FireCloud.Business.Firebase
{
    public class Fire_Store
    {
        System.Threading.CancellationTokenSource cancellation;
        Firebase_Settings.Storage settings = new Firebase_Settings.Storage();

        public void Firestorage_Delete(string file_name)
        {
            var task = Firestorage_Connection()
            .Child(settings.File_Child)//files folder
            .Child(file_name)//new file name
            .DeleteAsync();//new file

        }
        public async Task<string> Firestorage_Add(string file_path,string file_name)
        {
            var stream = File.Open(@"" + file_path, FileMode.Open);
            var task = Firestorage_Connection()
             .Child(settings.File_Child)//files folder
             .Child(file_name)//new file name
             .PutAsync(stream, cancellation.Token);//new file
            //  task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} 
            return await task;
         
        }
        public async Task<string> Firestorage_Update(string path,string update_file_name)
        {         
           if (update_file_name == null) 
            {
return await Firestorage_Add(path,"new_image_"+DateTime.Now);
            }
            string dest = path;
            var stream = File.Open(@"" + dest, FileMode.Open);
            var task = Firestorage_Connection()
             .Child(settings.File_Child)//files folder
             .Child(update_file_name)//new file name
             .PutAsync(stream, cancellation.Token);//new file
         
            return await task;
        }  
        public async Task<string> Firestorage_Change_FileName(string path,string new_filename)
        {         
           if (new_filename == null) 
            {
return await Firestorage_Add(path,"new_image_"+DateTime.Now);
            }
            string dest = path;
            var stream = File.Open(@"" + dest, FileMode.Open);
            var task = Firestorage_Connection()
             .Child(settings.File_Child)//files folder
             .Child(new_filename)//new file name
             .PutAsync(stream, cancellation.Token);//new file
         
            return await task;
        }
        public async Task<string>  Firestorage_Get_Async(string file_name)
        {
            var task = await Firestorage_Connection()
           .Child(settings.File_Child)//files folder
           .Child(file_name)//new file name
           .GetDownloadUrlAsync();
            return task;
        }

        public string Firestorage_Get(string file_name)
        {
            //file path get then return
            return Task.Run(()=> Firestorage_Get_Async(file_name)).Result;

        }

        private FirebaseStorage Firestorage_Connection()=>Task.Run(() => Firestore_Options_Connection()).Result;
        
        private async Task<FirebaseStorage> Firestore_Options_Connection()
        {
            var authpo = new FirebaseAuthProvider(new FirebaseConfig(settings.ApiKey));
            var a = await authpo.SignInWithEmailAndPasswordAsync(email: settings.Auth_Mail, password: settings.Auth_Pass);

            FirebaseStorageOptions options = new FirebaseStorageOptions
            {
                AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                ThrowOnCancel = true
            };
            cancellation = new System.Threading.CancellationTokenSource();
            FirebaseStorage storage = new FirebaseStorage(settings.Bucket, options);
            return storage;

        }
    }
}
/*
 
    //  task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");         
 */