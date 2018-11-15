using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IPCMessageQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            IPCMQServer server = new IPCMQServer();
            server.GetMessages();

            Console.WriteLine("Press Enter to end...");
        }
    }
}
