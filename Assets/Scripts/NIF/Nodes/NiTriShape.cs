using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiTriShape : NiTriBasedGeom
    {
        public NiTriShape(BinaryReader reader, NiFile file) : base(reader, file)
        {
        }
    }
}