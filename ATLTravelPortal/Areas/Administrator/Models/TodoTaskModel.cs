using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATLTravelPortal.Areas.Administrator.Models
{
    public class TodoTaskModel
    {
        public int userId { get; set; }
        public string taskName { get; set; }
        public string taskDescription { get; set; }
        public DateTime taskDate { get; set; }
        public TimeSpan taskTime { get; set; }
        public bool isComplete { get; set; }
        public DateTime createdDate { get; set; }
        public long taskId { get; set; }
        public IEnumerable<TodoTaskModel> TodoTaskList { get; set; }
    }
}