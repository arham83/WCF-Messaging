using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagePack;
using BenchmarkDotNet.Attributes;
using WCF.Client.Message;
using WCF.Client.SerializerDeserializer;
using System.IO;

namespace WCF.Client.BenchMarkIT
{
    public class BenchMarkSmallMessages
    {
        private readonly FullMessage SFM;
        private readonly Byte[] mpBytes1;
        private readonly OptimizedMessage SOM;
        private readonly Byte[] mpBytes2;
        private readonly FullMessage BFM;
        private readonly Byte[] mpBytes3;
        private readonly OptimizedMessage BOM;
        private readonly Byte[] mpBytes4;
        private readonly MessagingService.MessageServiceClient Client;

        public BenchMarkSmallMessages()
        {
            SFM = JsonHandler.DeserializeJson<FullMessage>(@"D:\LayerOne\Project - MessagePack\PonePOC - WCF using MessagePack_v3\WCFsender\WCFsender\Messages\smallFull.json");
            BFM = JsonHandler.DeserializeJson<FullMessage>(@"D:\LayerOne\Project - MessagePack\PonePOC - WCF using MessagePack_v3\WCFsender\WCFsender\Messages\bigFull.json");
            SOM = JsonHandler.DeserializeJson<OptimizedMessage>(@"D:\LayerOne\Project - MessagePack\PonePOC - WCF using MessagePack_v3\WCFsender\WCFsender\Messages\smallOptimized.json");
            BOM = JsonHandler.DeserializeJson<OptimizedMessage>(@"D:\LayerOne\Project - MessagePack\PonePOC - WCF using MessagePack_v3\WCFsender\WCFsender\Messages\bigOptimized.json");
            mpBytes1 = MessagePackSerializer.Serialize(SFM);
            mpBytes2 = MessagePackSerializer.Serialize(SOM);
            mpBytes3 = MessagePackSerializer.Serialize(BFM);
            mpBytes4 = MessagePackSerializer.Serialize(BOM);
            Client = new MessagingService.MessageServiceClient("CustomBinding_IMessageService");

        }


        // Small Full Sized Message 
        [Benchmark]
        public void MessagePackSerialization_SFM()
        {
            MessagePackSerializer.Serialize(SFM);
        }
        [Benchmark]
        public void TransmissionTime_UsingWCF_Msg1()
        {
            Client.GetMessages(mpBytes1);
        }
        [Benchmark]
        public void MessagePackDeserialization_SFM()
        {
            MessagePackSerializer.Deserialize<FullMessage>(mpBytes1);
        }

        // Small Optimized Message 

        [Benchmark]
        public void MessagePackSerialization_SOM()
        {
            MessagePackSerializer.Serialize(SOM);
        }
        [Benchmark]
        public void TransmissionTime_UsingWCF_Msg2()
        {
            Client.GetMessages(mpBytes2);
        }
        [Benchmark]
        public void MessagePackDeserialization_SOM()
        {
            MessagePackSerializer.Deserialize<OptimizedMessage>(mpBytes2);
        }

        // Big Full Sized Message 

        [Benchmark]
        public void MessagePackSerialization_BFM()
        {
            MessagePackSerializer.Serialize(BFM);
        }
        [Benchmark]
        public void TransmissionTime_UsingWCF_Msg3()
        {
            Client.GetMessages(mpBytes3);
        }
        [Benchmark]
        public void MessagePackDeserialization_BFM()
        {
            MessagePackSerializer.Deserialize<FullMessage>(mpBytes3);
        }

        // Big Optimized Message 

        [Benchmark]
        public void MessagePackSerialization_BOM()
        {
            MessagePackSerializer.Serialize(BOM);
        }
        [Benchmark]
        public void TransmissionTime_UsingWCF_Msg4()
        {
            Client.GetMessages(mpBytes4);
        }
        [Benchmark]
        public void MessagePackDeserialization_BOM()
        {
            MessagePackSerializer.Deserialize<OptimizedMessage>(mpBytes4);
        }
    }
}
