using Domain.Classes.Entities;

namespace Domain.Interfaces
{
    public interface IBookEntitiesValidationService
    {
        Result BookPreviewValidate(BookPreview bookPreview);
        Result TextOfBookValidate(TextOfBook textOfBook);
    }
}
