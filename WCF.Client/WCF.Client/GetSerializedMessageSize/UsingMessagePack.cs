using MessagePack;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.Client.Message;
using WCF.Client.SerializerDeserializer;

namespace WCF.Client.SerializedMessageSize
{
    class UsingMessagePack
    {
        public static void GetSerializedMessageSize()
        {
            var SFM = JsonHandler.DeserializeJson<FullMessage>(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "SampleMessages", "smallFull.json"));
            var BFM = JsonHandler.DeserializeJson<FullMessage>(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "SampleMessages", "bigFull.json"));
            var SOM = JsonHandler.DeserializeJson<OptimizedMessage>(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "SampleMessages", "smallOptimized.json"));
            var BOM = JsonHandler.DeserializeJson<OptimizedMessage>(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "SampleMessages", "bigOptimized.json"));
            var mpBytes1 = MessagePackSerializer.Serialize(SFM);
            var mpBytes2 = MessagePackSerializer.Serialize(SOM);
            var mpBytes3 = MessagePackSerializer.Serialize(BFM);
            var mpBytes4 = MessagePackSerializer.Serialize(BOM);
            Console.WriteLine("Serialized Message Size Using Message Pack - SFM " + mpBytes1.Length);
            Console.WriteLine("Serialized Message Size Using Message Pack - BFM " + mpBytes2.Length);
            Console.WriteLine("Serialized Message Size Using Message Pack - SOM " + mpBytes3.Length);
            Console.WriteLine("Serialized Message Size Using Message Pack - BOM " + mpBytes4.Length);
        }
    }
    public class UsingProtobufDotNet
    {
        public static void GetSerializedMessageSize()
        {
           
            var SOM = JsonHandler.DeserializeJson<OptimizedMessage>(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "SampleMessages", "smallOptimized.json"));
            var BOM = JsonHandler.DeserializeJson<OptimizedMessage>(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "SampleMessages", "bigOptimized.json"));
            byte[] pbBytes1;
            byte[] pbBytes2;
            using (var stream = new MemoryStream())
            {
                Serializer.Serialize(stream, SOM);
                pbBytes1 = stream.ToArray();
            }
            using (var stream = new MemoryStream())
            {
                Serializer.Serialize(stream, BOM);
                pbBytes2 = stream.ToArray();
            }
            Console.WriteLine("Serialized Message Size Using ProtoBufDotNet - SOM " + pbBytes1.Length);
            Console.WriteLine("Serialized Message Size Using ProtoBufDotNet  - BOM " + pbBytes2.Length);
        }
    }
    public class UsingTypicalBinary
    {
        public static void GetSerializedMessageSize()
        {
            var SFM = JsonHandler.DeserializeJson<FullMessage>(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "SampleMessages", "smallFull.json"));
            var BFM = JsonHandler.DeserializeJson<FullMessage>(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "SampleMessages", "bigFull.json"));
            var SOM = JsonHandler.DeserializeJson<OptimizedMessage>(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "SampleMessages", "smallOptimized.json"));
            var BOM = JsonHandler.DeserializeJson<OptimizedMessage>(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "SampleMessages", "bigOptimized.json"));
            var DBytes1 = BinarySerialization.Serialize<FullMessage>(SFM);
            var DBytes2 = BinarySerialization.Serialize<OptimizedMessage>(SOM);
            var DBytes3 = BinarySerialization.Serialize<FullMessage>(BFM);
            var DBytes4 = BinarySerialization.Serialize<OptimizedMessage>(BOM);
            Console.WriteLine("Serialized Message Size Using Message Pack - SFM " + DBytes1.Length);
            Console.WriteLine("Serialized Message Size Using Message Pack - BFM " + DBytes3.Length);
            Console.WriteLine("Serialized Message Size Using Message Pack - SOM " + DBytes2.Length);
            Console.WriteLine("Serialized Message Size Using Message Pack - BOM " + DBytes4.Length);
        }
    }
}
