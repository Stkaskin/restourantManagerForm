using restourantManagerForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restourantManagerForm.Manager
{

    public class TableManager
    {

        public Table getTable(int id)
        {
            foreach (Table table in getTables())
                if (id == table.getId())
                    return table;

            return null;
        }

        public List<Table> getTables()
        {
            return AddAllTables();
        }

        public Table setTable(Table table, Table setData)
        {
            return setTableProperties(table, setData);
        }


        public List<Table> setAllTables(List<Table> tables)
        {
            List<Table> list = getTables();
            for (int y = 0; y < tables.Count; y++)
                for (int i = 0; i < list.Count; i++)
                    if (list[i].getId() == tables[y].getId())
                        list[i]= setTableProperties(list[i], tables[y]);
            return list;
        }
        public Table setTableProperties(Table table, Table setData)
        {
            table = setData;
            /*  table.setId(temp.getId());
              table.setAd(temp.getAd());*/
            return table;
        }
        private List<Table> AddAllTables()
        {
            List<Table> tables = new List<Table>();
            //veritabanı
            tables.Add(new Table(1, "KAT1"));
            tables.Add(new Table(2, "KAT2"));
            tables.Add(new Table(3, "KAT3"));
            return tables;
        }

    }
}
