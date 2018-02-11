using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreyAndBilliard
{
    class AndreyAndBilliard
    {
        static string[] TakeProduct()
        {
            return Console.ReadLine()
                          .Split('-')
                          .Where(p => !string.IsNullOrWhiteSpace(p))
                          .ToArray();
        }

        static bool TakeClients(GameBar gameBar)
        {
            string[] clientOrder = Console.ReadLine()
                          .Split(new char[] { '-', ',', ' ' })
                          .Where(p => !string.IsNullOrWhiteSpace(p))
                          .ToArray();

            if (clientOrder[0] == "end")
            {
                return false;
            }

            gameBar.AddClients(clientOrder);

            return true;
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            GameBar gameBar = new GameBar();

            for (int i = 0; i < n; i++)
            {
                gameBar.AddProducts(TakeProduct());
            }

            while (TakeClients(gameBar)) { }

            gameBar.PrintBill();
        }
    }

    class GameBar
    {
        private Dictionary<string, decimal> prices;

        private List<Client> clients;

        public GameBar()
        {
            prices = new Dictionary<string, decimal> { };
            clients = new List<Client>();
        }

        public void AddProducts(string[] array)
        {
            if (prices.ContainsKey(array[0]))
            {
                prices[array[0]] = decimal.Parse(array[1]);
            }
            else
            {
                prices.Add(array[0], decimal.Parse(array[1]));
            }
        }

        public void AddClients(string[] array)
        {
            string name = array[0];
            string product = array[1];
            decimal quantity = decimal.Parse(array[2]);

            if (prices.ContainsKey(product))
            {
                if (clients.Any(x => x.Name == name))
                {
                    int index = clients.FindIndex(x => x.Name == name);

                    if (clients[index].Orders.ContainsKey(product))
                    {
                        clients[index].Orders[product] += quantity;
                    }
                    else
                    {
                        clients[index].Orders.Add(product, quantity);
                    }
                }
                else
                {
                    clients.Add(new Client(name, product, quantity));
                }
            }
        }

        public void PrintBill()
        {
            var sorted = clients.OrderBy(x => x.Name).ToList();

            decimal totalBill = 0;
            foreach (Client client in sorted)
            {
                string name = client.Name;
                Console.WriteLine(name);

                decimal bill = 0;
                foreach (KeyValuePair<string, decimal> pair in client.Orders)
                {
                    Console.WriteLine($"-- {pair.Key} - {pair.Value}");
                    bill += pair.Value * prices[pair.Key];
                }
                Console.WriteLine($"Bill: {string.Format("{0:0.00}", bill)}");

                totalBill += bill;
            }
            Console.WriteLine($"Total bill: {string.Format("{0:0.00}", totalBill)}");
        }
    }

    class Client
    {
        private string name;
        private Dictionary<string, decimal> orders = new Dictionary<string, decimal> { };

        public Client(string name, string order, decimal quantity)
        {
            this.name = name;
            this.orders.Add(order, quantity);
        }

        public string Name { get => name; set => name = value; }
        public Dictionary<string, decimal> Orders { get => orders; set => orders = value; }
    }
}
