using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading;

namespace IPCMQClient
{
    class Client
    {
        static void Main(string[] args)
        {
            IPCMQClient mqClient = new IPCMQClient();
            bool finished = false;
            Thread readQueue = new Thread(mqClient.ReadFromQueueu);
            readQueue.IsBackground = true;
            readQueue.Start();
            //readQueue.Start();


            do
            {
                //Console.Write("Enter a new message (or blank line to exit): ");
                string message = Console.ReadLine();
                int pid = Process.GetCurrentProcess().Id;
                message = Convert.ToString(pid) + "@" + message;


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


        //void ClientCheckQueue(object mQueueName)
        //{
        //    while(MessageQueue.Exists(mQueueName))
        //    {

        //        mqClient.ReadFromQueueu();



        //    }



        //}
        


    }
}
