using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Notifications
{
    public interface IPushNotificationServise
    {
        /// <summary>
        /// mobil uygulamayı bir kullanıcı indirince user hesabında AppId tutacağız.One signal ile kişinin cihazına bildirim göndereceğiz.
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        Task SendPushNotificationAsync(string appId, string message);
    }
}
