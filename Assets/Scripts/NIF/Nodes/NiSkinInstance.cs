using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiSkinInstance : NiObject
    {
        public NiRef<NiSkinData> SkinningData { get; set; }

        public NiRef<NiSkinPartition> SkinPartition { get; set; }

        public NiRef<NiNode> Root { get; set; }

        public uint BonesCount { get; set; }

        public NiPtr<NiNode>[] Bones { get; set; }

        public NiSkinInstance(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
            SkinningData = new NiRef<NiSkinData>(niFile, reader.ReadInt32());

            SkinPartition = new NiRef<NiSkinPartition>(niFile, reader.ReadInt32());

            Root = new NiRef<NiNode>(niFile, reader.ReadInt32());

            BonesCount = reader.ReadUInt32();

            Bones = new NiPtr<NiNode>[BonesCount];
            for (var i = 0; i < BonesCount; i++)
            {
                Bones[i] = new NiPtr<NiNode>(niFile, reader.ReadInt32());
            }
        }
    }
}