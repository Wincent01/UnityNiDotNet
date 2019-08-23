using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiTransformInterpolator : NiKeyBasedInterpolator
    {
        public NiQuatTransform Transform { get; set; }

        public NiRef<NiTransformData> Data { get; set; }

        public NiTransformInterpolator(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
            Transform = new NiQuatTransform(reader, niFile);
            Data = new NiRef<NiTransformData>(niFile, reader.ReadInt32());
        }
    }
}