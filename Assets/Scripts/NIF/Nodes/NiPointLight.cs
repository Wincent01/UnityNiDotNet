using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiPointLight : NiLight
    {
        public float ConstantAttenuation { get; set; }
        
        public float LinearAttenuation { get; set; }
        
        public float QuadraticAttenuation { get; set; }
        
        public NiPointLight(BinaryReader reader, NiFile file) : base(reader, file)
        {
            ConstantAttenuation = reader.ReadSingle();

            LinearAttenuation = reader.ReadSingle();

            QuadraticAttenuation = reader.ReadSingle();
        }
    }
}