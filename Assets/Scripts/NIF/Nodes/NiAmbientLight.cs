using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiAmbientLight : NiLight
    {
        public NiAmbientLight(BinaryReader reader, NiFile file) : base(reader, file)
        {
        }
    }
}