using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiStencilProperty : NiProperty
    {
        public short Flags { get; set; }
        
        public uint StencilRef { get; set; }
        
        public uint StencilMask { get; set; }
        
        public NiStencilProperty(BinaryReader reader, NiFile file) : base(reader, file)
        {
            Flags = reader.ReadInt16();

            StencilRef = reader.ReadUInt32();

            StencilMask = reader.ReadUInt32();
        }
    }
}