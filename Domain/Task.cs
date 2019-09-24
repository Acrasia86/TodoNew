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

        public Task(int id, string title, DateTime dueDate)
        {
            Title = title;
            DueDate = dueDate;
            Id = id;
        }
        
        public int Id { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? Completed { get; set; }
        public string Title { get; set; }

        //public bool IsCompleted
        //{
        //    get
        //    {

        //    return Completed != null;
 
        //    }
        //}
        

    }
}
