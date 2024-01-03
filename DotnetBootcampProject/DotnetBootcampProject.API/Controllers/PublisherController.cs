using AutoMapper;
using DotnetBootcampProject.Core.DTOs;
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

    }
}
