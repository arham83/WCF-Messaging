using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagePack;

namespace WCF.Client.Message
{
    [MessagePackObject]

    public class OptimizedMessage
    {
        [Key(0)]
        public List<StructureDefinition> Header { get; set; }
        [Key(1)]
        public string Rows { get; set; }
    }
}
