using Models;
using Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Utils
    {
        public static UserTask ConvertToInnerRequest(TaskRequestDto taskRequestDto)
        {
            var userTask = new UserTask
            {
                Id = taskRequestDto.Id,
                Title = taskRequestDto.Title,
                Description = taskRequestDto.Description,
                PlannedStartDate = taskRequestDto.PlannedStartDate,
                PlannedEndDate = taskRequestDto.PlannedEndDate,
                Priority = taskRequestDto.Priority,
                Status = taskRequestDto.Status,

            };
            return userTask;
        }


        public static List<TaskResponseDto> ConvertToResponse(List<UserTask> tasks)
        {
            if (tasks == null) return null;
            var result =  tasks.Select(t => new TaskResponseDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    Priority = t.Priority,
                    Status = t.Status,
                    PlannedStartDate = t.PlannedStartDate,
                    PlannedEndDate = t.PlannedEndDate,
                    Description = t.Description,
                    Tags = t.TaskTags?.Select(tag => new TagResponse
                    {
                        Id = tag.TagId,
                        Name = tag.Tag.Name
                    })
                }).ToList();

            return result;
        }


    }
}