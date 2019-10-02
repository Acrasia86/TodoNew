using System;
using System.Data.SqlClient;
using TodoNew.Domain;

namespace TodoNew
{

    class Program
    {
        //3 delar: adress till instans ; databasnamn ; authenisering sepereras med ;
        static int id = 1;
        static string connectionString = "Server = (local); Database = Todos; Integrated Security = true";

        static void Main(string[] args)
        {

            bool shouldNotExit = true;

            while (shouldNotExit)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.Clear();
                Console.WriteLine("1. Add todo");
                Console.WriteLine("2. List todo");
                Console.WriteLine("3. Exit");

                int userInput = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (userInput)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("Title: ");
                        string title = Console.ReadLine();

                        Console.Write("Due date (yyyy-mm-dd hh:mm): ");
                        DateTime dueDate = DateTime.Parse(Console.ReadLine());

                        CreateTask(title, dueDate);

                        break;


                    case 2:

                        var taskss = FetchAllTasks();

                        foreach (var todos in taskss)
                        {
                            if (todos != null)
                            {
                                Console.WriteLine($"Id: {todos.Id}\nTitle: {todos.Title}\nDue date: {todos.DueDate}\nCompleted on: {todos.Completed}.\n");
                            }
                        }

                        ConsoleKeyInfo keyPress = Console.ReadKey(true);

                        break;
                    case 3:
                        shouldNotExit = false;
                        break;

                }


            }

        }

        private static Task[] FetchAllTasks()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string sql = @"SELECT [Id]
                        ,[Title]
                        ,[DueDate]
                        ,[Completed]
                         FROM Todotable"
                        ;

            SqlCommand command = new SqlCommand(sql, connection);

            connection.Open();

            //Skickar SQL kommando till server
            SqlDataReader dataReader = command.ExecuteReader();

            while(dataReader.Read())
            {
                string id = dataReader["Id"].ToString();
                string title = dataReader["Title"].ToString();
                string dueDate = dataReader["DueDate"].ToString();
                string completed = dataReader["Completed"].ToString();

                Console.Write(id.PadRight(5, ' '));
                Console.Write(title.PadRight(20, ' '));
                Console.Write(dueDate.PadRight(12, ' '));
                Console.WriteLine(completed);

            }



            Console.WriteLine("Succefully connected to datebase manager instance");

            connection.Close();

            return new Task[100];
        }

        private static void CreateTask(string title, DateTime dueDate)
        {
            Task[] taskList = FetchAllTasks();

            taskList[GetIndexPosition()] = new Task(id++, title, dueDate);

        }

        static int GetIndexPosition()
        {
            Task[] taskList = FetchAllTasks();

            int result = -1;
            for (int i = 0; i < taskList.Length; i++)
            {
                if (taskList[i] != null)
                {
                    continue;
                }
                if (taskList[i] == null)
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


