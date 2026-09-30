using System;

namespace SolidPrinciples.WithDIP
{
    // Abstraction (Interface)
    // Defines how a kitchen should prepare an order
    interface IFoodPreparationService
    {
        void PrepareOrder(string order);
    }

    // Low-level module (Concrete implementation)
    // Represents the main kitchen
    class KitchenService : IFoodPreparationService
    {
        public void PrepareOrder(string order)
        {
            Console.WriteLine($"Preparing {order} in the main kitchen.");
        }
    }

    // Another low-level module (Concrete implementation)
    // Represents an external kitchen
    class ExternalKitchenService : IFoodPreparationService
    {
        public void PrepareOrder(string order)
        {
            Console.WriteLine($"Preparing {order} in the external kitchen.");
        }
    }

    // High-level module (Business logic)
    // Depends on abstraction, not on concrete classes
    class OrderHandler
    {
        private IFoodPreparationService kitchenService;

        // Constructor Injection
        // Dependency is provided from outside
        public OrderHandler(IFoodPreparationService kitchenService)
        {
            this.kitchenService = kitchenService;
        }

        public void TakeOrder(string order)
        {
            Console.WriteLine($"Server taking order: {order}");

            // Uses abstraction → flexible implementation
            kitchenService.PrepareOrder(order);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Using main kitchen
            OrderHandler orderHandler = new OrderHandler(new KitchenService());
            orderHandler.TakeOrder("Pizza");

            // Switching to external kitchen without modifying OrderHandler
            orderHandler = new OrderHandler(new ExternalKitchenService());
            orderHandler.TakeOrder("Burger");

            Console.ReadLine();
        }
    }
}

/*
 =============================================================================
                              EXPLANATION (DIP)
 -----------------------------------------------------------------------------
 1. IFoodPreparationService is an interface (abstraction) that defines how a
    kitchen should prepare an order.

 2. KitchenService and ExternalKitchenService are concrete classes that
    implement the IFoodPreparationService interface, each providing its own
    way of preparing an order.

 3. OrderHandler is a high-level class that handles customer orders.
    Instead of depending on a specific kitchen class, it depends only on
    the abstraction (IFoodPreparationService).

 4. Because of this, OrderHandler does not care which kitchen it works with.
    It simply calls PrepareOrder() on the provided implementation.

 5. In the Main method, we can easily switch between KitchenService and
    ExternalKitchenService without modifying OrderHandler.
    This is exactly what DIP requires.

 -----------------------------------------------------------------------------
                                 ADVANTAGES
 -----------------------------------------------------------------------------
 ✔ 1. High-level class (OrderHandler) depends on an abstraction, not a
      concrete class → flexible design.

 ✔ 2. New kitchen types can be added without modifying OrderHandler
      (extension without modification).

 ✔ 3. Loose coupling between business logic and implementation.

 ✔ 4. Easy to test using mock or fake implementations.

 ✔ 5. Follows Dependency Inversion Principle:
      - High-level modules depend on abstractions.
      - Low-level modules also depend on abstractions.
 =============================================================================
*/