using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiStringExtraData : NiExtraData
    {
        public string String { get; set; }

        public NiStringExtraData(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
            return;
            String = new NiString(reader);
        }
    }
}