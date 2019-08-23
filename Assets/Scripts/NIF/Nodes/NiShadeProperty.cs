using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiShadeProperty : NiProperty
    {
        public short Flags { get; set; }

        public NiShadeProperty(BinaryReader reader, NiFile file) : base(reader, file)
        {
            Flags = reader.ReadInt16();
        }
    }
}