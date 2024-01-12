using AutoMapper;
using DotnetBootcampProject.Core.DTOs;
using DotnetBootcampProject.Core.Models;
using DotnetBootcampProject.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotnetBootcampProject.API.Controllers
{
    public class PublicationInfoController : CustomBaseController
    {
        private readonly IPublicationInfoService _publicationInfoService;
        private readonly IMapper _mapper;

        public PublicationInfoController(IPublicationInfoService publicationInfoService, IMapper mapper)
        {
            _publicationInfoService = publicationInfoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var pubInfo = await _publicationInfoService.GetAllAsync();
            var pubInfoDtos = _mapper.Map<List<PublicationInfoDto>>(pubInfo.ToList());
            return CreateActionResult(GlobalResultDto<List<PublicationInfoDto>>.Success(200, pubInfoDtos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pubInfo = await _publicationInfoService.GetById(id);
            var pubInfoDto = _mapper.Map<PublicationInfoDto>(pubInfo);
            return CreateActionResult(GlobalResultDto<PublicationInfoDto>.Success(200, pubInfoDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(PublicationInfoDto pubInfoDto)
        {
            var pubInfo = await _publicationInfoService.AddAsync(_mapper.Map<PublicationInfo>(pubInfoDto));
            var pubInfoDtos = _mapper.Map<PublicationInfoDto>(pubInfo);
            return CreateActionResult(GlobalResultDto<PublicationInfoDto>.Success(201,pubInfoDtos));
        }
        [HttpPut]
        public async Task<IActionResult> Update(PublicationInfoDto pubInfoDto)
        {
            await _publicationInfoService.UpdateAsync(_mapper.Map<PublicationInfo>(pubInfoDto));
            return CreateActionResult(GlobalResultDto<NoContentDto>.Success(204));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var pubInfo = await _publicationInfoService.GetById(id);
            await _publicationInfoService.RemoveAsync(pubInfo);
            return CreateActionResult(GlobalResultDto<NoContentDto>.Success(204));
        }
    }
}
