using Contracts;
using Entities;
using FluentValidation;
using WebApi.BLL.Services.ValidationServices.Extensions;

namespace WebApi.BLL.Services.ValidationServices
{
    public class BookEntitiesValidationService : IBookEntitiesValidationService
    {
        private readonly IValidator<BookPreview> _bookPreviewValidator;
        private readonly IValidator<TextOfBook> _textOfBookValidator;
        public BookEntitiesValidationService(IValidator<BookPreview> bookPreviewValidator, IValidator<TextOfBook> textOfBookValidator)
        {
            _bookPreviewValidator = bookPreviewValidator;
            _textOfBookValidator = textOfBookValidator;
        }
        public Result BookPreviewValidate(BookPreview bookPreview)
        {
            var result = _bookPreviewValidator.Validate(bookPreview);

            if (result.IsValid)
                return new Result { IsSuccess = true };

            return new Result { IsSuccess = false, StatusCode = 400, Message = result.ErrorsToString() };
        }

        public Result TextOfBookValidate(TextOfBook textOfBook)
        {
            var result = _textOfBookValidator.Validate(textOfBook);

            if (result.IsValid)
                return new Result { IsSuccess = true };

            return new Result { IsSuccess = false, StatusCode = 400, Message = result.ErrorsToString() };
        }
    }
}
