
using AutoMapper;
using Common;
using Common.Enums;
using Models;
using Models.Data;
using Repository;

namespace Services
{
    public interface ITasksService
    {
        Task<IEnumerable<TaskResponseDto>> GetTasksAsync(E_TaskType taskType);
        Task<TaskResponseDto?> GetTaskByIdAsync(int id);
        Task<TaskResponseDto> CreateTaskAsync(UserTask task, IEnumerable<int> tagIds);
        Task<bool> UpdateTaskAsync(UserTask task);
        Task<bool> DeleteTaskAsync(int id);
    }

    public class TasksService : ITasksService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TasksService(IMapper mapper, ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TaskResponseDto>> GetTasksAsync(E_TaskType taskType)
        {
            var tasks = (await _taskRepository.GetTasksAsync(taskType)).ToList();
            var result = Utils.ConvertToResponse(tasks);
            return result;

        }

        public async Task<TaskResponseDto?> GetTaskByIdAsync(int id)
        {
            var task = await _taskRepository.GetTaskByIdAsync(id);
            if (task == null) 
            { 
                return null; 
            }
            var result = Utils.ConvertToResponse(new List<UserTask> { task });
            return result.FirstOrDefault();
        }

        public async Task<TaskResponseDto> CreateTaskAsync(UserTask task, IEnumerable<int> tagIds)
        {
            var result = await _taskRepository.CreateTaskAsync(task, tagIds);
            return _mapper.Map<TaskResponseDto>(result);
        }

        public async Task<bool> UpdateTaskAsync(UserTask task)
        {
            return await _taskRepository.UpdateTaskAsync(task);
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            return await _taskRepository.DeleteTaskAsync(id);
        }
    }

}