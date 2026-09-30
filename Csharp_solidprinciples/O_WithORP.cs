using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.WithORP
{

    // This interface is responsible for processing the payment.
    interface IPaymentMethod
    {
        void ProcessPayment();
    }


    // This class is responsible for handling the credit card payment.
    class CreditCardPayment : IPaymentMethod
    {
        public void ProcessPayment()
        {
            Console.WriteLine("Processing credit card payment...");
        }
    }

    // This class is responsible for handling the UPI payment.
    class UpiPayment : IPaymentMethod
    {
        public void ProcessPayment()
        {
            Console.WriteLine("Processing UPI payment...");
        }
    }

    // This class is responsible for handling the PayPal payment.
    class PayPalPayment : IPaymentMethod
    {
        public void ProcessPayment()
        {
            Console.WriteLine("Processing PayPal payment...");
        }
    }


    // This class is responsible for handling all the tasks related to a restaurant.
    class PaymentProcessor
    {
        // This method is responsible for processing the payment.
        public void ProcessPayment(IPaymentMethod paymentMethod)
        {
            paymentMethod.ProcessPayment();
        }


        // If you want to call the all payment methods at once then you can use below code
        public static void Main(string[] args)
        {
            PaymentProcessor paymentProcessor = new PaymentProcessor();
            paymentProcessor.ProcessPayment(new CreditCardPayment()); // Processing credit card payment...
            paymentProcessor.ProcessPayment(new UpiPayment()); // Processing UPI payment...
            paymentProcessor.ProcessPayment(new PayPalPayment()); // Processing PayPal payment...
        }
    }
}


/* Explanation
 * ------------
 *  1. The IPaymentMethod interface is responsible for processing the payment.
 *  2. The CreditCardPayment, UpiPayment, and PayPalPayment classes are responsible for handling the credit card, UPI, and PayPal payments respectively.
 *  3. The PaymentProcessor class is responsible for handling all the tasks related to processing payments.
 *  4. The ProcessPayment method is responsible for processing the payment.
 */

/*Advantages of this program
 * 1. The PaymentProcessor class is open for extension and closed for modification why means if we add new payment method we need not to modify the existing class because we are using interface.
 * 2. Means that we can add new payment methods like PayPal without modifying the existing code. so here we are using interface to achieve this open/closed principle.
 */