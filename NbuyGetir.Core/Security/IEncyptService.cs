using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Security
{
    public interface IEncyptService
    {
        /// <summary>
        /// MDS ile veya SHA,DES,3DES gibi algoritmalar ile şifreleme işlemleri yapan bir servis olarak kullanaılabilir. MD5 hash algoritması geri cevrilemez.
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        string Encrypt(string plainText);
    }
}
