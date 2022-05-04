using CloudFireEng.Business.Firebase;

namespace CloudFireEng.Business.Work
{
    public class Firebase_Work
    {
        public object Selection(string collection, string docCol, string docSearch)
        {
       
           
                return new Fire_Base().Selection(collection, docCol, docSearch);
            
          
        }


        public int Delete(string table_name, string table_row_id)
        {

            try
            {
                return  new Fire_Base().Delete(table_name, table_row_id);
            }

            catch
            {
                return -1;
            }
        }
        public int Update(string table_name, string table_row_id, object pairs)
        {

            try
            {
                return new Fire_Base().Update(table_name, table_row_id, pairs);
            }
            catch
            {
                return -1;
            }
        }
        public string Add(string table_name, object new_row_object)
        {

            try
            {
                return new Fire_Base().Add(table_name, new_row_object);
            }
            catch
            {
                return "-1";
            }
        }

    }
}
