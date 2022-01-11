using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Notifications
{
    public class EmailAttachement
    {
        /// <summary>
        /// base 64 formatında veri resim, excel, word dosyası olabilir.
        /// </summary>
        public string Base64 { get; set; }
        /// <summary>
        /// dosya byte olarakta email saf halinde gönderilebilir.
        /// </summary>
        public byte[] File { get; set; }

    }
    public interface IEmailSender
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="to"></param> aralarında , olarak tek bir string ile birden fazla kişiye mail atılabilir. sutanrıkuluasli@gmail.com, samet@gmail.com
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <param name="cc"></param> aralarına , konularak birden fazla kişi cc eklenebilir.
        /// <param name="emailAttachements"></param>
        /// <returns></returns>
        Task SenderSingleEmailAsync(string to, string subject, string message, string cc,List<EmailAttachement> emailAttachements=null);
    }
}
