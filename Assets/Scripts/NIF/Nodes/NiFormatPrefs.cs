using System.IO;
using NiDotNet.NIF.Enums;

namespace NiDotNet.NIF.Nodes
{
    public class NiFormatPrefs : NiObject
    {
        public PixelLayout Pixel { get; set; }

        public MipMapFormat MipMap { get; set; }

        public AlphaFormat Alpha { get; set; }

        public NiFormatPrefs(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
            Pixel = (PixelLayout) reader.ReadUInt32();
            MipMap = (MipMapFormat) reader.ReadUInt32();
            Alpha = (AlphaFormat) reader.ReadUInt32();
        }
    }
}