using System.IO;
using NiDotNet.NIF.Enums;

namespace NiDotNet.NIF.Nodes
{
    public class NiPersistentSrcTextureRendererData : NiPixelFormat
    {
        public NiRef<NiPalette> Palette { get; set; }

        public uint MipMapCount { get; set; }

        public uint BytesPerPixel { get; set; }

        public NiMipMap[] MipMaps { get; set; }

        public uint PixelCount { get; set; }

        public uint FacesCount { get; set; }

        public PlatformId Platform { get; set; }

        public byte[] PixelData { get; set; }
        
        public uint PadPixelCount { get; set; }
        
        public NiPersistentSrcTextureRendererData(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
            Palette = new NiRef<NiPalette>(niFile, reader.ReadInt32());

            MipMapCount = reader.ReadUInt32();

            BytesPerPixel = reader.ReadUInt32();

            MipMaps = new NiMipMap[MipMapCount];

            for (var i = 0; i < MipMapCount; i++)
            {
                MipMaps[i] = new NiMipMap(reader, niFile);
            }

            PixelCount = reader.ReadUInt32();

            PadPixelCount = reader.ReadUInt32();

            FacesCount = reader.ReadUInt32();

            Platform = (PlatformId) reader.ReadUInt32();
            
            PixelData = new byte[PixelCount];

            for (var i = 0; i < PixelCount; i++)
            {
                PixelData[i] = reader.ReadByte();
            }
        }
    }
}