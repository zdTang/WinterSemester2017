﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IPCMessageQueue
{
    class Server
    {
        static void Main(string[] args)
        {
            IPCMQServer server = new IPCMQServer();
            server.GetMessages();

            Console.WriteLine("Press any key to quit the console.");
            Console.ReadKey();
        }
    }
}
