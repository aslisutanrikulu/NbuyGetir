using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Authorization
{
    /// <summary>
    /// bu servis ile sistemdeki kullanıcının ilgili kaynağa erişimine yetkisi olup olmadıgını kontrol edeceğiz. claim ve role bazlı kontrolleri içerisinde yapacağız.
    /// </summary>
    public interface IAuthorizationService
    {
        /// <summary>
        /// Sistemde oturum açan kullanıcının sistemdeki özel kaynaklara yetkisi var mı kontrolü yapacağız. örneğin kargo sorumlusu sadece kargodaki ürünleri görebilecek.
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        bool HasRole(string roleName);
        bool HasRoles(params string[] roleNames);
        bool HasClaim(string claim);
        /// <summary>
        /// claims bilgisini kullanıcıya tanımlanmıs olan ozellikler örn nbuygetir çalışanı mı, indirim ceki tanımlanmıs mı, indirim kupunu var mı gibi vs kullanıcıya tanımlanan extra ozelliklere claim diyeceğiz.
        /// </summary>
        /// <param name="claims"></param>
        /// <returns></returns>
        bool HasClaims(params string[] claims);
    }
}
