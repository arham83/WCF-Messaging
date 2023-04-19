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
        }

        [Benchmark]
        public void MessagePackSerialization_SFM()
        {
            MessagePackSerializer.Serialize(SFM);
        }
        [Benchmark]
        public void MessagePackDeserialization_SFM()
        {
            MessagePackSerializer.Deserialize<FullMessage>(mpBytes1);
        }
        [Benchmark]
        public void MessagePackSerialization_SOM()
        {
            MessagePackSerializer.Serialize(SOM);
        }
        [Benchmark]
        public void MessagePackDeserialization_SOM()
        {
            MessagePackSerializer.Deserialize<OptimizedMessage>(mpBytes2);
        }

        [Benchmark]
        public void MessagePackSerialization_BFM()
        {
            MessagePackSerializer.Serialize(BFM);
        }
        [Benchmark]
        public void MessagePackDeserialization_BFM()
        {
            MessagePackSerializer.Deserialize<FullMessage>(mpBytes3);
        }
        [Benchmark]
        public void MessagePackSerialization_BOM()
        {
            MessagePackSerializer.Serialize(BOM);
        }
        [Benchmark]
        public void MessagePackDeserialization_BOM()
        {
            MessagePackSerializer.Deserialize<OptimizedMessage>(mpBytes4);
        }
    }
}
