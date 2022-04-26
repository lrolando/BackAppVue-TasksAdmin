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
        public async Task<List<TaskItem>> SaveNewItem([FromBody] TaskItem value)
        {
            return await _taskRepository.SaveNewItems(value);
        }

        [HttpDelete]
        public async Task<List<TaskItem>> DeleteItem([FromBody] TaskItem value)
        {

            return await _taskRepository.DeleteItems(value);

        }

            
        [HttpPut]
        public async Task<List<List<TaskItem>>> UpdateItem([FromBody] TaskItem value)
        {

            var ListTotal = await _taskRepository.UpdateItems(value);

            List<List<TaskItem>> respList = new List<List<TaskItem>>();
            List<TaskItem> ListP = new List<TaskItem>();
            List<TaskItem> ListC = new List<TaskItem>();

            foreach (var item in ListTotal)
            {
                if (item.Active==true)
                {
                    ListP.Add(item);
                }
                else
                {
                    ListC.Add(item);
                }
            }
            respList.Add(ListP);
            respList.Add(ListC);

            return respList;

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
