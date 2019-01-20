using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Myservice
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract (CallbackContract = typeof(IService1Callback))]
    //[ServiceContract]
    public interface IService1
    {
        [OperationContract (IsOneWay=true)]
        void GetData(int value);

        [OperationContract]
        int Division(int a,int b);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        bool MoneyTransfer(int a, int b);

    }

    public interface IService1Callback
    {
        [OperationContract (IsOneWay=true)]
        void Progress(int value);

    }    
}
