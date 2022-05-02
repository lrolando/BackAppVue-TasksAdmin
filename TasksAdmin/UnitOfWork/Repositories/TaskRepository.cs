using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TasksAdmin.Models;
using TasksAdmin.UnitOfWork;

namespace TasksAdmin.DataAccess
{
    public class TaskRepository : ITaskRepository<TaskItem>
    {

        private readonly TasksManager_DBContext _tasksManager_DBContext;

        public TaskRepository(TasksManager_DBContext tasksManager_DBContext)
        {

            _tasksManager_DBContext = tasksManager_DBContext;

        }

        public async Task<List<TaskItem>> GetItems() 
        {
            List<TaskItem> ListTI = null;

            ListTI = await (from a in _tasksManager_DBContext.Tasks 
                            select a).ToListAsync();

            return ListTI;
        }

       
        public async Task<TaskItem> SaveNewItems(TaskItem newItem)
        {
            var nI = new TaskItem()
            { Description = newItem.Description, 
              Active = true};
            _tasksManager_DBContext.Tasks.Add(nI);
            _tasksManager_DBContext.SaveChanges();
            var nItem = nI.Id;

            return nI;
        }

        public void DeleteItems(TaskItem Item)
        {
            _tasksManager_DBContext.Tasks.Remove(Item);
            _tasksManager_DBContext.SaveChanges();

        }


        public void UpdateItems(TaskItem Item)
        {

            var itemUpdated = _tasksManager_DBContext.Tasks.Single(x => x.Id == Item.Id);

            bool IsActive = Item.Active == true ? false : true;

            itemUpdated.Active = IsActive;

            _tasksManager_DBContext.SaveChanges();

        }
    }
}
