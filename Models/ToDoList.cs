using System;
using System.Collections.Generic;
using System.Linq;

namespace ToDoListApp.Models
{
    public class ToDoList
    {
        private List<Task> tasks;
        private int nextId; 

        public ToDoList()
        {
            tasks = new List<Task>();
            nextId = 1; 
        }

        // Adds a new task
        public void AddTask(string description, DateTime dueDate)
        { 
            // Add Task to tasks List
            Task newTask = new Task { Id = nextId++, Description = description, DueDate = dueDate };
            tasks.Add(newTask);

            // Print task added
            Console.WriteLine($"Task added: [{newTask.Id}] {newTask.Description} (Due: {newTask.DueDate.ToShortDateString()})");
        }

        // Removes a task by ID
        public void RemoveTask(int id)
{
            Task? taskToRemove = null;

            // Find task with correct id
            foreach (var task in tasks)
            {
                if (task.Id == id)
                {
                    taskToRemove = task;
                    break; 
                }
            }
            
            if (taskToRemove != null)
            {
                tasks.Remove(taskToRemove);
                Console.WriteLine($"Task with ID {id} removed.");
            }
            else
            {
                Console.WriteLine($"Task with ID {id} not found.");
            }
        }


        // View all tasks
        public List<string> ViewTasks()
        {
            // No tasks
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks available.");
                return new List<string>();
            }

            // Get task descriptions
            List<string> taskDescriptions = new List<string>();

            foreach (var task in tasks)
            {
                string taskDescription = $"[{task.Id}] {task.Description} (Due: {task.DueDate.ToShortDateString()})";
                taskDescriptions.Add(taskDescription);
            }

            return taskDescriptions;
        }

        // Remove all tasks
        public void RemoveAllTasks()
        {
            tasks.Clear();
            nextId = 1; // Reset ID counter
            Console.WriteLine("All tasks have been cleared.");
        }

        // Updates the IDs to be sequential again after tasks are removed
        public void UpdateTaskIds()
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                // Reset task based on its current position in list
                // If task is in position 0, the list number is now 1
                tasks[i].Id = i + 1;
            }
            // Get number of tasks and set the nextId to be 1 above that number
            nextId = tasks.Count + 1; 
        }
    }
}
