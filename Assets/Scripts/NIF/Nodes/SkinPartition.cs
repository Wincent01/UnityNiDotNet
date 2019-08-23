using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class SkinPartition : NiObject
    {
        public ushort VerticesCount { get; set; }

        public ushort TrianglesCount { get; set; }

        public ushort BonesCount { get; set; }

        public ushort StripsCount { get; set; }

        public ushort WeightsPerVertex { get; set; }

        public ushort[] Bones { get; set; }

        public NiBoolean HasVertexMap { get; set; }

        public ushort[] VertexMap { get; set; }

        public NiBoolean HasVertexWeights { get; set; }

        public float[,] VertexWeights { get; set; }

        public ushort[] StripsLengths { get; set; }

        public NiBoolean HasFaces { get; set; }

        public ushort[,] Strips { get; set; }

        public NiTriangle[] Triangles { get; set; }

        public NiBoolean HasBoneIndices { get; set; }

        public byte[,] BoneIndices { get; set; }

        public SkinPartition(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
            VerticesCount = reader.ReadUInt16();

            TrianglesCount = reader.ReadUInt16();

            BonesCount = reader.ReadUInt16();

            StripsCount = reader.ReadUInt16();

            WeightsPerVertex = reader.ReadUInt16();

            Bones = new ushort[BonesCount];
            for (var i = 0; i < BonesCount; i++)
            {
                Bones[i] = reader.ReadUInt16();
            }

            HasVertexMap = new NiBoolean(reader);

            if (HasVertexMap)
            {
                VertexMap = new ushort[VerticesCount];

                for (var i = 0; i < VerticesCount; i++)
                {
                    VertexMap[i] = reader.ReadUInt16();
                }
            }

            HasVertexWeights = new NiBoolean(reader);

            if (HasVertexWeights)
            {
                VertexWeights = new float[VerticesCount, WeightsPerVertex];

                for (var i = 0; i < VerticesCount; i++)
                {
                    for (var j = 0; j < WeightsPerVertex; j++)
                    {
                        VertexWeights[i, j] = reader.ReadSingle();
                    }
                }
            }

            StripsLengths = new ushort[StripsCount];
            for (var i = 0; i < StripsCount; i++)
            {
                StripsLengths[i] = reader.ReadUInt16();
            }

            HasFaces = new NiBoolean(reader);

            if (HasFaces && StripsCount != 0)
            {
                Strips = new ushort[StripsCount, StripsLengths.Length];

                for (var i = 0; i < StripsCount; i++)
                {
                    for (var j = 0; j < StripsLengths.Length; j++)
                    {
                        Strips[i, j] = reader.ReadUInt16();
                    }
                }
            }

            if (HasFaces && StripsCount == 0)
            {
                Triangles = new NiTriangle[TrianglesCount];

                for (var i = 0; i < TrianglesCount; i++)
                {
                    Triangles[i] = new NiTriangle(reader, niFile);
                }
            }

            HasBoneIndices = new NiBoolean(reader);
            
            if (!HasBoneIndices) return;
            {
                BoneIndices = new byte[VerticesCount, WeightsPerVertex];

                for (var i = 0; i < VerticesCount; i++)
                {
                    for (var j = 0; j < WeightsPerVertex; j++)
                    {
                        BoneIndices[i, j] = reader.ReadByte();
                    }
                }
            }
        }
    }
}