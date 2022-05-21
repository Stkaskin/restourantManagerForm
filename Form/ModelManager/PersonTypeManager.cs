using restourantManagerForm.Models;
using restourantManagerForm.Models.PersonPartial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restourantManagerForm.ModelManager
{
   public class PersonTypeManager
    {
        public void defaultValues(ref PersonType type) 
        {
            type.OrderAdd = type.OrderDelete = type.OrderUpdate =
                type.TableAdd = type.TableDelete = type.TableUpdate =
                type.CategoryAdd = type.CategoryDelete = type.CategoryUpdate = 
                type.PersonAdd = type.PersonDelete = type.PersonUpdate = 
                type.ProductAdd = type.ProductDelete= type.ProductUpdate= 
                type.TypeAdd = type.TypeDelete = type.TypeUpdate  = false;

        }
        public PersonType waiter(string SpecialPersonTypeListid)
        {
            PersonType type = new PersonType();
            defaultValues(ref type);
            type.SpecialPersonTypeListid = SpecialPersonTypeListid;
            type.OrderAdd = type.OrderDelete = type.OrderUpdate = type.TableAdd = type.TableDelete = type.TableUpdate = true;
            return type;
        }
        public PersonType cheff(string SpecialPersonTypeListid)
        {
            PersonType type = new PersonType();
            defaultValues(ref type);
            type.SpecialPersonTypeListid = SpecialPersonTypeListid;
            type.OrderAdd = type.OrderDelete = type.OrderUpdate = 
            type.CategoryAdd =type.CategoryDelete= type.CategoryUpdate= 
                type.ProductAdd = type.ProductDelete= type.ProductUpdate= true;
            return type;
        }
        public PersonType admin(string SpecialPersonTypeListid)
        {
            PersonType type = new PersonType();
            defaultValues(ref type);
            type.SpecialPersonTypeListid = SpecialPersonTypeListid;
            type.OrderAdd = type.OrderDelete = type.OrderUpdate =
                     type.TableAdd = type.TableDelete = type.TableUpdate =
                     type.CategoryAdd = type.CategoryDelete = type.CategoryUpdate =
                     type.PersonAdd = type.PersonDelete = type.PersonUpdate =
                     type.ProductAdd = type.ProductDelete = type.ProductUpdate =
                     type.TypeAdd = type.TypeDelete = type.TypeUpdate = true;
            return type;
        }
    }
}
