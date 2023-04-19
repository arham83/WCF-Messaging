using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.Client.BenchMarkIT;
using WCF.Client.Message;
using WCF.Client.SerializerDeserializer;

namespace WCF.Client
{
    class Program
    {
        static void Main(string[] args)
        {

            var summary2 = BenchmarkRunner.Run<BenchMarkSmallMessages>();
            /*
            var SFM = JsonHandler.DeserializeJson<FullMessage>(@"D:\LayerOne\Project - MessagePack\Github\WCF-Messaging\WCF.Client\WCF.Client\SampleMessages\smallFull.json");
            var bytes = MessagePackHandler.Serialize(SFM);
            Console.WriteLine(bytes.Length);
            MessagingService.MessageServiceClient Client = new MessagingService.MessageServiceClient("CustomBinding_IMessageService");
            //var message = new byte[10485760];
            //Console.WriteLine(message.Length);
            Client.GetMessages(bytes);
            Console.WriteLine("Message Sent Sucessfully 1");
            var samp = MessagePackHandler.Deserialize<FullMessage>(bytes);
            Console.WriteLine(samp.Header[0].Name);
            SFM = JsonHandler.DeserializeJson<FullMessage>(@"D:\LayerOne\Project - MessagePack\Github\WCF-Messaging\WCF.Client\WCF.Client\SampleMessages\bigFull.json");
            bytes = MessagePackHandler.Serialize(SFM);
            Console.WriteLine(bytes.Length);
            Client.GetMessages(bytes);
            Console.WriteLine("Message Sent Sucessfully 2");
            samp = MessagePackHandler.Deserialize<FullMessage>(bytes);
            Console.WriteLine(samp.Header[0].Name);
            var OM = JsonHandler.DeserializeJson<OptimizedMessage>(@"D:\LayerOne\Project - MessagePack\Github\WCF-Messaging\WCF.Client\WCF.Client\SampleMessages\smallOptimized.json");
            bytes = MessagePackHandler.Serialize(OM);
            Console.WriteLine(bytes.Length);
            Client.GetMessages(bytes);
            Console.WriteLine("Message Sent Sucessfully 3");
            var samp2 = MessagePackHandler.Deserialize<OptimizedMessage>(bytes);
            Console.WriteLine(samp2.Header[0].Name);
            OM = JsonHandler.DeserializeJson<OptimizedMessage>(@"D:\LayerOne\Project - MessagePack\Github\WCF-Messaging\WCF.Client\WCF.Client\SampleMessages\bigOptimized.json");
            bytes = MessagePackHandler.Serialize(OM);
            Console.WriteLine(bytes.Length);
            Client.GetMessages(bytes);
            Console.WriteLine("Message Sent Sucessfully 4");
            samp2 = MessagePackHandler.Deserialize<OptimizedMessage>(bytes);
            Console.WriteLine(samp.Header[0].Name);
            Console.ReadLine();
            */
        }
    }
}
