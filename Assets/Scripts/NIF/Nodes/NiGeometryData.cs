using System.IO;
using NiDotNet.NIF.Enums;

namespace NiDotNet.NIF.Nodes
{
    public class NiGeometryData : NiObject
    {
        public int GroupId { get; set; }

        public ushort VerticesCount { get; set; }

        public byte KeepFlags { get; set; }

        public byte CompressFlags { get; set; }

        public NiBoolean HasVertices { get; set; }

        public NiVector3[] Vertices { get; set; }

        public VectorFlags VectorSettings { get; set; }

        public NiBoolean HasNormals { get; set; }

        public NiVector3[] Normals { get; set; }

        public NiVector3 Center { get; set; }

        public float Radius { get; set; }

        public short[] LuSpecificShorts { get; set; }

        public NiBoolean HasVertexColors { get; set; }

        public NiColor4[] VertexColors { get; set; }

        public ConsistencyType Consistency { get; set; }

        public NiRef<AbstractAdditionalGeometryData> AdditionData { get; set; }

        public ushort NumUvSets { get; set; }

        public NiBoolean HasUv { get; set; }

        public NiTexCoord[][] Uv { get; set; }

        public NiVector3[] Tangents { get; set; }

        public NiVector3[] BitTangents { get; set; }

        public NiGeometryData(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
            if ((int) niFile.Header.NifVersion >= 0x0A020000)
            {
                GroupId = reader.ReadInt32();
            }

            VerticesCount = reader.ReadUInt16();

            if ((int) niFile.Header.NifVersion >= 0x0A010000)
            {
                KeepFlags = reader.ReadByte();
                CompressFlags = reader.ReadByte();
            }

            HasVertices = new NiBoolean(reader);
            if (HasVertices)
            {
                Vertices = new NiVector3[VerticesCount];
                for (uint i = 0; i < VerticesCount; i++)
                {
                    Vertices[i] = new NiVector3(reader, niFile);
                }
            }

            if ((int) niFile.Header.NifVersion >= 0x0A000100 &&
                !((int) niFile.Header.NifVersion >= 0x14020007 && niFile.Header.UserVersion >= 11))
            {
                NumUvSets = reader.ReadUInt16();
            }

            HasNormals = new NiBoolean(reader);
            if (HasNormals)
            {
                Normals = new NiVector3[VerticesCount];
                for (uint i = 0; i < VerticesCount; i++)
                {
                    Normals[i] = new NiVector3(reader, niFile);
                }
            }

            if ((int) niFile.Header.NifVersion >= 0x0A010000)
            {
                if (HasNormals && (NumUvSets & 61440) != 0)
                {
                    Tangents = new NiVector3[VerticesCount];
                    for (uint i = 0; i < VerticesCount; i++)
                    {
                        Tangents[i] = new NiVector3(reader, niFile);
                    }

                    BitTangents = new NiVector3[VerticesCount];
                    for (uint i = 0; i < VerticesCount; i++)
                    {
                        BitTangents[i] = new NiVector3(reader, niFile);
                    }
                }
            }

            Center = new NiVector3(reader, niFile);
            Radius = reader.ReadSingle();

            HasVertexColors = new NiBoolean(reader);
            if (HasVertexColors)
            {
                VertexColors = new NiColor4[VerticesCount];
                for (uint i = 0; i < VerticesCount; i++)
                {
                    VertexColors[i] = new NiColor4(reader, niFile);
                }
            }

            if ((int) niFile.Header.NifVersion <= 0x04020200)
            {
                NumUvSets = reader.ReadUInt16();
            }

            if ((int) niFile.Header.NifVersion <= 0x04000002)
            {
                HasUv = new NiBoolean(reader);
            }

            Uv = new NiTexCoord[(NumUvSets & 63) | (0 & 1)][];
            for (uint i = 0; i < Uv.Length; i++)
            {
                Uv[i] = new NiTexCoord[VerticesCount];
                for (uint j = 0; j < VerticesCount; j++)
                {
                    Uv[i][j] = new NiTexCoord(reader, niFile);
                }
            }

            if ((int) niFile.Header.NifVersion >= 0x0A000100 && niFile.Header.UserVersion < 12)
            {
                Consistency = (ConsistencyType) reader.ReadUInt16();
            }

            if ((int) niFile.Header.NifVersion >= 0x14000004 && niFile.Header.UserVersion < 12)
            {
                var blockNum = reader.ReadUInt32();
                AdditionData = new NiRef<AbstractAdditionalGeometryData>(niFile, (int) blockNum);
            }
        }
    }
}