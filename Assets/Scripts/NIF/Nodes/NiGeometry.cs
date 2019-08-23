using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiGeometry : NiAVObject
    {
        public NiRef<NiGeometryData> Data { get; set; }

        public NiRef<NiSkinInstance> SkinInstance { get; set; }

        public NiMaterialData MaterialData { get; set; }

        public NiGeometry(BinaryReader reader, NiFile file) : base(reader, file)
        {
            Data = new NiRef<NiGeometryData>(file, reader.ReadInt32());

            SkinInstance = new NiRef<NiSkinInstance>(file, reader.ReadInt32());

            MaterialData = new NiMaterialData(reader, file);
        }
    }
}