using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasksAdmin.Models;

namespace TasksAdmin.DataAccess
{
    public interface ITaskRepository<T>
    {
        public Task<List<T>> GetItems();

        //public Task<List<T>> GetCompleteItems(Boolean IsActive);
        public Task<TaskItem> SaveNewItems(TaskItem newItem);

        public void DeleteItems(TaskItem newItem);

        public void UpdateItems(TaskItem newItem);
    }
}
