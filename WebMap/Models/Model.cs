using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMap.Models
{
    public class Model
    {
        public IEnumerable<TasksModels> tasks { get; set; }
        public TasksModels task { get; set; }

    }
}