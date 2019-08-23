using System.IO;
using NiDotNet.NIF.Enums;

namespace NiDotNet.NIF.Nodes
{
    public class NiPixelFormat : NiObject
    {
        public PixelFormat PixelFormat { get; set; }
        
        public byte BitsPerPixel { get; set; }
        
        public uint RendererHint { get; set; }
        
        public uint ExtraData { get; set; }
        
        public byte Flags { get; set; }
        
        public PixelTiling Tiling { get; set; }
        
        public NiBoolean SRGBSpace { get; set; }
        
        public PixelFormatComponent[] Channels { get; set; }
        
        public NiPixelFormat(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
            PixelFormat = (PixelFormat) reader.ReadUInt32();

            BitsPerPixel = reader.ReadByte();

            RendererHint = reader.ReadUInt32();

            ExtraData = reader.ReadUInt32();

            Flags = reader.ReadByte();

            Tiling = (PixelTiling) reader.ReadUInt32();
            
            SRGBSpace = new NiBoolean(reader);

            Channels = new PixelFormatComponent[4];

            for (var i = 0; i < 4; i++)
            {
                Channels[i] = new PixelFormatComponent(reader, niFile);
            }
        }
    }
}