using System.IO;

namespace NiDotNet.NIF.Nodes
{
    /*
     * TODO: Fix
     */
    public class NiTriShapeData : NiTriBasedGeomData
    {
        public uint TrianglePointCount { get; set; }

        public NiBoolean HasTriangles { get; set; }

        public NiTriangle[] Triangles { get; set; }

        public ushort MatchGroupCount { get; set; }

        public NiMatchGroup[] MatchGroups { get; set; }

        public NiTriShapeData(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
            TrianglePointCount = reader.ReadUInt32();

            HasTriangles = new NiBoolean(reader.ReadByte() != 0);

            if (HasTriangles)
            {
                Triangles = new NiTriangle[TriangleCount];
                for (var i = 0; i < TriangleCount; i++)
                {
                    Triangles[i] = new NiTriangle(reader, niFile);
                }
            }

            MatchGroupCount = reader.ReadUInt16();

            MatchGroups = new NiMatchGroup[MatchGroupCount];

            for (var i = 0; i < MatchGroupCount; i++)
            {
                try
                {
                    MatchGroups[i] = new NiMatchGroup(reader, niFile);
                }
                catch
                {
                    return;
                }
            }
        }
    }
}