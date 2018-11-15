using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IPCMQClient
{
    class Program
    {
        static void Main(string[] args)
        {
            IPCMQClient mqClient = new IPCMQClient();
            bool finished = false;

            do
            {
                Console.Write("Enter a new message (or blank line to exit): ");
                string message = Console.ReadLine();


                string writeStatus = mqClient.WriteToQueue(message);
                if (writeStatus != "OK")
                {
                    Console.WriteLine("Status: " + writeStatus);
                }

                if (message == "Shutdown")
                {
                    finished = true;
                }

            } while (!finished);
            Console.WriteLine("Program Ended...");
            Console.Write("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
