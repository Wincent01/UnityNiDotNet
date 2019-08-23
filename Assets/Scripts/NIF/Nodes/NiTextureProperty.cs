using System.IO;

namespace NiDotNet.NIF.Nodes
{
    /// <summary>
    /// Should not be used in LU
    /// </summary>
    public class NiTextureProperty : NiProperty
    {
        public short Flags { get; set; }

        public NiRef<NiImage> Image { get; set; }

        public NiTextureProperty(BinaryReader reader, NiFile file) : base(reader, file)
        {
            Flags = reader.ReadInt16();

            Image = new NiRef<NiImage>(file, reader.ReadInt32());
        }
    }
}