using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TasksAdmin.Models
{
    public class TaskItem
    {

        public int Id { get; set; }

        public string Description { get; set; }

        public bool? Active { get; set; }
    }
}
