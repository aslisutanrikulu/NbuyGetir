using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Security
{
    public interface IDecryptService
    {
        /// <summary>
        /// byte olarak sirfrelenmiş datayı byte[] olarak şifresi çözülmüş şekilde geriye döndürebiliriz.
        /// </summary>
        /// <param name="chiper"></param>
        /// <returns></returns>
        byte[] Decrypt(byte[] chiper);
    }
}
