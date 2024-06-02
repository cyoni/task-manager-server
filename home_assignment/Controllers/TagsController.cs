using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace home_assignment.Controllers
{
    [ApiController]
    [Route("[controller]")]


    public class TagsController(ITagsService tagService) : ControllerBase
    {
        private readonly ITagsService _tagsService = tagService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TagResponse>>> Get()
        {
            try
            {
                var tags = await _tagsService.GetTagsAsync();
                return Ok(tags);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult<TagResponse>> Post(TagRequestDto tag)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var result = await _tagsService.CreateTagAsync(tag);
                return StatusCode(201, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TagRequestDto tag)
        {

            try
            {
                if (!ModelState.IsValid || id < 0)
                {
                    return BadRequest();
                }

                var result = await _tagsService.UpdateTagAsync(id, tag);
                if (!result)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _tagsService.DeleteTagAsync(id);
                if (!result)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}
