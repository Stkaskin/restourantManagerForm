using restourantManagerForm.Manager;
using restourantManagerForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restourantManagerForm.ModelManager
{

    public class TableManager
    {

        public Table getTable(string id)
   => getTables().Where(x => x.id == id).FirstOrDefault();

        public List<Table> getTables()
        {
            return AddAllTables();
        }

        public void setCategory(Table item, Table itemSet)
    => new PropertyManagerService().setAllProperties(item, itemSet);
        public List<Table> setAllCategories(List<Table> items)
        {
            var list = getTables();
            for (int y = 0; y < items.Count; y++)
                new PropertyManagerService().setAllProperties(list.Where(x => x.id == items[y].id).FirstOrDefault(), items[y]);
            return list;
        }
        private List<Table> AddAllTables()
        {
            List<Table> tables = new List<Table>();
            //veritabanı
            tables.Add(new Table("1", "KAT1"));
            tables.Add(new Table("2", "KAT2"));
            tables.Add(new Table("3", "KAT3"));
            return tables;
        }

    }
}
