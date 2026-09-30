using System;

namespace SolidPrinciples.WithSRP
{
    // Responsible for cooking meals
    class Chef
    {
        public void CookMeals()
        {
            Console.WriteLine("Cooking meals...");
        }
    }

    // Responsible for managing accounting
    class Accountant
    {
        public void ManageAccounting()
        {
            Console.WriteLine("Handling accounting...");
        }
    }

    // Responsible for cleaning tables
    class Cleaner
    {
        public void CleanTables()
        {
            Console.WriteLine("Cleaning tables...");
        }
    }

    // Responsible for taking customer orders
    class OrderTaker
    {
        public void TakeOrders()
        {
            Console.WriteLine("Taking customer orders...");
        }
    }

    // Responsible for serving food
    class Server
    {
        public void ServeFood()
        {
            Console.WriteLine("Serving food...");
        }
    }
}

/* Explanation
 * ------------
 * 1. Each class is responsible for a specific task in the restaurant.
 * 2. Each class has a single responsibility and performs only one job.
 * 3. Each class has only one reason to change.
 * 4. The classes follow the Single Responsibility Principle.
 */

/* Advantages
 * -----------
 * 1. Each class follows the Single Responsibility Principle and has only one reason to change.
 * 2. The classes are loosely coupled and can be modified independently.
 */
