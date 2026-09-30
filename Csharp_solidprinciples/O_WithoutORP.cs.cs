using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.WithoutORP
{

    // This class is responsible for handling all the tasks related to a restaurant.

    class PaymentProcessor
    {

        // This method is responsible for processing the payment.
        // The method has multiple reasons to change because it has multiple responsibilities.
        // those are 1.CreditCard, 2.UPI, 3.PayPal might be add more in future.
        public void ProcessPayment(string paymentType)
        {
            if (paymentType == "CreditCard")
            {
                Console.WriteLine("Processing credit card payment...");
            }
            else if (paymentType == "UPI")
            {
                Console.WriteLine("Processing UPI payment...");
            }

            // Adding PayPal requires modification here(In Future)
            //else if (paymentType == "PayPal")
            //{
            //    Console.WriteLine("Processing PayPal payment...");
            //}
        }
    }
}

/* Explanation
 * ------------
 *  1. The PaymentProcessor class is responsible for handling all the tasks related to processing payments.
 *  2. The ProcessPayment method is responsible for processing the payment.
 *  3. The method has multiple reasons to change because it has multiple responsibilities.
 *  4. The class violates the Open/Closed Principle because it is not open for extension and closed for modification.
 *  5. If a new payment method like PayPal is added, the ProcessPayment method needs to be modified.
 */

/*Problems in this program
 * 1. If a new payment method like PayPal is added, the ProcessPayment method needs to be modified.
 * 2. The class violates the Open/Closed Principle because it is not open for extension and closed for 
 * modification why means if we add new payment method we need to modify the existing class 
 * and this is not a good practice.
 */
