using System;
using ToDoListApp.Managers;

namespace ToDoListApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuManager menuManager = new MenuManager();
            menuManager.DisplayMenu();
        }
    }
}
