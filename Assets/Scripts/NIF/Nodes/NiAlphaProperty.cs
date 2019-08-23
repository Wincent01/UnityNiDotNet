using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiAlphaProperty : NiProperty
    {
        public short Flags { get; set; }

        public byte Threshold { get; set; }

        public NiAlphaProperty(BinaryReader reader, NiFile file) : base(reader, file)
        {
            Flags = reader.ReadInt16();

            Threshold = reader.ReadByte();
        }
    }
}