using AutoMapper;
using DotnetBootcampProject.Core.DTOs;
using DotnetBootcampProject.Core.Models;
using DotnetBootcampProject.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotnetBootcampProject.API.Controllers
{
    public class PublisherController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IPublisherService _publisherService;
        public PublisherController(IMapper mapper, IPublisherService publisherService)
        {
            _mapper = mapper;
            _publisherService = publisherService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var publishers = await _publisherService.GetAllAsync();
            var publisherDto = _mapper.Map<List<PublisherDto>>(publishers.ToList());
            return CreateActionResult(GlobalResultDto<List<PublisherDto>>.Success(200, publisherDto));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var publisher = await _publisherService.GetById(id);
            var publisherDto = _mapper.Map<PublisherDto>(publisher);
            return CreateActionResult(GlobalResultDto<PublisherDto>.Success(200, publisherDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(PublisherDto publisherDto)
        {
            var publisher = await _publisherService.AddAsync(_mapper.Map<Publisher>(publisherDto));
            var publisherDtos = _mapper.Map<PublisherDto>(publisher);
            return CreateActionResult(GlobalResultDto<PublisherDto>.Success(201, publisherDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(PublisherDto publisherDto)
        {
            await _publisherService.UpdateAsync(_mapper.Map<Publisher>(publisherDto));
            return CreateActionResult(GlobalResultDto<NoContentDto>.Success(204));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var publisher = await _publisherService.GetById(id);
            await _publisherService.RemoveAsync(publisher);
            return CreateActionResult(GlobalResultDto<NoContentDto>.Success(204));
        }

    }
}
