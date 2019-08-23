using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiVisController : NiBoolInterpController
    {
        public NiVisController(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
        }
    }
}