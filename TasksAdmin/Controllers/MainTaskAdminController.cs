using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasksAdmin.Business;
using TasksAdmin.DataAccess;
using TasksAdmin.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TasksAdmin.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainTaskAdminController : ControllerBase
    {
        private readonly ITaskRepository<TaskItem> _taskRepository;


        public MainTaskAdminController(ITaskRepository<TaskItem> taskRepository)
        {
            _taskRepository = taskRepository;

        }

        //GET: api/<ValuesController>
        [HttpGet]
        public async Task<List<TaskItem>> GetPendingItems()
        {
            return await _taskRepository.GetItems(true);
        }

        [HttpGet]
        public async Task<List<TaskItem>> GetCompleteItems()
        {
            return await _taskRepository.GetItems(false);
        }

        [HttpPost]
        public void SaveNewItem([FromBody] TaskItem value)
        {
            _taskRepository.SaveNewItems(value);
        }

        [HttpDelete]
        public void DeleteItem([FromBody] TaskItem value)
        {

            _taskRepository.DeleteItems(value);

        }

            
        [HttpPut]
        public void UpdateItem([FromBody] TaskItem value)
        {

            _taskRepository.UpdateItems(value);

        }


        //List<TaskItem> Tasks = new List<TaskItem>()
        //{
        //    new TaskItem() { Id = 1, Description = "Integrar Bootstrap", Active = true},
        //    new TaskItem() { Id = 2, Description = "Cargar horas", Active = true},
        //    new TaskItem() { Id = 3, Description = "hablar con Alex", Active = true},
        //    new TaskItem() { Id = 4, Description = "Onboarding", Active = false},
        //    new TaskItem() { Id = 5, Description = "Instalar Vetur", Active = false},
        //    new TaskItem() { Id = 6, Description = "Leer doc de Vue", Active = false}

        //};
    }
}
