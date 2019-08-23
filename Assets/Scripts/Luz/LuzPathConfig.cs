using System.IO;
using NiDotNet.NIF.Nodes;

namespace Luz
{
    public class LuzPathConfig
    {
        public NiString ConfigName { get; set; }
        
        public NiString ConfigTypeAndValue { get; set; }
        
        public LuzPathConfig(BinaryReader reader)
        {
            ConfigName = new NiString(reader, true, true);
            ConfigTypeAndValue = new NiString(reader, true, true);
        }
    }
}