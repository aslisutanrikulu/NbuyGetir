using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Notifications
{
    public interface ISMSSender
    {
        /// <summary>
        /// hangi telefon numarasına hangi mesajı atacağımızı bu servis ile yapacağız. twilio diye bir paket kullanacağız.
        /// </summary>
        /// <param name="PhoneNumber"></param>
        /// <param name="message"></param>
        void SendSmsAsync(string PhoneNumber, string message);
    }
}
