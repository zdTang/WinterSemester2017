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
        string mQueueName = @".\private$\ipcTest";
        public  MessageQueue mq;

        
        public IPCMQClient()
        {
            if (!MessageQueue.Exists(mQueueName))
            {

                // No queue exit, complain and quit.
                Console.WriteLine("no server exist!");
                Client.isExist = false;
               
            }
            else
            {
                // find the Queue, then make a reference to use the Queue
                Console.WriteLine("find server!");
                mq = new MessageQueue(mQueueName);
            }


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
        public void ReadFromQueueu()
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
                Thread.Sleep(1000);

            }


            
            Console.WriteLine("The server is quit...");
            Thread.Sleep(1000);

            Environment.Exit(0);



        }



    }
}
