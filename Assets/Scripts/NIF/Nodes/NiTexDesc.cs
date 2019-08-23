using System.IO;
using NiDotNet.NIF.Enums;

namespace NiDotNet.NIF.Nodes
{
    public class NiTexDesc : NiObject
    {
        public NiRef<NiSourceTexture> Source { get; set; }

        public short Flags { get; set; }

        public NiBoolean HasTextureTransform { get; set; }

        public NiTexCoord Translation { get; set; }

        public NiTexCoord Scale { get; set; }

        public float Rotation { get; set; }

        public TransformMethod Method { get; set; }

        public NiTexCoord Center { get; set; }

        public NiTexDesc(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
            Source = new NiRef<NiSourceTexture>(niFile, reader.ReadInt32());

            Flags = reader.ReadInt16();

            HasTextureTransform = new NiBoolean(reader);

            if (!HasTextureTransform) return;

            Translation = new NiTexCoord(reader, niFile);

            Scale = new NiTexCoord(reader, niFile);

            Rotation = reader.ReadSingle();

            Method = (TransformMethod) reader.ReadUInt32();

            Center = new NiTexCoord(reader, niFile);
        }
    }
}