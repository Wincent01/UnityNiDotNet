using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiRawImageData : NiObject
    {
        public NiRawImageData(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
        }
    }
}