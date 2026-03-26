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
        public async Task<IActionResult> GetAllRegions()
        {
            IEnumerable<Region> regions = await _regionRepository.GetAllAsync();

            //returning the list of regions to the client
            return Ok(_mapper.Map<IEnumerable<RegionDto>>(regions));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetRegionById([FromRoute] Guid id)
        {
            Region? region = await _regionRepository.GetByIdAsync(id);
            if (region == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<RegionDto>(region));
        }

        [HttpPost]
        public async Task<IActionResult> CreateRegion([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            var RegionNameExits = await _regionRepository.GetByNameAsync(addRegionRequestDto.Name);
            if (RegionNameExits != null)
                return Conflict($"Region with name '{addRegionRequestDto.Name}' already exists.");

            var RegionCodeExits = await _regionRepository.GetByCodeAsync(addRegionRequestDto.Code);
            if (RegionCodeExits != null)
                return Conflict($"Region with code '{addRegionRequestDto.Code}' already exists.");

            // Convert DTO to domain model
            Region? region = _mapper.Map<Region>(addRegionRequestDto);

            // Pass details to repository
            region = await _regionRepository.CreateAsync(region);

            if (region == null)
                return BadRequest();

            // Convert back to DTO
            RegionDto regionDto = _mapper.Map<RegionDto>(region);

            //this gives 500 error in postman, can't fix
            //return CreatedAtAction(nameof(GetRegionByIdAsync), new { id = regionDto.Id }, regionDto);
            return StatusCode(StatusCodes.Status201Created, regionDto);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateRegionByID([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            //DTO -> Model
            Region? region = _mapper.Map<Region>(updateRegionRequestDto);

            //pass details to repository
            region = await _regionRepository.UpdateByIdAsync(id, region);

            if (region == null)
                return NotFound();

            //Model -> DTO
            RegionDto regionDto = _mapper.Map<RegionDto>(region);

            return StatusCode(StatusCodes.Status200OK, regionDto);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteRegionByID([FromRoute] Guid id)
        {
            Region? region = await _regionRepository.DeleteAsync(id);
            if (region == null)
                return NotFound();
            return Ok(_mapper.Map<RegionDto>(region));
        }
    }
}
