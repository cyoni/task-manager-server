
using Common.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Models.Data;
using Repositories;
using Services;

namespace Repository
{
    public interface ITaskRepository
    {
        Task<IEnumerable<UserTask>> GetTasksAsync(E_TaskType taskType);
        Task<UserTask?> GetTaskByIdAsync(int id);
        Task<UserTask> CreateTaskAsync(UserTask task, IEnumerable<int> tagIds);
        Task<bool> UpdateTaskAsync(UserTask task);
        Task<bool> DeleteTaskAsync(int id);

    }
    public class TasksRepository(ILoggerService logger, TaskDbContext context) : ITaskRepository
    {
        private readonly ILoggerService _logger = logger;
        private readonly TaskDbContext _context = context;

        public async Task<IEnumerable<UserTask>> GetTasksAsync(E_TaskType taskType)
        {
            try
            {
                var query = _context.Tasks
                                    .Include(t => t.TaskTags)
                                    .ThenInclude(t => t.Tag)
                                    .AsQueryable();


                if (taskType != 0)
                {
                    query = query.Where(x => x.Status == (int)taskType);
                }


                var tasks = await query.ToListAsync();
                return tasks;
            }
            catch (Exception ex)
            {
                _logger.Log(E_LogLevel.High, "Exception in GetTasksAsync", ex);
                throw;
            }
        }

        public async Task<UserTask?> GetTaskByIdAsync(int id)
        {
            try
            {
                var task = await _context.Tasks.Where(x => x.Id == id).FirstOrDefaultAsync();
                return task;
            }
            catch (Exception ex)
            {
                _logger.Log(E_LogLevel.High, "Exception in GetTaskByIdAsync", ex);
                throw;
            }
        }

        public async Task<UserTask> CreateTaskAsync(UserTask task, IEnumerable<int> tagIds)
        {
            try
            {
                task.CreatedAt = DateTime.Now;
                EntityEntry<UserTask> newTask = _context.Tasks.Add(task);

                await _context.SaveChangesAsync();


                if (tagIds != null && tagIds.Any())
                {
                    task.TaskTags = new List<TaskTag>();
                    foreach (var tagId in tagIds)
                    {
                        task.TaskTags.Add(new TaskTag
                        {
                            TaskId = task.Id,
                            TagId = tagId
                        });
                    }
                }

                await _context.SaveChangesAsync();

                return newTask.Entity;
            }
            catch (Exception ex)
            {
                _logger.Log(E_LogLevel.High, "Exception in CreateTaskAsync", ex);
                throw;
            }
        }

        public async Task<bool> UpdateTaskAsync(UserTask task)
        {
            _context.Entry(task).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.Log(E_LogLevel.High, "Exception in UpdateTaskAsync", ex);
                throw;
            }
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            try
            {
                var task = await _context.Tasks.FindAsync(id);
                if (task == null)
                {
                    return false;
                }

                _context.Tasks.Remove(task);

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.Log(E_LogLevel.High, "Exception in DeleteTaskAsync", ex);
                throw;
            }
        }

    }

}