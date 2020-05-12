using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {

        public static DataClasses1DataContext context = new DataClasses1DataContext();
        static void Main(string[] args)
        {
            Grouping();
            Console.Read();
        }
        static void IntroToLinq()
        {
            int[] numbers = new int[7] { 1, 2, 3, 4, 5, 6, 7 };
            var numQuery = from num in numbers
                           where (num % 2) == 0
                           select num;
            foreach (int n in numQuery)
            {
                Console.Write("{0,1}", n);
            }
        }
        static void DataSource()
        {
            var queryAllCustomers = from cust in context.clientes
                                    select cust;
            foreach (var item in queryAllCustomers)
            {
                Console.WriteLine(item.NombreCompañia);
            }
        }
        static void Filtering()
        {
            var queryLondonCustomers = from cust in context.clientes
                                       where cust.Ciudad == "Londres"
                                       select cust;
            foreach (var iten in queryLondonCustomers)
            {
                Console.WriteLine(iten.Ciudad);
            }
        }
        static void Ordering()
        {
            var queryLondonCustomers3 = from cust in context.clientes
                                        where cust.Ciudad == "London"
                                        orderby cust.NombreCompañia ascending
                                        select cust;

            foreach (var item in queryLondonCustomers3)
            {
                Console.WriteLine(item.NombreCompañia);
            }
        }
        static void Grouping()
        {
            var queryCustomersByCity = from cust in context.clientes
                                       group cust by cust.Ciudad;

            foreach (var a in queryCustomersByCity)
            {
                Console.WriteLine(a.Key);
                foreach (clientes c in a)
                {
                    Console.WriteLine(" {0}", c.NombreCompañia);
                }
            }
        }
        static void Grouping2()
        {
            var custQuery = from cust in context.clientes
                            group cust by cust.Ciudad into custGroup
                            where custGroup.Count() > 2
                            orderby custGroup.Key
                            select custGroup;

            foreach (var item in custQuery)
            {
                Console.WriteLine(item.Key);
            }
        }
        static void Joining()
        {
            var innerJoinQuery = from cust in context.clientes
                                 join dist in context.Pedidos
                                 on cust.idCliente equals dist.IdCliente
                                 select new
                                 {
                                     CustomerName = cust.NombreCompañia,
                                     DistributorName = dist.PaisDestinatario
                                 };

            foreach (var item in innerJoinQuery)
            {
                Console.WriteLine(item.CustomerName);
            }

        }
    }
}
  
