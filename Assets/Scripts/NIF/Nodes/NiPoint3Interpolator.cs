using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiPoint3Interpolator : NiKeyBasedInterpolator
    {
        public NiVector3 Value { get; set; }

        public NiRef<NiPosData> Data { get; set; }

        public NiPoint3Interpolator(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
            Value = new NiVector3(reader, niFile);

            Data = new NiRef<NiPosData>(niFile, reader.ReadInt32());
        }
    }
}