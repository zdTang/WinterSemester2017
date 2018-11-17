﻿using System;
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
        public static bool isExist = true;
        
        static void Main(string[] args)
        {
           
            IPCMQClient mqClient = new IPCMQClient();

            if(isExist)
            {

                // create a thread to check the Message in the Queue constantly
                Thread readQueue = new Thread(mqClient.ReadFromQueueu);
                readQueue.IsBackground = true;
                readQueue.Start();
                

                // waiting for user's input 
                while(true)
                {
                    
                    string message = Console.ReadLine();
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
