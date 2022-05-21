using FireCloud.Business.Interface;
using FireCloud.Business.Operation;
using restourantManagerForm.FormDatas;
using restourantManagerForm.ModelManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restourantManagerForm.Manager
{
    public static class FirebaseOperationManager
    {
        #region getList
        public static object getList(string className)
            => getList(className, "", "", false);
        public static object getList(string className, bool reflesh)
    => getList(className, "", "", reflesh);
        public static object getList(string className, string search, string value)
         => getList(className, search, value, false);
        public static object getList(string className, string search, string value, bool reflesh)
        {


            if ("Person" == className)
            {
                if (Perdurable.PersonList.Count == 0 || reflesh)
                    Perdurable.PersonList = new Firebase_Save().Selection(Perdurable.Person);
                return Perdurable.PersonList;
            }
            else if ("Product" == className )
            {
                if (Perdurable.ProductList.Count == 0 || reflesh)
                    Perdurable.ProductList = new Firebase_Save().Selection(Perdurable.Product);
                return Perdurable.ProductList;
            }


            else if ("Table" == className )
            {
                if (Perdurable.TableList.Count == 0 || reflesh)
                    Perdurable.TableList = new Firebase_Save().Selection(Perdurable.Table);
                return Perdurable.TableList;
            }


            else if ("Category" == className )
            {
                if (Perdurable.CategoryList.Count == 0 || reflesh)
                    Perdurable.CategoryList = new Firebase_Save().Selection(Perdurable.Category);
                return Perdurable.CategoryList;
            }

            else if ("PersonType" == className)
            {
                if (Perdurable.PersonTypeList.Count == 0|| reflesh)
                    Perdurable.PersonTypeList = new Firebase_Save().Selection(Perdurable.PersonType);
                return Perdurable.PersonTypeList;
            }

            else if ("Order" == className)
            {
                if (Perdurable.OrderList.Count == 0 || reflesh)
                    Perdurable.OrderList = new Firebase_Save().Selection(Perdurable.Order);

                return new OrderManager().OrderGridView();
            }
            return new object();
        }
        #endregion
    }
}
