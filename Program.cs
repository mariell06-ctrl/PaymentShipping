using System;
using InfoM;
using RepData;
using ServiceB;

    //ACCOUNT 
    //PAYMENT BANK
    //SHIPPING SAVED ADDRESS PICK

class Program
{
    static void Main()
    {
        Console.WriteLine("------Sign Up Now------");
        Console.WriteLine("Enter Your Name: ");
        string fname = Console.ReadLine();
        Console.WriteLine("Enter Your Last Name: ");
        string lname = Console.ReadLine();

       
        var user = new info { fName = fname, lName = lname };
        var uservice = new Uservice();
        string result = uservice.Reguser(user);
        Console.WriteLine(result);
        if (!result.StartsWith("Welcome")) return;

        Console.WriteLine("What do you want to do today? " + "1. Payment Methods " + "2. Your Shipping Information");
        string pick = Console.ReadLine();
        switch (pick)
        {
            case "1":
                payment();
                break;
            case "2":
                shipping();
                break;
            default:
                Console.WriteLine("Invalid. Please check your inputted choice");
                break;
        }
    }
private static void payment()
    {
        Console.WriteLine("PAYMENT METHODS");

        Console.WriteLine("Select a payment method (1-4): ");
        Console.WriteLine("1. Cash " + " 2. Online Payment " + " 3. Credit Card " + " 4. Add a Bank Account");
        string paymentMethod = Console.ReadLine();

        var payment = new payinfo();
        var payservice = new Payservice();

        if (paymentMethod == "1")
        {
            payment.method = "Cash";
            Console.WriteLine("You have selected Cash.");
            Console.WriteLine("The total amount is:" + " " + "Please pay the amount upon delivery.\n");
            
        }
        else if (paymentMethod == "2")
        {
            Console.WriteLine("Available Online Payment: 1. Gcash 2. PayMaya 3. PayPal");
            Console.WriteLine("Select Payment Method: ");
            string onlinePayment = Console.ReadLine();
            if (onlinePayment == "1")
            {
                payment.method = "Gcash";
                Console.WriteLine("Enter your Phone Number: ");
                payment.phoneNumber = Console.ReadLine();
            }

        }
        else if (paymentMethod == "3")
        {
            payment.method = "Credit Card";
            Console.Write("Enter Card Holder Name: ");
            payment.cardHolder = Console.ReadLine();
            Console.Write("Enter Card Number: ");
            payment.cardNumber = Console.ReadLine();
                      
        }
        else if (paymentMethod == "4")
        {
            // ADD DETAILS HERE
        }
        string result = payservice.Processpay(payment);
        Console.WriteLine(result);
    }
       public static void shipping()
    {
        Console.WriteLine("SHIPPING INFORMATION");
        Console.WriteLine("");

        Console.WriteLine("Add Your Home Address: ");
        string address = Console.ReadLine();
        Console.WriteLine("Add Contact Number: ");
        string contact = Console.ReadLine();
        Console.WriteLine("");
        Console.WriteLine("Please make sure that the given information is correct.");

        var ship = new shipinfo { address = address, contactnum = contact };
        var shipservice = new Shipservice();
        string result = shipservice.Processship(ship);
        Console.WriteLine(result);
       
    }
} 
