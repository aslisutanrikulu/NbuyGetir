using NbuyGetir.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Domain.Models
{
    public class Product: AuditableEntity
    {

        public string Name { get; set; }
        public decimal UnitPrice { get; set; }//alış fiyatı
        public decimal ListPrice { get; set; } //satış fiyatı
        public double DiscountAmount { get; private set; } = 0;
        public int Stock { get; set; } // current stok
        public string Description { get; set; } // 1lt 2kg 30cc gibi açıklamalar olacak.
        public decimal DiscountedListPrice { get; set; } // indirimli fiyat
        public string PictureUrl { get; private set; }
        public bool IsDiscounted {
            get
            {
                return DiscountedListPrice < ListPrice ? true : false;            
            }
                }
        public bool IsStockInCriticalLevel
        {
            get
            {
                return Stock < 10 ? true : false;
            }
        }
        public Product(string name, decimal unitPrice, decimal listPrice,decimal discountedListPrice, int stock, string description, string pictureUrl)
        {
            SetName(name);
            SetPrice(unitPrice, ListPrice, discountedListPrice);
            SetDescription(description);
            SetStock(stock);
        }
        /// <summary>
        /// hem kayıt hemde güncelleme işleminde kullanılacağı için public yapıldı.
        /// eğer boş ise default ürüne ait bir url verelim.
        /// </summary>
        /// <param name="pictureUrl"></param>
        public void SetPictureUrl(string pictureUrl)
        {
            if (!UrlHelper.IsUrl(pictureUrl))
            {
                throw new Exception("resim yolu url formatında değildir.");
            }
            if (string.IsNullOrEmpty(pictureUrl)) 
            {
                pictureUrl = "default-product.jpeg";
            }
            pictureUrl = pictureUrl.Trim();
        }
        /// <summary>
        /// ilk kayıt işlemi sadece stok değeri formdan alınırken kullanılacağı iççin private yaptık diğer tüm stock işlemri de stockIn  ve stockOut operasyonlarını kullanacağız.
        /// </summary>
        /// <param name="stock"></param>
        private void SetStock(int stock)
        {
            if(stock < 0)
            {
                throw new Exception("stok değeri sıfırdan küçük olamaz");
            }
            Stock = stock;
        }
        public void StockIn(int quantity)
        {
            if(quantity <= 0)
            {
                throw new Exception("stoğa girilecek yeni ürün adeti 0 ve daha küçük olamaz");
            }
            Stock += quantity; //stoğa ürün girildi eventi fırlatalım
        }
        public void stockOut(int quantity)
        {
            if (IsStockInCriticalLevel)
            {
                //kritik stok seviyesindeki bir ürün sipariş edildi diye bir mesaj atalım.
            }
        }
        public void SetDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                throw new Exception("ürün açıklama alanı boş geçilemez.");
            }
            if(description.Length > 50)
            {
                throw new Exception("ürün açılaması 50 karakterden fazla girilemez");
            }
            Description = description.Trim();
        }
        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("ürün ismi boş geçilemez.");
            }
            Name = name.Trim();
        }
        public void SetPrice(decimal unitPrice, decimal listPrice, decimal discountedListPrice)
        {
            if(UnitPrice > listPrice)
            {
                throw new Exception("birim fiyat liste fiyatından büyük olamaz");
            }
            if(UnitPrice <= 0 || listPrice <= 0)
            {
                throw new Exception("ürün birim fiyatı veya ürün satış fiyatı negatif ve 0 verilemez");
            }
            if(discountedListPrice > listPrice)
            {
                throw new Exception("indirimli satış fiyatı satış fiyatından büyük olamaz");
            }
            if(discountedListPrice < unitPrice)
            {
                throw new Exception("indirimli satış fiyatı birim fiyattan küçük olamaz");
            }
            ListPrice = listPrice;
            UnitPrice = unitPrice;
            DiscountedListPrice = discountedListPrice;
        }
        /// <summary>
        /// bu method ile bir ürünün satış fiyatına belirli bir oranda indirim yapılır. İndirim oranı güncellenir ve sadece program tarafında DiscountListPrice tutacağız bu indirimli fiyatımız olacaktır. 11 unitprice 13 listprice 12.67 discountprice
        /// </summary>
        /// <param name="discountAmount"></param>
        public void DecreasePrice(decimal newPrice)
        {
            if(newPrice > ListPrice)
            {
                throw new Exception("indirimli fiyat liste fiyatından büyük olamaz");
            }
            
            if(newPrice <= UnitPrice)
            {
                throw new Exception("indirimli fiyat birim fiyatından küçük olamaz.");
            }

            DiscountedListPrice = newPrice;
        }
        public void IncreasePrice(decimal newListPrice, decimal newDiscountedListPrice)
        {
            if(newListPrice < ListPrice)
            {
                throw new Exception("yeni zamlanmış fiyat liste fıyatindan kücük olamaz");
            }
            if(newDiscountedListPrice > newListPrice)
            {
                throw new Exception("indirimli fiyat yeni liste fiyatından büyük olamaz.");
            }
            ListPrice = newListPrice;
            DiscountedListPrice = newDiscountedListPrice;
            // zamlı ürünleri event olarak fırlatabiliriz.
        }
    }
}
