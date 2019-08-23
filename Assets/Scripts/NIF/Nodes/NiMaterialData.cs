using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiMaterialData : NiObject
    {
        public string[] Materials { get; set; }

        public int[] MaterialExtraData { get; set; }

        public int ActiveMaterial { get; set; }

        public NiMaterialData(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
            Materials = new string[reader.ReadUInt32()];
            MaterialExtraData = new int[Materials.Length];

            for (var i = 0; i < Materials.Length; i++)
            {
                Materials[i] = new NiString(reader);
                MaterialExtraData[i] = reader.ReadInt32();
            }

            ActiveMaterial = reader.ReadInt32();
        }
    }
}