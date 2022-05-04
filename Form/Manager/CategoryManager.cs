using restourantManagerForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restourantManagerForm.Manager
{

    public class CategoryManger
    {

        public List<Category> getAllCategories()
        {
            return AddAllCategories();
        }

        public Category setCategory(Category category, Category setCategory)
        {
            return setCategoryProperties(category, setCategory);
        }
        public Category search(int id)
        {
            foreach (Category category in getAllCategories())
            {
                if (category.getId() == id)
                    return category;
            }
            return null;
        }

        public List<Category> setAllCategories(List<Category> categories)
        {
            List<Category> list = getAllCategories();
            for (int y = 0; y < categories.Count; y++)
                for (int i = 0; i < list.Count; i++)
                    if (list[i].getId() == categories[y].getId())
                        list[i] = setCategoryProperties(list[i], categories[y]);
            return list;
        }
        private Category setCategoryProperties(Category category, Category setCategory)
        {
            category = setCategory;
            return category;
        }
        private List<Category> AddAllCategories()
        {
            List<Category> CategoriesList = new List<Category>();
            //veritabanı
            CategoriesList.Add(new Category(1, "Başlangıç "));
            CategoriesList.Add(new Category(2, "Ana Yemek "));
            CategoriesList.Add(new Category(3, "Tatlı"));
            CategoriesList.Add(new Category(4, "İçicek"));
            return CategoriesList;
        }}
    }
