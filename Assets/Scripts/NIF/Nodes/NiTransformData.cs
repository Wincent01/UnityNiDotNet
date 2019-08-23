using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiTransformData : NiKeyframeData
    {
        public NiTransformData(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
        }
    }
}