using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiTriBasedGeom : NiGeometry
    {
        public NiTriBasedGeom(BinaryReader reader, NiFile file) : base(reader, file)
        {
        }
    }
}