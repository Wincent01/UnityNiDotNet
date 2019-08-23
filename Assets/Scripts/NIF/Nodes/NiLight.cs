using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiLight : NiDynamicEffect
    {
        public float Dimmer { get; set; }

        public NiColor3 AmbientColor { get; set; }

        public NiColor3 DiffuseColor { get; set; }

        public NiColor3 SpecularColor { get; set; }

        public NiLight(BinaryReader reader, NiFile file) : base(reader, file)
        {
            Dimmer = reader.ReadSingle();

            AmbientColor = new NiColor3(reader, file);

            DiffuseColor = new NiColor3(reader, file);

            SpecularColor = new NiColor3(reader, file);
        }
    }
}