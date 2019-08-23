using System.IO;
using NiDotNet.NIF.Enums;

namespace NiDotNet.NIF.Nodes
{
    public class NiSwitchNode : NiNode
    {
        public NiSwitchFlags Flags { get; set; }

        public uint Index { get; set; }

        public NiSwitchNode(BinaryReader reader, NiFile file) : base(reader, file)
        {
            Flags = (NiSwitchFlags) reader.ReadUInt16();
            Index = reader.ReadUInt32();
        }
    }
}