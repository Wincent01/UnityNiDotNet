using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiBoolInterpolator : NiKeyBasedInterpolator
    {
        public NiBoolean Value { get; set; }
        
        public NiRef<NiBoolData> Data { get; set; }
        
        public NiBoolInterpolator(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
            Value = new NiBoolean(reader);

            Data = new NiRef<NiBoolData>(niFile, reader.ReadInt32());
        }
    }
}