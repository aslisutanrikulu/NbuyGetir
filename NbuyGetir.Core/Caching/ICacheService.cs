using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Caching
{
    public class CacheData<T>
    {
        public string Key { get; set; } //cachelenecek veri için bir key değeri tutuyoruz bu key değeri üzerinden bu data bilgimize ulaşacağız.
        public List<T> Data { get; set; } //liste halinde json[] olarak buraya data set edeceğiz.
    }
    /// <summary>
    /// Getir uygulamasındaki kategorileri ve bu kategorilere ait alt kategori bilgisini cacheden yani ram üzerinden okuyacağız. böylece her seferinde dbden çekmediğimiz için daha hızlı bir sonuc döndüreceğiz. Bu gibi cok fazla crud operastonun yapılmadıgı sınıflarımızı ramden okuyabiliriz.Aynı zamanda sepet gibi işlemler içinde tanımlanabilir.Çok fazla insert update işlemi olmayan verilerimiz için cache mekanizması kullanırız.
    /// </summary>
    public interface ICacheService<TResult> where TResult:class
    {
        /// <summary>
        /// veriyi ramde tutarken key bilgisi üzerinden sistemde tutacağız.
        /// </summary>
        /// <param name="cacheData"></param>
        void SetCache(string key,TResult cacheData);
        /// <summary>
        /// ilgili ramde cachedeki dataya set ederken verdiğimiz key üzerinden erişiş json formatında deserialize edilmiş veriye ulaşacağız.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        TResult GetFromData(string key);
    }
}
