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
            if (!MessageQueue.Exists(mQueueName))
            {
                mq = MessageQueue.Create(mQueueName);
            }
            else
            {
                mq = new MessageQueue(mQueueName);
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
                    //mq.MessageReadPropertyFilter.ClearAll();
                    //Message emptyMessage = mq.Peek();
                    string message = (string)mq.Receive().Body;
                    //string message = (string)mq.Peek().Body;
                    //string message = (string)mq.Receive(new TimeSpan(0, 0, 1)).Body;
                    if (message != null)
                    {
                        Console.WriteLine(message);
                       // Console.WriteLine("new message");
                       // Console.ReadKey();
                        if (message == "Shutdown")
                        {
                            finished = true;
                        }
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

        }
    }
}
