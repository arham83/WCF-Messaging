using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace WCF.Host
{
    class Program
    {
        static void Main()
        {
            // create an instance of the HttpTransportBindingElement
            var httpBinding = new HttpTransportBindingElement();

            // combine the two binding elements to create a custom binding
            //var customBinding = new CustomBinding(gzipBinding, httpBinding);

            // create a new instance of the service client using the custom binding
            using (ServiceHost host = new ServiceHost(typeof(WCF.Service.MessagingService)))
            {
                //host.AddServiceEndpoint(typeof(WCFMessaging.Service1), customBinding, "");

                // This will open the service for Communication
                host.Open();
                Console.WriteLine("Host Started on port: 8080 @: " + DateTime.Now.ToString());
                Console.ReadLine();
            }
        }
    }
}
