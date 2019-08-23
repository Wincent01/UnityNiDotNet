using System.IO;
using NiDotNet.NIF.Enums;

namespace NiDotNet.NIF.Nodes
{
    public class NiMaterialProperty : NiProperty
    {
        public NiColor3 AmbientColor { get; set; }

        public NiColor3 DiffuseColor { get; set; }

        public NiColor3 SpecularColor { get; set; }

        public NiColor3 EmissiveColor { get; set; }

        public float Glossiness { get; set; }

        public float Alpha { get; set; }

        public float EmissiveMultiplier { get; set; } = 1f;

        public NiMaterialProperty(BinaryReader reader, NiFile file) : base(reader, file)
        {
            //
            //    Read colors
            //
            AmbientColor = new NiColor3(reader, file);

            DiffuseColor = new NiColor3(reader, file);

            SpecularColor = new NiColor3(reader, file);

            EmissiveColor = new NiColor3(reader, file);

            //
            //    Get other properties
            //
            Glossiness = reader.ReadSingle();

            Alpha = reader.ReadSingle();

            if (file.Header.NifVersion == NiVersion.Ver20207)
            {
                EmissiveMultiplier = reader.ReadSingle();
            }
        }
    }
}