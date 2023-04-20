using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF.Service
{
    public class MessagingService : IMessageService
    {
        public void GetMessages(byte[] msg)
        {
            Console.WriteLine("Hello There From Server");
            //Console.WriteLine("Client Side Message: "+ msg);
        }
    }
}
