using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiBoneVertData : NiObject
    {
        public ushort Index { get; set; }

        public float Weight { get; set; }

        public NiBoneVertData(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
            Index = reader.ReadUInt16();

            Weight = reader.ReadSingle();
        }
    }
}