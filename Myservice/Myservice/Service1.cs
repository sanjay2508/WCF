using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.IO;

namespace Myservice
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
   [ServiceBehavior (ConcurrencyMode = ConcurrencyMode.Single)]
    public class Service1 : IService1
    {
        public void GetData(int value)
        {
            Console.WriteLine("host started");
            //if (value == 0)
            //    throw new FaultException("fault exception Divide by zero exception");
            //int a = 1/value;
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(100);
                OperationContext.Current.GetCallbackChannel<IService1Callback>().Progress(i);
            }              
        }

        public int Division(int a, int b)
        {
            if (b == 0)
            {
                throw new FaultException("Denominator can't be zero");
            }
            else
                return a / b;            
        }

       [OperationBehavior(TransactionScopeRequired = true)]
        public bool MoneyTransfer(int a, int b)
        {
            try
            {
                int temp;
                temp = b;
                a = a - b;
                b = b-temp;

                StreamWriter sw = new StreamWriter("C:\\Users/sanjay/Documents/Visual Studio 2012/Projects/Myservice/Transaction.txt");
                sw.Write("Value of A {0}",a);
                sw.Write("Value of B {0}",b);
                sw.Close();

                throw new Exception("Sample exeception for testing");
                
                return true;
            }
            catch (Exception e)
            {
                throw new FaultException(e.Message);
            }

        }
    }
}
