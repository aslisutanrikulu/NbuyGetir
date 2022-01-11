using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Exceptions
{
    public static class ExceptionCodes
    {
        public const string UserNotFound = "1001";
        public const string OrderRejected = "2001";
        public const string AccountDenied = "3001";
    }
    public abstract class ExceptionBase: Exception
    {
        public string ErrorCode { get; private set; }
        /// <summary>
        /// bir hata durumunda hata ile ilgili bir class açıp mesaj ve errorCode bilgisini constructor ile belirtiyoruz.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="errorCode"></param>
        public ExceptionBase (string message, string errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
