using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiFloatData : NiObject
    {
        public NiKeyGroup<NiFloat> Data { get; set; }
        
        public NiFloatData(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
            Data = new NiKeyGroup<NiFloat>(reader, niFile);
        }
    }
}