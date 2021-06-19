using TodoListApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task = TodoListApi.Models.Task;

namespace TodoListApi.Services
{
    public interface ITodoService
    {
        Task<IEnumerable<Task>> GetAllTask();
        Task<Task> AddTask(Task task);
        Task<Task> UpdateTask(Task task);
        Task<Task> DeleteTask(int id);
        Task<Task> UpdateStatusTask(int id);
    }
}