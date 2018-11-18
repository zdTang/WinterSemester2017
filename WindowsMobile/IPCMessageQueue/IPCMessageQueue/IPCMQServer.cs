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
     private static string mQueueName = @".\private$\ipcTest";
        MessageQueue mq;
        
        public IPCMQServer()
        {
            Console.WriteLine("Server is starting......!");

            if (!MessageQueue.Exists(mQueueName))
            {
                mq = MessageQueue.Create(mQueueName);  // create a new Queue
                Console.WriteLine("Create a new Queue!");

            }
            else
            {
                mq = new MessageQueue(mQueueName);
                Console.WriteLine("Find the old Queue!");  // Use the old Queue
            }

            Console.WriteLine("Waiting for client......");
        }

        public static void CloseQueue()
        {
            // Determine whether the queue exists.
            if (MessageQueue.Exists(mQueueName))
            {
                try
                {
                    // Delete the queue.
                    MessageQueue.Delete(mQueueName);
                }
                catch (MessageQueueException e)
                {
                    if (e.MessageQueueErrorCode ==
                        MessageQueueErrorCode.AccessDenied)
                    {
                        Console.WriteLine("Opreation Failed: " +
                            e.Message);
                    }

                
                }

            }

            
        }
           

        public void GetMessages()
        {
            bool finished = false;
            mq.Formatter = new XmlMessageFormatter(new Type[] {typeof(string)});

            while (!finished)
            {
                try
                {
                    
                    string message = (string)mq.Peek().Body;  // peek each Message

                          
                    int index = message.IndexOf("@", 0);

                    if (message.Substring(index+1).ToUpper() == "SHUTDOWN") // Shutdown is received
                        {

                            finished = true;
                        }
                    
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

            //MessageQueue.Delete(mQueueName);

            IPCMQServer.CloseQueue();

            Console.WriteLine("Queue shut down! ");

        }
    }
}
