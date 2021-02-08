using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerHomework.Shared.Entities.Concrete;
using CustomerHomework.Shared.Utilities.Results.Abstract;
using CustomerHomework.Shared.Utilities.Results.ComplexTypes;
using FluentValidation;


namespace CustomerHomework.Shared
{
    public class ValidationTool
    {
        public static IResult Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                IList<ValidationError> validationErrors = new List<ValidationError>();
                foreach (var error in result.Errors)
                {
                    validationErrors.Add(new ValidationError
                    {
                        PropertyName = error.PropertyName,
                        Message = error.ErrorMessage
                    });
                }

                return new Result(ResultStatus.Error, $"Bir veya daha fazla validasyon hatasına rastlandı.",
                    validationErrors);
            }

            return new Result(ResultStatus.Success);
        }
    }
}
