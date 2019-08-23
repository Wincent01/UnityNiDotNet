using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiTriBasedGeomData : NiGeometryData
    {
        public ushort TriangleCount { get; set; }

        public NiTriBasedGeomData(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
            TriangleCount = reader.ReadUInt16();
        }
    }
}