using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiFloatInterpolator : NiKeyBasedInterpolator
    {
        public float Value { get; set; }
        
        public NiRef<NiFloatData> Data { get; set; }
        
        public NiFloatInterpolator(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
            Value = reader.ReadSingle();

            Data = new NiRef<NiFloatData>(niFile, reader.ReadInt32());
        }
    }
}