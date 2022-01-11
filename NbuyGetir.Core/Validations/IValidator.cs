using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Validations
{
    public class ProductCreateDto
    {
        public string EmailAddress { get; set; }
    }
    public class ProductCreateValidator : IValidator<ProductCreateDto>
    {
        public ValidationResult ValidationResult { get; set; }
    }

        public void Validate(ProductCreateDto dto)
        {
        if()
            throw new NotImplementedException();
        }
    }


    public interface IValidator<TDto> where  TDto:class
    {
        ValidationResult ValidationResult { get; set; }

        void Validate(TDto dto)
    }
}
