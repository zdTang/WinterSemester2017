using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Messaging;


namespace IPCMessageQueue
{
    class IPCMQServer
    {
        // ipcTest is the name of the QUEUE
        string mQueueName = @".\private$\ipcTest";
        MessageQueue mq;
        
        public IPCMQServer()
        {
            Console.WriteLine("Server is starting......!");
            if (!MessageQueue.Exists(mQueueName))
            {
                mq = MessageQueue.Create(mQueueName);
                Console.WriteLine("Create a new Queue!");

            }
            else
            {
                mq = new MessageQueue(mQueueName);
                Console.WriteLine("Find the old Queue!");
            }

            Console.WriteLine("Waiting for client......");
        }

        public void GetMessages()
        {
            bool finished = false;
            mq.Formatter = new XmlMessageFormatter(new Type[] {typeof(string)});

            while (!finished)
            {
                try
                {
                    
                    string message = (string)mq.Peek().Body;
                   
                    int index = message.IndexOf("@", 0);

                    if (message.Substring(index+1) == "Shutdown")
                        {

                            finished = true;
                        }
                    //}
                }
                catch (MessageQueueException mqex)
                {
                    Console.WriteLine("MQ Exception: " + mqex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                }
            }
           
            mq.Close();

            MessageQueue.Delete(mQueueName);
            Console.WriteLine("Server is shutting down! ");

        }
    }
}
