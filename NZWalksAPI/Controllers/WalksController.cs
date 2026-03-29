using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Repositories;
using NZWalksAPI.Models;
using NZWalksAPI.Models.DTO;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IWalkRepository _walkRepository;
        private readonly IMapper _mapper;

        public WalksController(IWalkRepository walkRepository, IMapper mapper)
        {
            _walkRepository = walkRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWalks()
        {
            IEnumerable<Walk> walks = await _walkRepository.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<WalkDto>>(walks));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetWalkById([FromRoute] Guid id)
        {
            Walk? walk = await _walkRepository.GetByIdAsync(id);
            if (walk == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<WalkDto>(walk));
        }

        [HttpPost]
        public async Task<IActionResult> CreateWalk([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            // Convert DTO to domain model
            Walk? walk = _mapper.Map<Walk>(addWalkRequestDto);

            // Pass details to repository
            walk = await _walkRepository.CreateAsync(walk);

            if (walk == null)
                return BadRequest();

            // Convert back to DTO
            WalkDto walkDto = _mapper.Map<WalkDto>(walk);

            return StatusCode(StatusCodes.Status201Created, $"Walk created with id: {walkDto.Id}");
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateRegionByID([FromRoute] Guid id, [FromBody] UpdateWalkRequestDto updateWalkRequestDto)
        {
            //DTO -> Model
            Walk? walk = _mapper.Map<Walk>(updateWalkRequestDto);

            //pass details to repository
            walk = await _walkRepository.UpdateByIdAsync(id, walk);

            if (walk == null)
                return NotFound();

            //Model -> DTO
            WalkDto walkDto = _mapper.Map<WalkDto>(walk);

            return StatusCode(StatusCodes.Status200OK, walkDto);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteWalkByID([FromRoute] Guid id)
        {
            Walk? walk = await _walkRepository.DeleteAsync(id);
            if (walk == null)
                return NotFound();
            return Ok(_mapper.Map<WalkDto>(walk));
        }
    }
}
