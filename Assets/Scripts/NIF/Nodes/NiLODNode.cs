using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiLODNode : NiSwitchNode
    {
        public NiRef<NiLODData> Data { get; set; }

        public NiLODNode(BinaryReader reader, NiFile file) : base(reader, file)
        {
            Data = new NiRef<NiLODData>(file, reader.ReadInt32());
        }
    }
}