using AutoMapper;
using TodoListApi.Dtos;
using TodoListApi.Models;

namespace TodoListApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Task, TaskDto>();
            CreateMap<Task, AddTaskDto>().ReverseMap();
            CreateMap<TaskDto, Task>();
        }
    }
}