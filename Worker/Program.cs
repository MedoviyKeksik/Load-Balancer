using System;
using System.Net;
using LoadBalancer;

namespace Worker
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1) Console.WriteLine("Please specify remote host");
            else
            {
                try
                {
                    Worker worker = new Worker(IPEndPoint.Parse(args[0]));
                    worker.Run(TaskProcesser.ProcessTask);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}