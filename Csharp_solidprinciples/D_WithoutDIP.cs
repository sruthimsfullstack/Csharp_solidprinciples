using System;
using System.ComponentModel;
using System.Reflection.Emit;
using System.Security.Cryptography;

namespace SolidPrinciples.WithoutDIP
{
    // Bad Design:
    // OrderHandler depends directly on KitchenService (a concrete class).
    // If we want to switch to a different kitchen, we must MODIFY OrderHandler.



    //A higher-level module is a class that contains main business logic.
    //OrderHandler = high-level module

    //Abstraction means focusing on what something does, not how it does it.
    //It is usually represented using interfaces or abstract classes.
    //An abstraction defines behavior or rules, but not the actual implementation.
    //It hides unnecessary details and exposes only the required functionality.

    // Bad Design:
    // High-level module depends directly on a low-level module (concrete class)
    // This violates the Dependency Inversion Principle (DIP)



    // Low-level module (concrete implementation / Work) - Prepare food
    class KitchenService
    {
        public void PrepareOrder(string order)
        {
            Console.WriteLine($"Preparing {order} in the MAIN kitchen.");
        }
    }



    // Another low-level module (alternative implementation / Work) - Prepare food
    class ExternalKitchenService
    {
        public void PrepareOrder(string order)
        {
            Console.WriteLine($"Preparing {order} in the EXTERNAL kitchen.");
        }
    }



    // High-level module (business logic) - Take Order
    class OrderHandler
    {
        // ❌ Direct dependency on concrete class (low-level module)
        private KitchenService kitchenService = new KitchenService();

        public void TakeOrder(string order)
        {
            Console.WriteLine($"Server taking order: {order}");
            kitchenService.PrepareOrder(order); // Only MAIN kitchen is used
        }

        // Real problem scenario
        public void TakeNightOrder(string order)
        {
            Console.WriteLine($"Server taking NIGHT order: {order}");

            // ❌ Still uses MAIN kitchen even if business wants EXTERNAL kitchen
            kitchenService.PrepareOrder(order);

            // ❌ To support external kitchen, we must MODIFY this class:
            // ExternalKitchenService externalKitchen = new ExternalKitchenService();
            // externalKitchen.PrepareOrder(order);

            // This modification requirement = DIP violation
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            OrderHandler orderHandler = new OrderHandler();

            // Normal order → uses MAIN kitchen
            orderHandler.TakeOrder("Pizza");

            // Night order → should use external kitchen, but cannot
            orderHandler.TakeNightOrder("Burger");

            Console.ReadLine();
        }
    }
}


/* ============================================================================
                                EXPLANATION
   ----------------------------------------------------------------------------
   1. KitchenService is the only cooking class available inside the program.
      It prepares food in the MAIN kitchen.

   2. OrderHandler creates KitchenService by itself (hardcoded inside the class).
      This means OrderHandler is tightly tied to this *one* kitchen.

   3. When the restaurant later introduces ExternalKitchen, the OrderHandler
      cannot use it unless we REWRITE the OrderHandler class.

   4. This breaks the Dependency Inversion Principle (DIP) because:
        - High-level class (OrderHandler) depends directly on LOW-LEVEL class.
        - No abstraction/interface is used.
        - Code must be changed every time a new kitchen is added.

   5. The TakeNightOrder() method clearly shows the problem:
        Even if the restaurant wants external kitchen for night orders,
        OrderHandler *cannot* switch kitchens dynamically.
   ----------------------------------------------------------------------------
                                PROBLEMS
   ----------------------------------------------------------------------------
   ❌ 1. OrderHandler is tightly coupled to KitchenService.
         It cannot work with ExternalKitchen without modifying the code.

   ❌ 2. If the restaurant adds another kitchen (CloudKitchen or FastKitchen),
         we must AGAIN modify OrderHandler → breaks DIP.

   ❌ 3. Hardcoding dependencies makes the class rigid and hard to extend.

   ❌ 4. The program violates DIP because:
         - High-level class depends on a concrete class, not an abstraction.
         - The details force changes in the high-level module.

   ❌ 5. Testing becomes difficult because we cannot replace KitchenService
         with a mock or fake kitchen.

   ----------------------------------------------------------------------------
   To fix all these issues, we use DIP with an interface (IKitchenService)
   and inject the dependency into OrderHandler through constructor.
   ============================================================================
*/




//practical example ..

//
