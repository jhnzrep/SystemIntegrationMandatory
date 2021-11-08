using MessageQue.Model;
using System;
using System.Threading.Tasks;

namespace Publisher
{
    class Program
    {
        static async Task Main(string[] args)
        {
            bool goAgain = true;
            Publisher publisher = new Publisher();
            Message message = new Message();
            Console.WriteLine("Welcome to the publisher client!");
            Console.WriteLine();
            Console.WriteLine();
            while (goAgain == true)
            {
                Console.WriteLine("To start please enter a title for your message:");
                message.Title = Console.ReadLine();

                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("Please enter the body of your message");
                message.Body = Console.ReadLine();

                var response = await publisher.PostRequest(message);
                Console.WriteLine(response);
                Console.ReadLine();
            }
        }
    }
}
