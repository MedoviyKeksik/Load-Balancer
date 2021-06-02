using System;

namespace LoadBalancer
{
    class Program
    {
        static void Main(string[] args)
        {
            LoadBalancer loadBalancer = new LoadBalancer();
            loadBalancer.Run();
        }
    }
}
