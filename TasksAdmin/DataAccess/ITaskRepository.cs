using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasksAdmin.Models;

namespace TasksAdmin.DataAccess
{
    public interface ITaskRepository<T>
    {
        public Task<List<T>> GetItems(Boolean IsActive);

        //public Task<List<T>> GetCompleteItems(Boolean IsActive);
        public Task<List<T>> SaveNewItems(TaskItem newItem);

        public Task<List<T>> DeleteItems(TaskItem newItem);

        public Task<List<T>> UpdateItems(TaskItem newItem);
    }
}
