using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiBoolInterpController : NiSingleInterpController
    {
        public NiBoolInterpController(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
        }
    }
}