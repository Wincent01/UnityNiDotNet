using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiKeyBasedInterpolator : NiInterpolator
    {
        public NiKeyBasedInterpolator(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
        }
    }
}