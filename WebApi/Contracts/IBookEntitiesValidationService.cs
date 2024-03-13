using Entities;

namespace Contracts
{
    public interface IBookEntitiesValidationService
    {
        Result BookPreviewValidate(BookPreview bookPreview);
        Result TextOfBookValidate(TextOfBook textOfBook);
    }
}
