using System;

namespace SolidPrinciples.WithISP
{
    // ISP: Instead of one big interface, we divide it into small, specific interfaces.

    // Interface for cooking-related operations
    // Contains only the method required for cooking tasks
    interface ICook
    {
        void Cook();
    }

    // Interface for cleaning-related operations
    // Contains only the method required for cleaning tasks
    interface ICleaner
    {
        void CleanTables();
    }

    // Interface for accounting-related operations
    // Contains only the method required for financial tasks
    interface IAccountant
    {
        void ManageAccounts();
    }

    // Chef class implements only cooking functionality
    // Follows ISP by not depending on unnecessary methods
    class Chef : ICook
    {
        public void Cook()
        {
            Console.WriteLine("Cooking meals...");
        }
    }

    // Cleaner class implements only cleaning functionality
    // Follows ISP by focusing only on its responsibility
    class Cleaner : ICleaner
    {
        public void CleanTables()
        {
            Console.WriteLine("Cleaning tables...");
        }
    }

    // Accountant class implements only accounting functionality
    // Follows ISP by implementing only required behavior
    class Accountant : IAccountant
    {
        public void ManageAccounts()
        {
            Console.WriteLine("Managing restaurant finances...");
        }
    }

    // Entry point of the program
    class Program
    {
        static void Main()
        {
            // Each object is accessed through its specific interface

            ICook chef = new Chef();
            chef.Cook(); // Output: Cooking meals...

            ICleaner cleaner = new Cleaner();
            cleaner.CleanTables(); // Output: Cleaning tables...

            IAccountant accountant = new Accountant();
            accountant.ManageAccounts(); // Output: Managing restaurant finances...

            Console.ReadLine();
        }
    }
}

/*
 ======================================================================
                            EXPLANATION (ISP)
 ======================================================================

 1. The Interface Segregation Principle (ISP) states:
        "Clients should not be forced to depend on methods they do not use."

 2. Instead of one large interface like:
        interface IRestaurantWorker { Cook(); CleanTables(); ManageAccounts(); }

    it is better to split it into smaller, role-specific interfaces:
        - ICook
        - ICleaner
        - IAccountant

 3. Each class (Chef, Cleaner, Accountant) implements only the interface
    relevant to its role.

 4. This ensures that no class is forced to implement unnecessary methods.


 ======================================================================
                               BENEFITS
 ======================================================================

 ✔ 1. No class is forced to implement unwanted methods.
      (Chef does not need to clean tables or manage accounts.)

 ✔ 2. Code becomes flexible and easy to extend.
      New roles can be added without affecting existing classes.

 ✔ 3. Promotes clean and modular design.
      Interfaces are small, focused, and role-specific.

 ✔ 4. Reduces tight coupling between classes and interfaces.

 ✔ 5. Improves testability, as each interface has a single responsibility.

 ======================================================================
*/
