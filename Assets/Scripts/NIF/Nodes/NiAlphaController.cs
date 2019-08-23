using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiAlphaController : NiFloatInterpController
    {
        public NiAlphaController(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
        }
    }
}