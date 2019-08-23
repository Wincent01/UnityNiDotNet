using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiMipMap : NiObject
    {
        public uint Width { get; set; }

        public uint Height { get; set; }

        public uint Offset { get; set; }

        public NiMipMap(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
            Width = reader.ReadUInt32();

            Height = reader.ReadUInt32();

            Offset = reader.ReadUInt32();
        }
    }
}