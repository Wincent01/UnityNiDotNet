using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiTransformController : NiKeyframeController
    {
        public NiTransformController(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
        }
    }
}