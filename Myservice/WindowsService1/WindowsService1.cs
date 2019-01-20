using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace WindowsService1
{
    public partial class WindowsService1 : ServiceBase
    {
        ServiceHost host;
        public WindowsService1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            host = new ServiceHost(typeof(Myservice.Service1));
            host.Open();
        }

        protected override void OnStop()
        {
            host.Close();
        }
    }
}
