using Domain.Classes.Entities;
using FluentValidation;

namespace Domain.Classes.FluentValidation.Config
{
    public class TextOfBookValidator : AbstractValidator<TextOfBook>
    {
        public TextOfBookValidator()
        {
            RuleFor(t => t.BookId)
                .NotEmpty().WithMessage("Book id is required!");

            RuleFor(t => t.Text)
                .NotEmpty().WithMessage("Text of book is required!");
        }
    }
}
