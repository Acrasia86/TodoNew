using System;

namespace TodoNew
{
    class Program
    {
        static void Main(string[] args)
        {
            bool shouldNotExit = true;

            Console.Clear();

            while (shouldNotExit)
            {
                Console.WriteLine("1. Add todo");
                Console.WriteLine("2. List todo");
                Console.WriteLine("3. Exit");

                int userInput = int.Parse(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        AddTodo();
                        break;
                    case 2:
                        ListTodo();
                        break;
                    case 3:
                        shouldNotExit = false;
                        break;
                }
            }
        }
    }
}
