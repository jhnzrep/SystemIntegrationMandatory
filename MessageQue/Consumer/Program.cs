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
            Console.WriteLine("To start please enter your username:");
            string name = Console.ReadLine();
            bool Loop = true;
            while (Loop)
            {
                Console.Clear();
                Console.WriteLine("Please choose what you want to do next:");
                Console.WriteLine("1 - Read next message");
                Console.WriteLine("2 - Exit program");

                Console.WriteLine();
                Console.WriteLine();

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Choose message format:");
                        Console.WriteLine("J - JSON");
                        Console.WriteLine("X - XML");
                        string format;
                        switch (Console.ReadLine())
                        {
                            case "X":
                                format = "XML";
                                break;
                            default:
                                format = "JSON";
                                break;
                        }
                        request = new Request(name, format);
                        var response = await consumer.GetMessage(request);

                        Console.WriteLine();
                        Console.WriteLine();

                        Console.WriteLine(response);

                        Console.WriteLine();
                        Console.WriteLine();

                        Console.WriteLine("Would you like to forward this message through SMS?");
                        Console.WriteLine("Y/N");
                        switch (Console.ReadLine())
                        {
                            case "Y":
                                break;
                            default:
                                break;
                        }
                        break;

                    default:
                        Console.WriteLine("Thank you for using our client. Goodbye!");
                        break;
                }
            }
        }
    }
}
