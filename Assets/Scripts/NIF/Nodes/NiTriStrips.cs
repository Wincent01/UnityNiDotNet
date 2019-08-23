using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiTriStrips : NiTriBasedGeom
    {
        public NiTriStrips(BinaryReader reader, NiFile file) : base(reader, file)
        {
        }
    }
}