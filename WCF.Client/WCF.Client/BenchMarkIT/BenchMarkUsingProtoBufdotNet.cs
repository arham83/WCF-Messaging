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
using ProtoBuf;

namespace WCF.Client.BenchMarkIT
{
    public class BenchMarkUsingProtoBufdotNet
    {
        private readonly OptimizedMessage SOM;
        private readonly Byte[] pbBytes2;
        private readonly OptimizedMessage BOM;
        private readonly Byte[] pbBytes4;
        private readonly MessagingService.MessageServiceClient Client;

        public BenchMarkUsingProtoBufdotNet()
        {
            SOM = JsonHandler.DeserializeJson<OptimizedMessage>(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "SampleMessages", "smallOptimized.json"));
            BOM = JsonHandler.DeserializeJson<OptimizedMessage>(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "SampleMessages", "bigOptimized.json"));
            
            using (var stream = new MemoryStream())
            {
                Serializer.Serialize(stream, SOM);
                pbBytes2 = stream.ToArray();
            }
            using (var stream = new MemoryStream())
            {
                Serializer.Serialize(stream, BOM);
                pbBytes4 = stream.ToArray();
            }
            Client = new MessagingService.MessageServiceClient("CustomBinding_IMessageService");
        }


        // Small Optimized Message 

        [Benchmark]
        public void ProtoBufSerialization_SOM()
        {
            using (var stream = new MemoryStream())
            {
                Serializer.Serialize(stream, SOM);
            }
        }
        [Benchmark]
        public void TransmissionTime_UsingWCF_SOM()
        {
            Client.GetMessages(pbBytes2);
        }
        [Benchmark]
        public void ProtoBufDeserialization_SOM()
        {
            using (MemoryStream stream = new MemoryStream(pbBytes2))
            {
                // deserialize the object from the stream using the Serializer
                OptimizedMessage pbDeserialized = Serializer.Deserialize<OptimizedMessage>(stream);
            }
        }

        // Big Optimized Message 

        [Benchmark]
        public void ProtoBufSerialization_BOM()
        {
            using (var stream = new MemoryStream())
            {
                Serializer.Serialize(stream, BOM);
            }
        }
        [Benchmark]
        public void TransmissionTime_UsingWCF_BOM()
        {
            Client.GetMessages(pbBytes4);
        }
        [Benchmark]
        public void ProtoBufDeserialization_BOM()
        {
            using (MemoryStream stream = new MemoryStream(pbBytes4))
            {
                // deserialize the object from the stream using the Serializer
                OptimizedMessage pbDeserialized = Serializer.Deserialize<OptimizedMessage>(stream);
            }
        }
    }
}
