using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiKeyframeController : NiSingleInterpController
    {
        public NiKeyframeController(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
        }
    }
}