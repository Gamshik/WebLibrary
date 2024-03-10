using Domain.Classes.Entities;
using FluentValidation;

namespace Domain.Classes.FluentValidation.Config
{
    public class BookPreviewValidator : AbstractValidator<BookPreview>
    {
        public BookPreviewValidator()
        {
            RuleFor(b => b.Title)
                .NotEmpty().WithMessage("Book title is required!")
                .MinimumLength(4).WithMessage("Book title can not be less than 4 symbols!");

            RuleFor(b => b.Cover)
                .NotEmpty().WithMessage("Cover is required!");

            RuleFor(b => b.Author)
                .NotEmpty().WithMessage("Author is required!")
                .MinimumLength(5).WithMessage("Author name can not be less than 5 symbols!");
        }
    }
}
