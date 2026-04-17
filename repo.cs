using InfoM;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace RepData

{

    public class Userrepo
    {
        private const string path = "users.json";
        private const string connString =
             "Server=localhost\\SQLEXPRESS;Database=DBPaymentShipping;Integrated Security=True;TrustServerCertificate=True;";
        public void saveUser(info user)
        {
            List<info> users = new List<info>();

            if (File.Exists(path))
            {
                string existingData = File.ReadAllText(path);
                users = JsonConvert.DeserializeObject<List<info>>(existingData)
                        ?? new List<info>();
            }
            users.Add(user);

            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(path, json);


            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "INSERT INTO Users (Fname, Lname) VALUES (@fName, @lName)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@fName", user.fName);
                    cmd.Parameters.AddWithValue("@lName", user.lName);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<info> getUsers()
        {
            if (!File.Exists(path))
                return new List<info>();

            string data = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<info>>(data)
                   ?? new List<info>();
        }
    }
    public class Orderrepo
    {
        private const string paypath = "payment.json";
        private const string connString =
             "Server=localhost\\SQLEXPRESS;Database=DBPaymentShipping;Integrated Security=True;TrustServerCertificate=True;";

        //JSON
        public void savePay(payinfo payment)
        {
            List<payinfo> payments = new List<payinfo>();

            if (File.Exists(paypath))
            {
                string existingData = File.ReadAllText(paypath);
                payments = JsonConvert.DeserializeObject<List<payinfo>>(existingData)
                           ?? new List<payinfo>();
            }

            payments.Add(payment);
            string json = JsonConvert.SerializeObject(payments, Formatting.Indented);
            File.WriteAllText(paypath, json);


            //MS SQL

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = @"INSERT INTO Payments 
                                (method, cardNumber, phoneNumber, cardHolder, email) 
                                VALUES 
                                (@Method, @CardNumber, @PhoneNumber, @CardHolder, @Email)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Method", payment.method ?? "");
                    cmd.Parameters.AddWithValue("@CardNumber", payment.cardNumber ?? "");
                    cmd.Parameters.AddWithValue("@PhoneNumber", payment.phoneNumber ?? "");
                    cmd.Parameters.AddWithValue("@CardHolder", payment.cardHolder ?? "");
                    cmd.Parameters.AddWithValue("@Email", payment.email ?? "");
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
        public class shippingpath
        {
            private const string shippath = "ship.json";
            private const string connString =
                 "Server=localhost\\SQLEXPRESS;Database=DBPaymentShipping;Integrated Security=True;TrustServerCertificate=True;";

            //JSON
            public void saveShip(shipinfo shipping)
            {
                List<shipinfo> shippings = new List<shipinfo>();

                if (File.Exists(shippath))
                {
                    string existingData = File.ReadAllText(shippath);
                    shippings = JsonConvert.DeserializeObject<List<shipinfo>>(existingData)
                                ?? new List<shipinfo>();
                }

                shippings.Add(shipping);
                string json = JsonConvert.SerializeObject(shippings, Formatting.Indented);
                File.WriteAllText(shippath, json);

                // MS SQL

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string query = @"INSERT INTO Shippings (address, contactNumber) 
                                VALUES (@Address, @ContactNum)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Address", shipping.address ?? "");
                        cmd.Parameters.AddWithValue("@ContactNum", shipping.contactnum ?? "");
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }

