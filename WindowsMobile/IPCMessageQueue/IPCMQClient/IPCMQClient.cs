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
                
                Console.WriteLine("no server exist!");
                Client.isExist = false;
               
            }
            else
            {
                Console.WriteLine("find server!");
                mq = new MessageQueue(mQueueName);
            }


        }


        public void WriteToQueue(string data)
        {
            

            mq.Send(data);

            mq.Close();

          
            
        }
        public void ReadFromQueueu()
        {
            int pid = Process.GetCurrentProcess().Id;
            while (MessageQueue.Exists(mQueueName))
            {
                string content;
                string pidGet;
                mq.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
                content = (string)mq.Peek().Body;
                
                int index = content.IndexOf("@", 0);
                pidGet = content.Substring(0, index);
                if(pidGet!=Convert.ToString(pid))
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
