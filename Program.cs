using System;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
class Program
{
    static void Main()
    {
        Console.WriteLine("Sign Up Now");
        Console.WriteLine("Enter Your Name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Enter Your Last Name: ");
        string lname = Console.ReadLine();

        Console.WriteLine("Welcome," + name + "!");
        Console.WriteLine("What do you want to do today?" + "1. Payment Methods" + "2. Your Shipping Information");
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
        Console.WriteLine("1. Cash" + " 2. Online Payment" + " 3. Credit Card" + " 4. Add a Bank Account");
        string paymentMethod = Console.ReadLine();

        if (paymentMethod == "1")
        {
            Console.WriteLine("You have selected Cash.");
            Console.WriteLine("The total amount is:" + " " + "Please pay the amount upon delivery. Thank you!");

        }
        else if (paymentMethod == "2")
        {
            Console.WriteLine("Available Online Payment: A. Gcash B. PayMaya C. PayPal");
            Console.WriteLine("Select Payment Method: ");
            string onlinePayment = Console.ReadLine();
            switch (onlinePayment)
            {
                case "A":
                    gcash();
                    break;
                case "B":
                    break;
                case "C":
                    break;
                default:
                    Console.WriteLine("Sorry! Please check your inputted choice");
                    break;
            }

        }
        else if (paymentMethod == "3")
        {
            Console.WriteLine("Credit Card Information:");
            Console.WriteLine("Enter Card Number: ");
            string card = Console.ReadLine();
        }
    }
    private static void gcash()
    {
        Console.WriteLine("Enter Your Information." +
            "Phone Number: " + "User Authentication: ");
    }
    private static void paymaya()
    {
        Console.WriteLine("Enter Your Information." +
           "Phone Number: " + "User Authentication: ");
    }
    private static void paypal()
    {
        Console.WriteLine("Enter Your Information." +
           "Phone Number: " + "User Authentication: ");
    }
    public static void shipping()
    {
        Console.WriteLine("SHIPPING INFORMATION");

        Console.WriteLine("Add Your Home Address: ");
        Console.WriteLine("Add Contact Number: ");

        Console.WriteLine("Hello! Your order is on the way. Please check your parcel carefully."); 
    }
} 
