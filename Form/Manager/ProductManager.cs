using restourantManagerForm.Models;
using System.Collections.Generic;
namespace restourantManagerForm.Manager
{

    public class ProductManager
    {

        public Product getProduct(int id)
        {
            foreach (Product product in getProducts())
                if (id == product.getId())
                    return product;

            return null;
        }

        public List<Product> getProducts()
        {
            return AddAllProducts();
        }

        public Product setProduct(Product product, Product setproduct)
        {
            return setProductProperties(product, setproduct);
        }


        public List<Product> setAllProducts(List<Product> products)
        {
            List<Product> list = getProducts();
            for (int y = 0; y < products.Count; y++)
                for (int i = 0; i < list.Count; i++)
                    if (list[i].getId() == products[y].getId())
                        list[i]= setProductProperties(list[i], products[y]);
            return list;
        }

        public Product setProductProperties(Product product, Product setproduct)
        {
            product = setproduct;
            /*  product.setId(temp.getId());
              product.setAd(temp.getAd());*/
            return product;
        }

        private List<Product> AddAllProducts()
        {
            //veritabanı
            List<Product> products = new List<Product>();
            products.Add(new Product(1, "Ezo Gelin Çorbası", 1, new CategoryManger().search(1)));
            products.Add(new Product(2, "Domates Çorbası", 1, new CategoryManger().search(1)));
            products.Add(new Product(3, "Mercimek Çorbası", 1, new CategoryManger().search(1)));
            products.Add(new Product(4, "Et Döner", 2, new CategoryManger().search(2)));
            products.Add(new Product(5, "Tavuk Döner", 2, new CategoryManger().search(2)));
            products.Add(new Product(6, "Kuru Fasulye", 2, new CategoryManger().search(2)));
            products.Add(new Product(7, "Halka", 3, new CategoryManger().search(3)));
            products.Add(new Product(8, "Şekerpare", 3, new CategoryManger().search(3)));
            products.Add(new Product(9, "Puding", 3, new CategoryManger().search(3)));
            products.Add(new Product(10, "Su", 4, new CategoryManger().search(4)));
            products.Add(new Product(11, "Ayran", 4, new CategoryManger().search(4)));
            products.Add(new Product(12, "Kola", 4, new CategoryManger().search(4)));
            return products;
        }

        private List<Product> searchCategory(List<Product> list)
        {
            CategoryManger manager = new CategoryManger();

            for (int i = 0; i < list.Count; i++)
            {
                list[i].setCategory(manager.search(list[i].getCategoryId()));
            }
            return list;
        }
    }
}
