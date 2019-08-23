using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiVertexColorProperty : NiProperty
    {
        public short Flags { get; set; }

        public NiVertexColorProperty(BinaryReader reader, NiFile file) : base(reader, file)
        {
            Flags = reader.ReadInt16();
        }
    }
}