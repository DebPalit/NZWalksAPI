using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Models;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Repositories;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegionsAsync()
        {
            IEnumerable<Region> regions = await _regionRepository.GetAllAsync();

            //returning the list of regions to the client
            return Ok(_mapper.Map<IEnumerable<RegionDto>>(regions));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetRegionByIdAsync(Guid id)
        {
            Region? region = await _regionRepository.GetRegionByIdAsync(id);
            if (region == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<RegionDto>(region));
        }
    }
}
