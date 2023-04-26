using BenchmarkDotNet.Running;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.Client.BenchMarkIT;
using WCF.Client.Message;
using WCF.Client.SerializedMessageSize;

namespace WCF.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //var summary1 = BenchmarkRunner.Run<BenchMarkUsingMessagePack>();
            //var summary2 = BenchmarkRunner.Run<BenchMarkUsingProtoBufdotNet>();
            UsingMessagePack.GetSerializedMessageSize();
            UsingProtobufDotNet.GetSerializedMessageSize();
            UsingTypicalBinary.GetSerializedMessageSize();
            Console.ReadLine();
        }
    }
}
