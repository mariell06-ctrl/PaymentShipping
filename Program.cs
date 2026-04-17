using InfoM;
using Microsoft.Data.SqlClient;
using RepData;
using ServiceB;
using System;

//ACCOUNT 
//PAYMENT BANK
//SHIPPING SAVED ADDRESS PICK

class Program
{
    static void Main()
    {
        Console.WriteLine("Hello!");
        Console.WriteLine("Let us get to know you.");
        Console.WriteLine("What is your first name?: ");
        string fname = Console.ReadLine();
        Console.WriteLine("Your Last Name?: ");
        string lname = Console.ReadLine();
        Console.WriteLine("-------------------------------- <3");

        var user = new info { fName = fname, lName = lname };
        var uservice = new Uservice();
        string result = uservice.Reguser(user);
        Console.WriteLine(result);
        if (!result.StartsWith("Welcome")) return;

        Console.WriteLine("What do you want to do today?\n " + "[1] Payment Methods\n " + "[2] Your Shipping Information\n");
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
        Console.WriteLine("========== PAYMENT TAB ===========");

        Console.WriteLine("What do want to do today?:\n " + "[1] Payment Methods\n [2] View Saved Payment Methods\n " +
            "[3] Update Payment Method\n");
        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                methodpayment();
                break;
            case "2":
                saved();
                break;
            case "3":
                update();
                break;
            default:
                Console.WriteLine("Invalid. Please check your inputted choice");
                break;
        }
    }

    public static void methodpayment()
    {
        Console.WriteLine("========== PAYMENT METHOD ===========");

        Console.WriteLine("Select a payment method:\n ");
        Console.WriteLine("[1] Cash \n[2] Online Payment\n[3] Credit Card\n ");
        string paymentMethod = Console.ReadLine();

        var payment = new payinfo();
        var payservice = new Payservice();

        if (paymentMethod == "1")
        {
            payment.method = "Cash";
            Console.WriteLine("You have selected Cash.");
            Console.WriteLine("The total amount is:" + "....\n" + "Please pay the amount upon delivery.\n");

        }
        else if (paymentMethod == "2")
        {
            Console.WriteLine("Available Online Payment:\n [1] Gcash\n [2] PayMaya\n [3] PayPal\n");
            Console.WriteLine(">> Select Payment Payment: \n");
            string onlinePayment = Console.ReadLine();
            if (onlinePayment == "1")
            {
                payment.method = "Gcash";
                Console.WriteLine("Enter your Phone Number: ");
                payment.phoneNumber = Console.ReadLine();
            }
            else if (onlinePayment == "2")
            {
                payment.method = "PayMaya";
                Console.WriteLine("Enter your Phone Number: ");
                payment.phoneNumber = Console.ReadLine();
            }
            else if (onlinePayment == "3")
            {
                payment.method = "PayPal";
                Console.WriteLine("Enter your Email: ");
                payment.email = Console.ReadLine();
                Console.WriteLine("Enter your Card Number: ");
                payment.cardNumber = Console.ReadLine();
                Console.WriteLine("Enter Card Holder Name: ");
                payment.cardHolder = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Invalid. Please check your inputted selection.");
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
            payment.method = "PayPal";
            Console.WriteLine("Enter Your Email:");
            payment.email = Console.ReadLine();
            Console.Write("Enter Card Holder Name: ");
            payment.cardHolder = Console.ReadLine();
            Console.Write("Enter Card Number: ");
            payment.cardNumber = Console.ReadLine();
        }
        string result = payservice.Processpay(payment);
        Console.WriteLine(result);
    }

    public static void saved()
    {
        string connStr = "Server=localhost\\SQLEXPRESS;Database=DBPaymentShipping;Integrated Security=True;TrustServerCertificate=True;";
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            string query = "SELECT * FROM Payments";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                int i = 1;
                while (reader.Read())
                {
                    Console.WriteLine($"[{i}] ID: {reader["Id"]}, Method: {reader["method"]}, Phone: {reader["phoneNumber"]}");
                    i++;
                }
            }
        }
    }

    public static void update()
    {
        string connStr = "Server=localhost\\SQLEXPRESS;Database=DBPaymentShipping;Integrated Security=True;TrustServerCertificate=True;";
        saved();

        Console.Write("Enter ID to update: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter new method: (Gcash, PayMaya, PayPal)");
        string newMethod = Console.ReadLine();

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            string query = "UPDATE Payments SET method=@method WHERE Id=@id";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@method", newMethod);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        Console.WriteLine(" >> Updated successfully!");
    }


      public static void shipping()
    {
        Console.WriteLine("=========== SHIPPING TAB ===========");

        Console.WriteLine("What do you want to do today?:\n [1] Add Shipping Information\n [2] View Saved Information\n " +
            "[3] Delete Shipping Information\n ");
        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                addship();
                break;
            case "2":
                viewship();
                break;
            case "3":
                deleteship();
                break;
            default:
                Console.WriteLine("Invalid. Please check inputted selection");
                break;
        }
    }
    public static void addship()
    {

        Console.WriteLine("========== ADD SHIPPING INFORMATION ==========");
        Console.WriteLine("");

        Console.WriteLine("Add Your Home Address: ");
        string address = Console.ReadLine();
        Console.WriteLine("Add Contact Number: ");
        string contact = Console.ReadLine();
        Console.WriteLine("\n Please make sure that the given information is correct.");

        var ship = new shipinfo { address = address, contactnum = contact };
        var shipservice = new Shipservice();
        string result = shipservice.Processship(ship);
        Console.WriteLine(result);

    }


    public static void viewship()
    {
        string connStr = "Server=localhost\\SQLEXPRESS;Database=DBPaymentShipping;Integrated Security=True;TrustServerCertificate=True;";
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            string query = "SELECT * FROM Shippings";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                int i = 1;
                while (reader.Read())
                {
                    Console.WriteLine($"[{i}] ID: {reader["Id"]}, Address: {reader["address"]}, Contact: {reader["contactNumber"]}");
                    i++;
                }
            }
        }
    }

    public static void deleteship()
    {
       string connStr = "Server=localhost\\SQLEXPRESS;Database=DBPaymentShipping;Integrated Security=True;TrustServerCertificate=True;";
       viewship();

        Console.Write("Enter ID to delete: ");
        int id = int.Parse(Console.ReadLine());

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            string query = "DELETE FROM Shippings WHERE Id=@id";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        Console.WriteLine(" >> Deleted successfully!");
    }
}



