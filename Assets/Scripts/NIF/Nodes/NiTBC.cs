using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiTBC : NiObject
    {
        public float Tension { get; set; }

        public float Bias { get; set; }

        public float Continuity { get; set; }

        public NiTBC(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
            Tension = reader.ReadSingle();
            Bias = reader.ReadSingle();
            Continuity = reader.ReadSingle();
        }
    }
}