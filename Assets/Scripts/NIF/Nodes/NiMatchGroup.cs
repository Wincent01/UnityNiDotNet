using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiMatchGroup : NiObject
    {
        public ushort VerticesCount { get; set; }

        public ushort[] VertexIndices { get; set; }

        public NiMatchGroup(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
            VerticesCount = reader.ReadUInt16();
            VertexIndices = new ushort[VerticesCount];

            for (var i = 0; i < VerticesCount; i++)
            {
                VertexIndices[i] = reader.ReadUInt16();
            }
        }
    }
}