using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiMatrix2X2 : NiObject
    {
        public float m11 { get; set; }

        public float m21 { get; set; }

        public float m12 { get; set; }

        public float m22 { get; set; }

        public NiMatrix2X2(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
            m11 = reader.ReadSingle();
            m21 = reader.ReadSingle();
            m12 = reader.ReadSingle();
            m22 = reader.ReadSingle();
        }
    }
}