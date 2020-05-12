using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Lambda
    {
        public static DataClasses1DataContext context = new DataClasses1DataContext();
        public static void DataSource()
        {
            var queryAllCustomers = context.clientes.ToList();
            foreach (var item in queryAllCustomers)
            {
                Console.Write(item.NombreCompañia);
            }
        }
    }
}
