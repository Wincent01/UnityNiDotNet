using System.IO;
using NiDotNet.NIF.Enums;

namespace NiDotNet.NIF.Nodes
{
    public class NiTextureTransformController : NiFloatInterpController
    {
        public NiBoolean ShaderMap { get; set; }
        
        public TexType TextureSlot { get; set; }
        
        public TransformMember Operation { get; set; }
        
        public NiTextureTransformController(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
            ShaderMap = new NiBoolean(reader);

            TextureSlot = (TexType) reader.ReadUInt32();

            Operation = (TransformMember) reader.ReadUInt32();
        }
    }
}