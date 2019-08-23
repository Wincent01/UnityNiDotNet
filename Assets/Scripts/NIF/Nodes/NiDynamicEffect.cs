using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiDynamicEffect : NiAVObject
    {
        public NiBoolean SwitchState { get; set; }

        public uint AffectedNodesCount { get; set; }

        public NiPtr<NiNode>[] AffectedNodes { get; set; }

        public NiDynamicEffect(BinaryReader reader, NiFile file) : base(reader, file)
        {
            SwitchState = new NiBoolean(reader);

            AffectedNodesCount = reader.ReadUInt32();

            AffectedNodes = new NiPtr<NiNode>[AffectedNodesCount];

            for (var i = 0; i < AffectedNodesCount; i++)
            {
                AffectedNodes[i] = new NiPtr<NiNode>(file, reader.ReadInt32());
            }
        }
    }
}