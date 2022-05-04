using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restourantManagerForm.Models
{
    public class Product
    {
        int id{ get; set; }
        string name{ get; set; }
        int categoryId{ get; set; }
        Category category{ get; set; }
        public Product()
        {
        }

        public Product(int id, string name, int categoryId)
        {
            this.id = id;
            this.name = name;
            this.categoryId = categoryId;
        }
        public Product(int id, string name, int categoryId, Category category)
        {
            this.id = id;
            this.name = name;
            this.categoryId = categoryId;
            this.category = category;
        }
        public int getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public string getName()
        {
            return name;
        }

        public void setName(string name)
        {
            this.name = name;
        }



        public int getCategoryId()
        {
            return categoryId;
        }

        public void setCategoryId(int categoryId)
        {
            this.categoryId = categoryId;
        }

        public Category getCategory()
        {
            return category;
        }

        public void setCategory(Category category)
        {
            this.category = category;
        }
    }
}
