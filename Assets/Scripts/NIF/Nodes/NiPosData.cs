using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiPosData : NiObject
    {
        public NiKeyGroup<NiVector3> Data { get; set; }

        public NiPosData(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
            Data = new NiKeyGroup<NiVector3>(reader, niFile);
        }
    }
}