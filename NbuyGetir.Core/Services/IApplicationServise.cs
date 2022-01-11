using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Services
{
    /// <summary>
    /// frontend tarafından gelen bir isteğin işlenip frontend tarafına bir sonucun döndürülmesi için yaptık. api de ınput model ve view model yerine artık dto (data transfer object) terimini kullanacağız.buradaki servisi application katmanı için yazıyoruz.
    /// </summary>
    /// <typeparam name="TRequestDto"></typeparam>
    /// <typeparam name="TResultDto"></typeparam>
    public interface IApplicationServise<TRequestDto,TResultDto>
    {
        Task<TResultDto> HandleAsync(TRequestDto dto);
    }
}
