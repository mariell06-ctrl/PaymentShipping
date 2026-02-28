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

        Console.WriteLine("Welcome," + name + lname + "!");
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

        if (paymentMethod == "1")
        {
            Console.WriteLine("You have selected Cash.");
            Console.WriteLine("The total amount is:" + " " + "Please pay the amount upon delivery. Thank you!");

        }
        else if (paymentMethod == "2")
        {
            Console.WriteLine("Available Online Payment: 1. Gcash 2. PayMaya 3. PayPal");
            Console.WriteLine("Select Payment Method: ");
            string onlinePayment = Console.ReadLine();
            switch (onlinePayment)
            {
                case "1":
                    gcash();
                    break;
                case "2":
                    break;
                case "3":
                    break;
                default:
                    Console.WriteLine("Sorry! Please check your inputted choice");
                    break;
            }

        }
        else if (paymentMethod == "3")
        {
            Console.WriteLine("Credit Card Information.");
            Console.WriteLine(" ");
            Console.WriteLine("Enter Card Holder Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Card Number: ");
            string card = Console.ReadLine();
            Console.WriteLine("Enter Billing Address: ");
            string bill = Console.ReadLine();
            Console.WriteLine("Enter Card Expiration Date: ");
            string expire = Console.ReadLine();

            Console.WriteLine("Please check your card information below, make sure that all aure accurate.");
            Console.WriteLine(name);
            Console.WriteLine(card);
            Console.WriteLine(bill);
            Console.WriteLine(expire);

        }
    }
    public static void gcash()
    {
        Console.WriteLine("Enter Your Information.");
        Console.WriteLine(" ");
        Console.WriteLine("Enter Phone Number: ");
        string phone = Console.ReadLine();
        Console.WriteLine("Enter Your MPIN: ");
        string pin = Console.ReadLine();
    }
    public static void paymaya()
    {
        Console.WriteLine("Enter Your Information.");
        Console.WriteLine(" ");
        Console.WriteLine("Enter Card Holder Name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Enter Card Number: ");
        string card = Console.ReadLine();
        Console.WriteLine("Enter Billing Address: ");
        string bill = Console.ReadLine();
        Console.WriteLine("Enter Card Expiration Date: ");
        string expire = Console.ReadLine();
        Console.WriteLine("Enter Phone Number: ");
        string phone = Console.ReadLine();
        Console.WriteLine("Enter given OTP: ");
        string auth = Console.ReadLine();
    }
    public static void paypal()
    {
        Console.WriteLine("Enter Your Information.");
        Console.WriteLine(" ");
        Console.WriteLine("Enter Email Address: ");
        string email = Console.ReadLine();
        Console.WriteLine("Enter Phone Number: ");
        string phone = Console.ReadLine();
        Console.WriteLine("User Authentication: ");
        string auth = Console.ReadLine();
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
        Console.WriteLine(address);
        Console.WriteLine(contact);
        Console.WriteLine(" ");
        Console.WriteLine("Hello! Your order is on the way. Please check your parcel information regularly."); 
    }
} 
