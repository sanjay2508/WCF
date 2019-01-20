using System;
using System.ServiceModel;

namespace host
{
    public class Program
    {
        static void Main(string[] args)
        {
            using(ServiceHost host = new ServiceHost(typeof(Myservice.Service1)))
            {
                host.Open();
                Console.WriteLine("host started");
                //Myservice.Service1 s = new Myservice.Service1();
                //int z = s.GetData(0);
                Console.ReadLine();
            }
        }
    }
}
