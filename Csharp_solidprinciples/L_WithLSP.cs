using System;

namespace SolidPrinciples.WithLSP
{
    // Base class representing any person
    abstract class Person
    {
        // Common behavior for all persons
        public virtual void ShowRole()
        {
            Console.WriteLine("This is a person.");
        }
    }

    // Staff inherits from Person and represents employees
    // Only staff members can perform help tasks
    class Staff : Person
    {
        public override void ShowRole()
        {
            Console.WriteLine("This is a staff member.");
        }

        // Staff-specific responsibility
        public virtual void PerformHelpTask()
        {
            Console.WriteLine("Performing a staff task...");
        }
    }

    // Chef is a type of Staff and performs cooking tasks
    class Chef : Staff
    {
        public override void PerformHelpTask()
        {
            Console.WriteLine("Cooking food...");
        }
    }

    // Cleaner is a type of Staff and performs cleaning tasks
    class Cleaner : Staff
    {
        public override void PerformHelpTask()
        {
            Console.WriteLine("Cleaning tables...");
        }
    }

    // Customer is a type of Person, NOT Staff
    // This ensures correct relationship ancld follows LSP
    class Customer : Person
    {
        public override void ShowRole()
        {
            Console.WriteLine("This is a customer.");
        }

        public void PlaceOrder()
        {
            Console.WriteLine("Customer placing order...");
        }
    }

    class Program
    {
        static void Main()
        {
            // Valid substitutions
            Staff chef = new Chef();
            Staff cleaner = new Cleaner();

            chef.PerformHelpTask();      // Cooking food...
            cleaner.PerformHelpTask();   // Cleaning tables...


            //Person customer = new Customer();   // ✔ LSP correct
            //Staff customer = new Customer();   // ❌ LSP violation


            // Customer behaves independently
            Customer customer = new Customer();
            customer.ShowRole();
            customer.PlaceOrder();       // Customer placing order...

            Console.ReadLine();
        }
    }
}

/* Explanation
 * ------------
 * 1. Person is the base class for all types of people.
 * 2. Staff inherits from Person and contains staff-specific behavior.
 * 3. Chef and Cleaner are valid Staff types and override behavior correctly.
 * 4. Customer inherits from Person, not Staff, because it cannot perform staff tasks.
 * 5. This ensures that all subclasses can safely replace their base class (LSP).
 */

/* Advantages
 * -----------
 * 1. Proper class hierarchy with correct relationships.
 * 2. No runtime exceptions due to invalid substitutions.
 * 3. Code is easier to maintain and extend.
 */
