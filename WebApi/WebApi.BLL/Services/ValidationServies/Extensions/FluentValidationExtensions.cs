using FluentValidation.Results;
using System.Text;

namespace WebApi.BLL.Services.ValidationServices.Extensions
{
    public static class FluentValidationExtensions
    {
        public static string ErrorsToString(this ValidationResult validationResult)
        {
            StringBuilder builder = new StringBuilder();
            validationResult.Errors.ForEach(e => builder.Append($"{e.ErrorMessage} "));
            return builder.ToString();
        }
    }
}
