using System;
using System.Net;

namespace Worker
{
    class Program
    {
        static void Main(string[] args)
        {
            Worker worker = new Worker(IPEndPoint.Parse(args[0]));

        worker.Run(task => null);
        }
    }
}