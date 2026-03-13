using System;
using RepData;
using InfoM;

namespace ServiceB 
{
    public class Uservice
    {
        private readonly Userrepo userR = new Userrepo();
        public string Reguser(info user)
        {
            if (string.IsNullOrWhiteSpace(user.fName))
                return "First name is required.";
            if (string.IsNullOrWhiteSpace(user.lName))
                return "Last name is required.";

            userR.saveUser(user);
            return $"Welcome, {user.fName} {user.lName}!";
        }
    }
    public class Payservice
    {
        private readonly Orderrepo orderR = new Orderrepo();
        public string Processpay(payinfo payment)
        {
            if (payment.method == "Credit Card")
            {
                if (payment.cardNumber.Length != 16)
                    return "Card number must be 16 digits";
            }

            if (payment.method == "Gcash")
            {
                if (string.IsNullOrWhiteSpace(payment.phoneNumber))
                    return "Phone number required.";
            }
            if (payment.method == "Bank")
            {
                // ADD DETAILS HERE
            }
            orderR.savePay(payment);
            return "Successful! Thank you.";
        }
    }

    public class Shipservice
    {
        private readonly Orderrepo orderrepo = new Orderrepo();
        public string Processship(shipinfo shipping)
        {
            if (string.IsNullOrWhiteSpace(shipping.address))
                return "Address is required.";
            if (string.IsNullOrWhiteSpace(shipping.contactnum))
                return "Contact number is required.";

            orderrepo.saveShip(shipping);
            return "Shipping information saved!";
        }

    }
}
