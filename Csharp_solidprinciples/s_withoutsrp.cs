using System;

namespace SolidPrinciples.WithoutSRP
{
    // This class handles all tasks related to a restaurant (violates SRP)
    class RestaurantService
    {
        // This method calls all task-related methods
        public void HandleRestaurantTasks()
        {
            CookMeals();
            ManageAccounting();
            CleanTables();
            TakeOrders();
            ServeFood();
        }

        // Method to cook meals
        private void CookMeals()
        {
            Console.WriteLine("Cooking meals...");
        }

        // Method to manage accounting
        private void ManageAccounting()
        {
            Console.WriteLine("Handling accounting...");
        }

        // Method to clean tables
        private void CleanTables()
        {
            Console.WriteLine("Cleaning tables...");
        }

        // Method to take customer orders
        private void TakeOrders()
        {
            Console.WriteLine("Taking customer orders...");
        }

        // Method to serve food
        private void ServeFood()
        {
            Console.WriteLine("Serving food...");
        }
    }
}

/* Explanation
 * ------------
 * 1. The RestaurantService class handles all tasks related to a restaurant.
 * 2. The HandleRestaurantTasks method calls all task-related methods.
 * 3. Each method performs a specific task such as cooking, accounting, cleaning, ordering, and serving.
 * 4. This class violates the Single Responsibility Principle because it has multiple responsibilities.
 */

/* Problems in this program
 * ------------------------
 * 1. The RestaurantService class has multiple responsibilities.
 * 2. Any change in one task (e.g., accounting or cooking) requires modifying the same class.
 * 3. This makes the code difficult to maintain, test, and extend.
 */