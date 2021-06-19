using System.Collections.Generic;
using System.Threading.Tasks;
using TodoListApi.Models;
using Microsoft.EntityFrameworkCore;
using Task = TodoListApi.Models.Task;

namespace TodoListApi.Services
{
    public class TodoService : ITodoService
    {
        private readonly TodoListContext _context;
        
        public TodoService(TodoListContext context)
        {
            this._context = context;
        }
        
        public async Task<IEnumerable<Task>> GetAllTask()
        {
            return await this._context.Tasks.ToListAsync();
        }

        public async Task<Task> AddTask(Task task)
        {
            await this._context.Tasks.AddAsync(task);
            await this._context.SaveChangesAsync();
            return task;
        }

        public async Task<Task> UpdateTask(Task task)
        {
            this._context.Attach(task).State = EntityState.Modified;
            await this._context.SaveChangesAsync();
            return task;
        }

        public async Task<Task> DeleteTask(int id)
        {
            var task = await this._context.Tasks
                .FirstOrDefaultAsync(t => t.Id == id);
            this._context.Attach(task).State = EntityState.Deleted;
            await this._context.SaveChangesAsync();
            return task;
        }

        public async Task<Task> UpdateStatusTask(int id)
        {
            var task = await this._context.Tasks
                .FirstOrDefaultAsync(t => t.Id == id);
            
            task.Status = !task.Status;
            this._context.Attach(task).State = EntityState.Modified;
            await this._context.SaveChangesAsync();
            return task;
        }
    }
}