using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiInterpController : NiTimeController
    {
        public NiInterpController(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
        }
    }
}