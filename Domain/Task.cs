using System;
using System.Collections.Generic;
using System.Text;

namespace TodoNew.Domain
{
    class Task
    {
        public Task()
        {

        }

        public Task(string title, DateTime dueDate)
        {
            Title = title;
            DueDate = dueDate;
        }

        public string Title { get; set; }
        public DateTime DueDate { get; set; }

        
    }
}
