using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiSpecularProperty : NiProperty
    {
        public short Flags { get; set; }

        public NiSpecularProperty(BinaryReader reader, NiFile file) : base(reader, file)
        {
            Flags = reader.ReadInt16();
        }
    }
}