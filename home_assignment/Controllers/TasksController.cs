using AutoMapper;
using Common;
using Microsoft.AspNetCore.Mvc;
using Model;
using Models;
using Models.Data;
using Services;

namespace home_assignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController(IMapper mapper, ITasksService tasksService) : ControllerBase
    {
        private readonly IMapper _mapper = mapper;
        private readonly ITasksService _tasksService = tasksService;

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<TaskResponseDto>>> GetAllTasks([FromQuery] string type = "0")
        {

            Enum.TryParse(type, out E_TaskType taskType);
            
            var tasks = await _tasksService.GetTasksAsync(taskType);

            //_mapper.Map<IEnumerable<TaskResponseDto>>(tasks);
            //var result = _mapper.Map<IEnumerable<TaskResponseDto>>(tasks);

            return Ok(tasks);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TaskResponseDto>> GetTaskById([FromQuery] int id)
        {
            var task = await _tasksService.GetTaskByIdAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<TaskResponseDto>> Post(TaskRequestDto task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            var userTask = Utils.ConvertToInnerRequest(task); // _mapper.Map<UserTask>(task);

            var createdTask = await _tasksService.CreateTaskAsync(userTask, task.Tags);
            return StatusCode(201, createdTask);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TaskRequestDto task)
        {


            if (!ModelState.IsValid || id < 0)
            {
                return BadRequest();
            }
            var userTask = _mapper.Map<UserTask>(task);
            var result = await _tasksService.UpdateTaskAsync(userTask);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _tasksService.DeleteTaskAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }


    }
}
