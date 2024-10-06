using System;
using ToDoListApp.Models;

namespace ToDoListApp.Managers
{
    public class MenuManager
    {
        private ToDoList todo;

        public MenuManager()
        {
            todo = new ToDoList(); // Initialize ToDoList
        }

        public void DisplayMenu()
        {
            while (true)
            {
                Console.WriteLine("\nTo Do List App");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. Remove Task");
                Console.WriteLine("3. View Task List");
                Console.WriteLine("4. Clear Task List");
                Console.WriteLine("5. Update Task IDs");
                Console.WriteLine("0. Exit");
                Console.Write("Select an option (0-5): ");
                
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Write("Enter task description: ");
                        string description = Console.ReadLine();
                        Console.Write("Enter due date (MM/DD/YYYY): ");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime dueDate))
                        {
                            todo.AddTask(description, dueDate);
                        }
                        else
                        {
                            Console.WriteLine("Invalid date format. Task not added.");
                        }
                        break;
                    case "2":
                        Console.Write("Enter task ID to remove: ");
                        if (int.TryParse(Console.ReadLine(), out int removeId))
                        {
                            todo.RemoveTask(removeId);
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID.");
                        }
                        break;
                    case "3":
                        var tasks = todo.ViewTasks();
                        foreach (var task in tasks)
                        {
                            Console.WriteLine(task);
                        }
                        break;
                    case "4":
                        todo.RemoveAllTasks();
                        break;
                    case "5":
                        todo.UpdateTaskIds();
                        Console.WriteLine("Task IDs updated.");
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}
