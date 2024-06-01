using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Model;
using Models;
using Models.Data;
using Services;

namespace home_assignment.Controllers
{
    [ApiController]
    [Route("[controller]")]


    public class TagsController(IMapper mapper, ITagsService tagService) : ControllerBase
    {
        private readonly ITagsService _tagsService = tagService;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tag>>> Get()
        {
            var tags = await _tagsService.GetTagsAsync();
            return Ok(tags);
        }


        [HttpPost]
        public async Task<ActionResult<Tag>> Post(TagRequestDto tag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var innerTagRequest = _mapper.Map<Tag>(tag);

            var result = await _tagsService.CreateTagAsync(innerTagRequest);
            return StatusCode(201, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TaskRequestDto tag)
        {


            if (!ModelState.IsValid || id < 0)
            {
                return BadRequest();
            }
            var innerTagRequest = _mapper.Map<Tag>(tag);

            var result = await _tagsService.UpdateTagAsync(id, innerTagRequest);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _tagsService.DeleteTagAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }


    }
}
