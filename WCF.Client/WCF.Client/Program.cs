using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            MessagingService.MessageServiceClient Client = new MessagingService.MessageServiceClient("BasicHttpBinding_IMessageService");
            Client.GetMessages("Message by the Client");
            Console.ReadLine();
        }
    }
}
