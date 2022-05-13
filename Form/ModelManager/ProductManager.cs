using restourantManagerForm.Manager;
using restourantManagerForm.Models;
using System.Collections.Generic;
using System.Linq;

namespace restourantManagerForm.ModelManager
{

    public class ProductManager
    {

        public Product getProduct(string id)
           =>getProducts().Where(x => x.id == id).FirstOrDefault();
          

        public List<Product> getProducts()
        {
            return AddAllProducts();
        }

        public void setCategory(Product item, Product itemSet)
      => new PropertyManagerService().setAllProperties(item, itemSet);
        public List<Product> setAllCategories(List<Product> items)
        {
            var list = getProducts();
            for (int y = 0; y < items.Count; y++)
                new PropertyManagerService().setAllProperties(list.Where(x => x.id == items[y].id).FirstOrDefault(), items[y]);
            return list;
        }

    

        private List<Product> AddAllProducts()
        {
            //veritabanı
            List<Product> products = new List<Product>();
            products.Add(new Product("1", "Ezo Gelin Çorbası","1", new CategoryManager().getCategory("1")));
            products.Add(new Product("2", "Domates Çorbası", "1", new CategoryManager().getCategory("1")));
            products.Add(new Product("3", "Mercimek Çorbası", "1", new CategoryManager().getCategory("1")));
            products.Add(new Product("4", "Et Döner", "2", new CategoryManager().getCategory("2")));
            products.Add(new Product("5", "Tavuk Döner", "2", new CategoryManager().getCategory("2")));
            products.Add(new Product("6", "Kuru Fasulye", "2", new CategoryManager().getCategory("2")));
            products.Add(new Product("7", "Halka", "3", new CategoryManager().getCategory("3")));
            products.Add(new Product("8", "Şekerpare", "3", new CategoryManager().getCategory("3")));
            products.Add(new Product("9", "Puding", "3", new CategoryManager().getCategory("3")));
            products.Add(new Product("10", "Su", "3", new CategoryManager().getCategory("4")));
            products.Add(new Product("11", "Ayran", "3", new CategoryManager().getCategory("4")));
            products.Add(new Product("12", "Kola", "3", new CategoryManager().getCategory("4")));
            return products;
        }

        public List<Product> getCategory(List<Product> list)
        {
            for (int i = 0; i < list.Count; i++)
                  list[i].category = new CategoryManager().getCategory(list[i].id);
            
            return list;
        }
    }
}
