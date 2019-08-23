using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiExtraData : NiObject
    {
        public NiExtraData(BinaryReader Reader, NiFile niFile) : base(Reader, niFile)
        {
        }
    }
}