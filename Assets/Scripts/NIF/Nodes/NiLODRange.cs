using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiLODRange : NiObject
    {
        public float Near { get; set; }

        public float Far { get; set; }

        public NiLODRange(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
            Near = reader.ReadSingle();
            Far = reader.ReadSingle();
        }
    }
}