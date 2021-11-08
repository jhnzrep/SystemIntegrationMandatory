using MessageQue.Model;
using System;
using System.Threading.Tasks;

namespace Consumer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Consumer consumer = new Consumer();
            Request request;
            Console.WriteLine("Welcome to the consumer client!");
            Console.WriteLine();
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("To start please write the exact title of the message");
                var title = Console.ReadLine();

                Console.WriteLine("Please enter the format you want the message in! JSON or XML");
                var format = Console.ReadLine();

                request = new Request(title, format);

                var response = await consumer.GetMessage(request);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(response);
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
