using restourantManagerForm.Manager;
using restourantManagerForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restourantManagerForm.ModelManager
{

    public class CategoryManager
    {
        public Category getCategory(string id)
            => getAllCategories().Where(x => x.id == id.ToString()).FirstOrDefault();

        public List<Category> getAllCategories()
            => AddAllCategories();


        public void setCategory(Category category, Category setCategory)
        => new PropertyManagerService().setAllProperties(category, setCategory);



        public List<Category> setAllCategories(List<Category> categories)
        {
            var list = getAllCategories();
            for (int y = 0; y < categories.Count; y++)
                new PropertyManagerService().setAllProperties(list.Where(x => x.id == categories[y].id).FirstOrDefault(), categories[y]);
            return list;
        }

        private List<Category> AddAllCategories()
        {
            List<Category> CategoriesList = new List<Category>();
            //veritabanı
            CategoriesList.Add(new Category("1", "Başlangıç "));
            CategoriesList.Add(new Category("2", "Ana Yemek "));
            CategoriesList.Add(new Category("3", "Tatlı"));
            CategoriesList.Add(new Category("4", "İçicek"));
            return CategoriesList;
        }
    }
}
