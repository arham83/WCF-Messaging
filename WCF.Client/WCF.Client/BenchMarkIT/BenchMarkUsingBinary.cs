using BenchmarkDotNet.Attributes;
using MessagePack;
using System;
using System.IO;
using WCF.Client.Message;
using WCF.Client.SerializerDeserializer;

namespace WCF.Client.BenchMarkIT
{

    public class BenchMarkUsingBinary
    {
        private readonly FullMessage SFM;
        private readonly Byte[] DBytes1;

        private readonly OptimizedMessage SOM;
        private readonly Byte[] DBytes2;

        private readonly FullMessage BFM;
        private readonly Byte[] DBytes3;

        private readonly OptimizedMessage BOM;
        private readonly Byte[] DBytes4;

        private readonly MessagingService.MessageServiceClient Client;

        public BenchMarkUsingBinary()
        {
      
            SFM = JsonHandler.DeserializeJson<FullMessage>(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "SampleMessages", "smallFull.json"));
            BFM = JsonHandler.DeserializeJson<FullMessage>(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "SampleMessages", "bigFull.json"));
            SOM = JsonHandler.DeserializeJson<OptimizedMessage>(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "SampleMessages", "smallOptimized.json"));
            BOM = JsonHandler.DeserializeJson<OptimizedMessage>(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "SampleMessages", "bigOptimized.json"));
            DBytes1 = BinarySerialization.Serialize<FullMessage>(SFM);
            DBytes2 = BinarySerialization.Serialize<OptimizedMessage>(SOM);
            DBytes3 = BinarySerialization.Serialize<FullMessage>(BFM);
            DBytes4 = BinarySerialization.Serialize<OptimizedMessage>(BOM);
            Client = new MessagingService.MessageServiceClient("CustomBinding_IMessageService");
        }


        [Benchmark]
        public void BinarySerialization_SFM()
        {
            BinarySerialization.Serialize<FullMessage>(SFM);
        }

        [Benchmark]
        public void TransmissionTime_UsingWCF_Msg1()
        {
            Client.GetMessages(DBytes1);
        }

        [Benchmark]

        public void BinaryDeserialization_SFM()
        {
            BinarySerialization.Deserialize<FullMessage>(DBytes1);
        }

        [Benchmark]
        public void BinarySerialization_SOM()
        {
            BinarySerialization.Serialize<OptimizedMessage>(SOM);
        }
        [Benchmark]
        public void TransmissionTime_UsingWCF_Msg2()
        {
            Client.GetMessages(DBytes2);
        }

        [Benchmark]

        public void BinaryDeserialization_SOM()

        {
            BinarySerialization.Deserialize<OptimizedMessage>(DBytes2);
        }

        [Benchmark]
        public void BinarySerialization_BFM()
        {
            BinarySerialization.Serialize<FullMessage>(BFM);
        }

        [Benchmark]
        public void TransmissionTime_UsingWCF_Msg3()
        {
            Client.GetMessages(DBytes3);
        }

        [Benchmark]

        public void BinaryDeserialization_BFM()
        {
            BinarySerialization.Deserialize<FullMessage>(DBytes3);
        }

        [Benchmark]
        public void BinarySerialization_BOM()
        {
            BinarySerialization.Serialize<OptimizedMessage>(BOM);
        }

        [Benchmark]
        public void TransmissionTime_UsingWCF_Msg4()
        {
            Client.GetMessages(DBytes4);
        }

        [Benchmark]
        public void BinaryDeserialization_BOM()
        {
            BinarySerialization.Deserialize<OptimizedMessage>(DBytes4);
        }
    }
}

