using AutoMapper;
using Models;
using Models.Data;

namespace Common
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<TaskRequestDto, UserTask>();
              
            //.ForPath(empmodel => empmodel.Schedule.PlannedStartDate, empdto => empdto.MapFrom(x => x.PlannedStartDate))
            //.ForPath(empmodel => empmodel.Schedule.PlannedEndDate, empdto => empdto.MapFrom(x => x.PlannedEndDate))
            // .ForMember(empmodel => empmodel.Tags, opt => opt.MapFrom(src => src.Tags.Select(tag => new Tag { Name = tag })));

            CreateMap<UserTask, TaskResponseDto>();
            // .ForPath(empmodel => empmodel.PlannedStartDate, empdto => empdto.MapFrom(x => x.Schedule.PlannedStartDate))
            // .ForPath(empmodel => empmodel.PlannedEndDate, empdto => empdto.MapFrom(x => x.Schedule.PlannedEndDate));

            CreateMap<TagRequestDto, Tag>();

            CreateMap<Tag?, TagResponse>();
                



        }
    }
}
