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
        public void SaveNewItems(TaskItem newItem);

        public void DeleteItems(TaskItem newItem);

        public void UpdateItems(TaskItem newItem);
    }
}
