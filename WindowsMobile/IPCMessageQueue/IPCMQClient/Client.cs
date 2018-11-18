using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading;

namespace IPCMQClient
{
    
    public class Client
    {
        public static bool isExist = false;
        
        static void Main(string[] args)
        {
           
            IPCMQClient mqClient = new IPCMQClient();

            if(isExist)
            {

                // create a thread to check the Message in the Queue constantly
                Thread readQueue = new Thread(mqClient.ReadFromQueue);
                readQueue.IsBackground = true;
                readQueue.Start();
                

                // waiting for user's input 
                while(true)
                {
                    //Console.Write("My Message: ");
                    string message = Console.ReadLine();
                    Console.WriteLine("Me: {0}", message);
                    int pid = Process.GetCurrentProcess().Id;
                    message = Convert.ToString(pid) + "@" + message;


                    mqClient.WriteToQueue(message);
                    

                } 
               
            }

            else
            {
                Console.Write("Server doesn't exist");
                Console.ReadKey();
            }

        }


        
        


    }
}
