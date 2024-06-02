using Common;
using Common.Enums;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace home_assignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController(ITasksService tasksService) : ControllerBase
    {
        private readonly ITasksService _tasksService = tasksService;

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<TaskResponseDto>>> GetAllTasks([FromQuery] string type = "0")
        {
            try
            {
                Enum.TryParse(type, out E_TaskType taskType);
                var tasks = await _tasksService.GetTasksAsync(taskType);
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TaskResponseDto>> GetTaskById(int id)
        {
            try
            {
                var task = await _tasksService.GetTaskByIdAsync(id);
                if (task == null)
                {
                    return BadRequest("Task with the requested id wasn't found");
                }
                return Ok(task);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message );
            }
        }

        [HttpPost]
        public async Task<ActionResult<TaskResponseDto>> Post(TaskRequestDto task)
        {
            try
            {
                var userTask = Utils.ConvertToInnerRequest(task);
                var createdTask = await _tasksService.CreateTaskAsync(userTask, task.Tags);
                return StatusCode(201, createdTask);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TaskRequestDto taskDto)
        {
            try
            {
                if (id < 0)
                {
                    return BadRequest();
                }

                taskDto.Id = id;

                var task = Utils.ConvertToInnerRequest(taskDto);
                var result = await _tasksService.UpdateTaskAsync(task);

                if (!result)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message );
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _tasksService.DeleteTaskAsync(id);
                if (!result)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message );
            }
        }
    }
}