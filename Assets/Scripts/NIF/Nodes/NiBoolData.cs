using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiBoolData : NiObject
    {
        public NiKeyGroup<NiByte> Data { get; set; }
        
        public NiBoolData(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
            Data = new NiKeyGroup<NiByte>(reader, niFile);
        }
    }
}