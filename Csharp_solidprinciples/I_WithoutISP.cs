using System;

namespace SolidPrinciples.WithoutISP
{
    // Bad Design (Without ISP):
    // A large interface forces classes to implement methods they do not need.

    interface IRestaurantService
    {
        void Cook();
        void ManageAccounts();
        void CleanTables();
    }

    // Chef class is responsible only for cooking.
    // However, due to the large interface, it is forced to implement unrelated methods.
    class Chef : IRestaurantService
    {
        // Relevant method for Chef
        public void Cook()
        {
            Console.WriteLine("Cooking meals...");
        }

        // Not relevant for Chef, but forced by the interface
        public void ManageAccounts()
        {
            // Unnecessary implementation
        }

        // Not relevant for Chef, but forced by the interface
        public void CleanTables()
        {
            // Unnecessary implementation
        }
    }


    // ---------------------------------------------------
    // MAIN METHOD
    // ---------------------------------------------------
    class Program
    {
        static void Main(string[] args)
        {
            IRestaurantService chefService = new Chef();
            chefService.Cook();   // This works

            // These calls do nothing because Chef should not be doing them
            chefService.ManageAccounts();
            chefService.CleanTables();

            Console.ReadLine();
        }
    }
}


/*
 ======================================================================
                           EXPLANATION (Without ISP)
 ======================================================================

 1. The IRestaurant interface contains three actions:
        Cook(), ManageAccounts(), CleanTables()

 2. The Chef class implements this interface and is forced to write code for
    ALL three methods.

 3. But Chef only needs one method: Cook()
    The other two methods do not make sense for a chef.

 4. This breaks the Interface Segregation Principle (ISP) because the Chef
    class is forced to depend on methods it does not use.

 5. Large interfaces create unnecessary responsibilities for classes and
    make the design harder to maintain.

 ======================================================================
                              PROBLEMS
 ======================================================================

 ✔ 1. Chef is forced to implement unwanted methods like:
        - ManageAccounts()
        - CleanTables()

 ✔ 2. These empty or useless methods increase code pollution and confusion.

 ✔ 3. Chef is depending on things it does NOT need → direct ISP violation.

 ✔ 4. If the interface grows bigger, Chef will be forced to implement even
      more unnecessary methods.

 ✔ 5. This design becomes hard to extend and maintain over time.

 ======================================================================
*/
