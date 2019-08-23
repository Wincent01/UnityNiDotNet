using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiTransform : NiObject
    {
        public NiMatrix3X3 Rotation { get; set; }

        public NiVector3 Position { get; set; }

        public float Scale { get; set; }

        public NiTransform(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
            Rotation = new NiMatrix3X3(reader, niFile);
            Position = new NiVector3(reader, niFile);
            Scale = reader.ReadSingle();
        }
    }
}