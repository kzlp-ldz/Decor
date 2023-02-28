using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Decor.Data
{
    public class DataAccess
    {
        
        public static DecorZakirovaEntities connection = new DecorZakirovaEntities();

        public static List<Product> GetProducts()
        {
            return connection.Product.ToList();
        }
        public static List<User> GetUsers()
        {
            return connection.User.ToList();
        }

        internal static User GetUser(string login, string password)
        {
            return GetUsers().FirstOrDefault(x => x.Login == login && x.Password == password);
        }

        public void SaveProduct(Product product)
        {
            if (product.ID == 0)
                connection.Product.Add(product);

            connection.SaveChanges();
        }
    }
}
