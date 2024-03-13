using AutoMapper;
using Contracts;
using Entities;
using Entities.DTOs.BookDTOs;
using Entities.Parameters;

namespace WebApi.BLL.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly IBookEntitiesValidationService _bookEntitiesValidationService;
        private readonly ILoggerService _loggerService;
        public BookService(IBookRepository bookRepository, IMapper mapper, IBookEntitiesValidationService bookEntitiesValidationService, ILoggerService loggerService)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _bookEntitiesValidationService = bookEntitiesValidationService;
            _loggerService = loggerService;
        }
        public Result CreateBookPreview(BookPreviewCreateDto bookPreviewCreateDto)
        {
            var bookPreview = _mapper.Map<BookPreview>(bookPreviewCreateDto);

            var result = _bookEntitiesValidationService.BookPreviewValidate(bookPreview);

            if (!result.IsSuccess)
            {
                _loggerService.LogInfo($"User entered incorrect data for create book!");
                return result;
            }

            _bookRepository.CreateBookPreview(bookPreview);

            return new Result { IsSuccess = true, StatusCode = 201, Message = $"Book - {bookPreview.Title} had been created!" };
        }
        public Result CreateTextOfBook(TextOfBookCreateDto textOfBookCreateDto)
        {
            var textOfBook = _mapper.Map<TextOfBook>(textOfBookCreateDto);

            var result = _bookEntitiesValidationService.TextOfBookValidate(textOfBook);

            if (!result.IsSuccess)
            {
                _loggerService.LogInfo($"User entered incorrect data for create text of book!");
                return result;
            }

            _bookRepository.CreateTextOfBook(textOfBook);

            return new Result { IsSuccess = true, StatusCode = 201, Message = $"Text for book with id = {textOfBook.BookId} had been created!" };
        }
        public Dictionary<int, BookPreviewDto> GetAllBookPreviews()
        {
            var booksPreviews = _bookRepository.GetAllBookPreviews();

            var titleBook = new Dictionary<int, BookPreviewDto>();

            foreach (var bookPreview in booksPreviews)
            {
                var bookPreviewDto = _mapper.Map<BookPreviewDto>(bookPreview);

                titleBook.Add(bookPreview.Id, bookPreviewDto);
            }

            return titleBook;
        }
        public PagedList<char> GetTextOfPage(int bookId, PagingParameters parameters)
        {
            var textOfBook = _bookRepository.GetTextOfBook(bookId);

            if (textOfBook == null)
                return PagedList<char>.ToPagedList([], 0, 0);

            var textOfPage = PagedList<char>.ToPagedList(textOfBook.Text.ToList(), parameters.PageNumber, parameters.PageSize);

            return textOfPage;
        }
    }
}