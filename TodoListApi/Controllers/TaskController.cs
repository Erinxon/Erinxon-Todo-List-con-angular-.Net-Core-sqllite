using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TodoListApi.Dtos;
using TodoListApi.Response;
using TodoListApi.Services;
using Task = TodoListApi.Models.Task;

namespace TodoListApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITodoService _todoService;
        private readonly IMapper _mapper;
        
        public TaskController(ITodoService todoService, IMapper mapper)
        {
            this._todoService = todoService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<TaskDto>>>> Get()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<TaskDto>>();
            try
            {
                var tasks = await this._todoService.GetAllTask();
                serviceResponse.Data = _mapper.Map<List<TaskDto>>(tasks);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return Ok(serviceResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TaskDto>>> Insert([FromBody] AddTaskDto addTaskDto)
        {
            var serviceResponse = new ServiceResponse<TaskDto>();
            try
            {
                var task = _mapper.Map<Task>(addTaskDto);
                task.Status = false;
                var result = await this._todoService.AddTask(task);
                serviceResponse.Data = _mapper.Map<TaskDto>(result);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return Ok(serviceResponse);
        }
        
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<TaskDto>>> Update([FromBody] TaskDto taskDto)
        {
            var serviceResponse = new ServiceResponse<TaskDto>();
            try
            {
                var task = _mapper.Map<Task>(taskDto);
                var result = await this._todoService.UpdateTask(task);
                serviceResponse.Data = _mapper.Map<TaskDto>(result);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return Ok(serviceResponse);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<TaskDto>>> Delete(int id)
        {
            var serviceResponse = new ServiceResponse<TaskDto>();
            try
            {
                var result = await this._todoService.DeleteTask(id);
                serviceResponse.Data = _mapper.Map<TaskDto>(result);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return Ok(serviceResponse);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<TaskDto>>> UpdateStatusTask(int id)
        {
            var serviceResponse = new ServiceResponse<TaskDto>();
            try
            {
                var result = await this._todoService.UpdateStatusTask(id);
                serviceResponse.Data = _mapper.Map<TaskDto>(result);
               
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return Ok(serviceResponse);
        }
    }
}