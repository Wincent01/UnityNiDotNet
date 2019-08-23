using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiBoneData : NiObject
    {
        public NiTransform Transform { get; set; }

        public NiVector3 BoundingSphereOffset { get; set; }

        public float BoundingSphereRadius { get; set; }

        public ushort VertexCount { get; set; }

        public NiBoneVertData[] Weights { get; set; }

        public NiBoneData(BinaryReader reader, NiFile niFile, bool hasVertexWeights) : base(reader, niFile)
        {
            Transform = new NiTransform(reader, niFile);

            BoundingSphereOffset = new NiVector3(reader, niFile);

            BoundingSphereRadius = reader.ReadSingle();

            VertexCount = reader.ReadUInt16();

            if (!hasVertexWeights) return;
            Weights = new NiBoneVertData[VertexCount];
            for (var i = 0; i < VertexCount; i++)
            {
                Weights[i] = new NiBoneVertData(reader, niFile);
            }
        }
    }
}