using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data.Task
{
  public  class TaskDetailModel
    {

        public string Content { get; set; }

        public TaskDetailModel() : this("") { }
        public TaskDetailModel(string description)
        {
            Content = description;
        }

        
    }
}
