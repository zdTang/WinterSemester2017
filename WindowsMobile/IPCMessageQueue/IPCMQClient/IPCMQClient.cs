 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Messaging;
using System.Diagnostics;
using System.Threading;

namespace IPCMQClient
{
    public class IPCMQClient
    {
       private static string mQueueName = @".\private$\ipcTest";
        public  MessageQueue mq;

        
        //constructor
        public IPCMQClient()
        {

            while (!MessageQueue.Exists(mQueueName))
            {

                // No queue exit, complain and quit.
                Console.WriteLine("Attempt to connect to queue...");
                // Client.isExist = false;

                Thread.Sleep(2000);
            }


            // find the Queue, then make a reference to use the Queue
            Client.isExist = true;
                
                mq = new MessageQueue(mQueueName);
                Console.WriteLine("Queue Connected!");


        }

        // write data to Queue
        public void WriteToQueue(string data)
        {
            

            mq.Send(data);

            mq.Close();

          
            
        }

        // Peek the Message in the Queue.
        // Once the Message is not send by the client.
        // This client will Receive this message
        public void ReadFromQueue()
        {
            int pid = Process.GetCurrentProcess().Id;
            while (MessageQueue.Exists(mQueueName))
            {
                string content;
                string pidGet;
                mq.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
                content = (string)mq.Peek().Body;  //  peek the Message
                
                int index = content.IndexOf("@", 0); // find the index of "@"
                pidGet = content.Substring(0, index); // get the PID of the Client
                if(pidGet!=Convert.ToString(pid))      // if the string is not send by me, receive it!
                {
                    content = (string)mq.Receive().Body;
                    Console.WriteLine("[Client-{0}]:{1}",Convert.ToString(pidGet),content.Substring(index+1));
                }

                //else
                //{
                //    content = (string)mq.Receive().Body;
                //    Console.WriteLine("Me: {0}", content.Substring(index+1));
                //}
                Thread.Sleep(1000);

            }


            
            Console.WriteLine("The server is quit...");
            Thread.Sleep(1000);

            Environment.Exit(0);



        }



    }
}
