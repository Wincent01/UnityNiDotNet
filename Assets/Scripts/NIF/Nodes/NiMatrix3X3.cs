using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiMatrix3X3 : NiObject
    {
        public float m11 { get; set; }

        public float m21 { get; set; }

        public float m31 { get; set; }

        public float m12 { get; set; }

        public float m22 { get; set; }

        public float m32 { get; set; }

        public float m13 { get; set; }

        public float m23 { get; set; }

        public float m33 { get; set; }

        public NiMatrix3X3(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
            m11 = reader.ReadSingle();
            m21 = reader.ReadSingle();
            m31 = reader.ReadSingle();
            m12 = reader.ReadSingle();
            m22 = reader.ReadSingle();
            m32 = reader.ReadSingle();
            m13 = reader.ReadSingle();
            m23 = reader.ReadSingle();
            m33 = reader.ReadSingle();
        }
    }
}