using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Domain.Models
{
    public class Category: Entity
    {
        /// <summary>
        /// ekranda ilk açılışta en üst seviye olan kategorileri listeleyeceğiz. bu üst seviye altına eklenen alt kategorileri ise ürünler ile bağlayacağız. ürünler IsTopLevel olarak işaretlenmemiş  kategorilerin altına girilecektir.
        /// </summary>
        public string Name { get; set; }
        public bool IsTopLevel { get; set; } // en üst seviye kategori mi ?
        private List<Category> _subCategories = new List<Category>();
        public IReadOnlyCollection<Category> SubCategories => _subCategories;
        private List<Product> _products = new List<Product>();
        public IReadOnlyCollection<Product> Products => _products;



        public void AddSubCategory(Category category)
        {
            if (string.IsNullOrEmpty(category.Name))
            {
                throw new Exception("kategori alanı boş geçilemez");
            }
            _subCategories.Add(category);
        }
        public void AddSubProduct(Product product)
        {
            if(!IsTopLevel && _subCategories.Count() == 0)
            {
                //!IsTopLevel  && _subCategories.Count()==0 en alt kategoridir.
                _products.Add(product);
            }
        }
    }
}
