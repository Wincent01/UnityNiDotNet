using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiDirectionalLight : NiLight
    {
        public NiDirectionalLight(BinaryReader reader, NiFile file) : base(reader, file)
        {
        }
    }
}