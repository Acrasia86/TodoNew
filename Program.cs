using System;
using TodoNew.Domain;

namespace TodoNew
{

    class Program
    {
        static Task[] tasks = new Task[100];
        static void Main(string[] args)
        {
            bool shouldNotExit = true;
  
            

            while (shouldNotExit)
            {
                Console.Clear();
                Console.WriteLine("1. Add todo");
                Console.WriteLine("2. List todo");
                Console.WriteLine("3. Exit");

                int userInput = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (userInput)
                {
                    case 1:

                        Console.Write("Title: ");
                        string title = Console.ReadLine();

                        Console.Write("Due date (yyyy-mm-dd-hh:mm): ");
                        DateTime dueDate = DateTime.Parse(Console.ReadLine());

                        tasks[GetIndexPosition()] = new Task(title, dueDate);

                        break;


                    case 2:
                        
                        break;
                    case 3:
                        shouldNotExit = false;
                        break;

                }

                
            }
            
        }


        static int GetIndexPosition()
        {
            int result = -1;
            for (int i = 0; i < tasks.Length; i++)
            {
                if (tasks[i] != null)
                {
                    continue;
                }
                if (tasks[i] == null)
                {
                    result = i;
                    break;
                }
                if (result == -1)
                {
                    throw new Exception("No avalible position");
                }
            }
            return result;
        }
    }
   
}


