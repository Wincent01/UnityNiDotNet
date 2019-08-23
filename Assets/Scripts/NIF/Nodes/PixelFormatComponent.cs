using System.IO;
using NiDotNet.NIF.Enums;

namespace NiDotNet.NIF.Nodes
{
    public class PixelFormatComponent : NiObject
    {
        public PixelComponent Type { get; set; }
        
        public PixelRepresentation Convention { get; set; }
        
        public byte BitsPerChannel { get; set; }
        
        public NiBoolean IsSigned { get; set; }
        
        public PixelFormatComponent(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
            Type = (PixelComponent) reader.ReadUInt32();

            Convention = (PixelRepresentation) reader.ReadUInt32();

            BitsPerChannel = reader.ReadByte();

            IsSigned = new NiBoolean(reader);
        }
    }
}