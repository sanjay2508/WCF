using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;


namespace CalcForWCF
{
    [CallbackBehavior (UseSynchronizationContext = false)]
    public class Program : ServiceReference1.IService1Callback
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.abc();
        }

        public void abc() {
            InstanceContext s = new InstanceContext(this);
            ServiceReference1.Service1Client svc = new ServiceReference1.Service1Client(s);
            svc.GetData(0);
        }

        void ServiceReference1.IService1Callback.Progress(int value)
        {            
            Console.WriteLine(value + "% process completed");
        }
    }
}
