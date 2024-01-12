using AutoMapper;
using DotnetBootcampProject.Core.DTOs;
using DotnetBootcampProject.Core.Models;
using DotnetBootcampProject.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotnetBootcampProject.API.Controllers
{
    public class BookController : CustomBaseController
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BookController(IBookService bookService,IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var books = await _bookService.GetAllAsync();
            var booksDto = _mapper.Map<List<BookDto>>(books.ToList());
            return CreateActionResult(GlobalResultDto<List<BookDto>>.Success(200, booksDto));

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _bookService.GetById(id);
            var bookDto = _mapper.Map<BookDto>(book);
            return CreateActionResult(GlobalResultDto<BookDto>.Success(200, bookDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(BookDto bookDto)
        {
            var book =await _bookService.AddAsync(_mapper.Map<Book>(bookDto));
            var bookDtos = _mapper.Map<BookDto>(book);
            return CreateActionResult(GlobalResultDto<BookDto>.Success(201, bookDtos));
        }

        [HttpPut]
        public async Task<IActionResult> Update(BookDto bookDto)
        {
            await _bookService.UpdateAsync(_mapper.Map<Book>(bookDto));
            return CreateActionResult(GlobalResultDto<NoContentDto>.Success(204));
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(int id)
        {
            var book = await _bookService.GetById(id);
            await _bookService.RemoveAsync(book);
            return CreateActionResult(GlobalResultDto<NoContentDto>.Success(204));
        }

    }
}