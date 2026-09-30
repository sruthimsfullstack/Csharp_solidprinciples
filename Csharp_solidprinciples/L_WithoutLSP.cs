using System;

namespace SolidPrinciples_WithoutLSP
{
    // Without LSP: Bad Design (Restaurant Example)
    // Even though we use an abstract class, the design still violates LSP

    // Base abstract class representing staff members
    // It forces all derived classes to implement PerformHelpTask
    abstract class Staff
    {
        // Method to show the role of the staff
        public abstract void ShowRole();

        // Contract: every staff must perform a help task
        public abstract void PerformHelpTask();
    }

    // Chef is a Staff member and performs cooking tasks
    class Chef : Staff
    {
        public override void ShowRole()
        {
            Console.WriteLine("This is a Chef.");
        }

        public override void PerformHelpTask()
        {
            Console.WriteLine("Cooking food...");
        }
    }

    // Cleaner is a Staff member and performs cleaning tasks
    class Cleaner : Staff
    {
        public override void ShowRole()
        {
            Console.WriteLine("This is a Cleaner.");
        }

        public override void PerformHelpTask()
        {
            Console.WriteLine("Cleaning tables...");
        }
    }

    // LSP Violation:
    // Customer is forced to inherit from Staff, but it cannot perform staff tasks
    // This breaks the expected behavior of the base class
    class Customer : Staff
    {
        public override void ShowRole()
        {
            Console.WriteLine("This is a Customer.");
        }

        public override void PerformHelpTask()
        {
            // Customer cannot perform this task → throws exception
            throw new Exception("Customer cannot perform staff tasks.");
        }
    }

    class Program
    {
        static void Main()
        {
            // Valid substitutions
            Staff chef = new Chef();
            Staff cleaner = new Cleaner();

            // Invalid substitution (LSP violation)
            Staff customer = new Customer();

            chef.ShowRole();
            chef.PerformHelpTask();

            cleaner.ShowRole();
            cleaner.PerformHelpTask();

            customer.ShowRole();
            //customer.PerformHelpTask(); // This is problem . Logically not correct as Custoer cannot perfom staff task ...

            try
            {
                // This breaks because Customer cannot perform staff task
                customer.PerformHelpTask();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadLine();

            //Since the subclass (Customer) cannot behave like the base class (Staff), it violates Liskov Substitution Principle.
        }
    }
}

/*
 ======================================================================
                          EXPLANATION
 ======================================================================

 1. Staff is an abstract base class that forces all subclasses 
    to implement PerformHelpTask.

 2. Chef and Cleaner correctly implement this behavior.

 3. Customer is also forced to implement PerformHelpTask,
    but it cannot actually perform staff tasks.

 4. So Customer throws an exception, which breaks the program.

 5. This violates Liskov Substitution Principle (LSP):
    A subclass (Customer) cannot replace its base class (Staff)
    without breaking expected behavior.

 ======================================================================
                        PROBLEMS IN THIS DESIGN
 ======================================================================

 1. Customer cannot follow the contract defined by Staff.

 2. The base class is too generic and forces invalid behavior.

 3. Substitution fails:
        Staff s = new Customer();  → breaks at runtime

 4. Therefore, this is a clear violation of LSP.

 ======================================================================
*/
