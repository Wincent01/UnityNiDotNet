using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiSkinData : NiObject
    {
        public NiTransform Transform { get; set; }

        public uint BonesCount { get; set; }

        //public NiRef<NiSkinPartition> SkinPartition { get; set; }

        public byte HasVertexWeights { get; set; }

        public NiBoneData[] BoneList { get; set; }

        public NiSkinData(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
            Transform = new NiTransform(reader, niFile);

            BonesCount = reader.ReadUInt32();

            HasVertexWeights = reader.ReadByte();

            BoneList = new NiBoneData[BonesCount];
            for (var i = 0; i < BonesCount; i++)
            {
                BoneList[i] = new NiBoneData(reader, niFile, new NiBoolean(HasVertexWeights != 0));
            }
        }
    }
}