using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Messaging;

namespace IPCMQClient
{
    class IPCMQClient
    {
        string mQueueName = @".\private$\ipcTest";
        MessageQueue mq;

        public IPCMQClient()
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

        public string WriteToQueue(string data)
        {
            string result = "OK";

            mq.Send(data);

            mq.Close();

            return result;
            
        }
    }
}
