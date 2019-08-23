using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiQuatTransform : NiObject
    {
        public NiVector3 Translation { get; set; }

        public NiQuaternion Rotation { get; set; }

        public float Scale { get; set; }

        public NiQuatTransform(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
            Translation = new NiVector3(reader, niFile);

            Rotation = new NiQuaternion(reader, niFile);

            Scale = reader.ReadSingle();
        }
    }
}