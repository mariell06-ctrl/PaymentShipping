using System;
class Program {
    static void Main()
    {
        Console.WriteLine("PAYMENT METHODS");

        Console.WriteLine("Select a payment method (1-4): ");
        Console.WriteLine("1. Cash" + " 2. Online Payment" + " 3. Credit Card" + " 4. Add a Bank Account");
        string paymentMethod = Console.ReadLine();

        if (paymentMethod == "Cash")
        {
            Console.WriteLine("You have selected Cash.");
            Console.WriteLine("The total amount is:" + " " + "Please pay the amount upon delivery. Thank you!");

        }






    }
}