using System.IO;
using InfoM;
namespace RepData
{

    public class Userrepo
    {
        private const string path = "users.txt";
        public void saveUser(info user)
        {
            File.AppendAllText(path, $"{user.fName},{user.lName}\n");
        }
    }
    public class Orderrepo
    {
        private const string path = "order.txt";
        public void savePay(payinfo payment)
        {
            File.AppendAllText(path, $"{payment.method},{payment.cardNumber}\n");
        }
        public void saveShip(shipinfo shipping)
        {
            File.AppendAllText(path, $"{shipping.address},{shipping.contactnum}\n");

        }
    }
}
