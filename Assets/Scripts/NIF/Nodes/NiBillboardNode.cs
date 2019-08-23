using System.IO;
using NiDotNet.NIF.Enums;

namespace NiDotNet.NIF.Nodes
{
    public class NiBillboardNode : NiNode
    {
        public BillboardMode Mode { get; set; }
        
        public NiBillboardNode(BinaryReader reader, NiFile file) : base(reader, file)
        {
            Mode = (BillboardMode) reader.ReadUInt16();
        }
    }
}