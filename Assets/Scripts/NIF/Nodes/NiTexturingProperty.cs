using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiTexturingProperty : NiProperty
    {
        public short Flags { get; set; }

        public uint TextureCount { get; set; }

        public NiBoolean HasBaseTexture { get; set; }

        public NiTexDesc BaseTexture { get; set; }

        public NiBoolean HasDarkTexture { get; set; }

        public NiTexDesc DarkTexture { get; set; }

        public NiBoolean HasDetailTexture { get; set; }

        public NiTexDesc DetailTexture { get; set; }

        public NiBoolean HasGlossTexture { get; set; }

        public NiTexDesc GlossTexture { get; set; }

        public NiBoolean HasGlowTexture { get; set; }

        public NiTexDesc GlowTexture { get; set; }

        public NiBoolean HasBumpMapTexture { get; set; }

        public NiTexDesc BumpMapTexture { get; set; }

        public float BumpMapLumaScale { get; set; }

        public float BumpMapLumaOffset { get; set; }

        public NiMatrix2X2 BumpMapMatrix { get; set; }

        public NiBoolean HasNormalTexture { get; set; }

        public NiTexDesc NormalTexture { get; set; }

        public NiBoolean HasParallaxTexture { get; set; }

        public NiTexDesc ParallaxTexture { get; set; }

        public float ParallaxOffset { get; set; }

        public uint ShaderTexturesCount { get; set; }

        public NiShaderTexDesc[] ShaderTextures { get; set; }

        public NiTexturingProperty(BinaryReader reader, NiFile file) : base(reader, file)
        {
            Flags = reader.ReadInt16();

            TextureCount = reader.ReadUInt32();

            HasBaseTexture = new NiBoolean(reader);

            if (HasBaseTexture)
                BaseTexture = new NiTexDesc(reader, file);

            HasDarkTexture = new NiBoolean(reader);

            if (HasDarkTexture)
                DarkTexture = new NiTexDesc(reader, file);

            HasDetailTexture = new NiBoolean(reader);

            if (HasDetailTexture)
                DetailTexture = new NiTexDesc(reader, file);

            HasGlossTexture = new NiBoolean(reader);

            if (HasGlossTexture)
                GlossTexture = new NiTexDesc(reader, file);

            HasGlowTexture = new NiBoolean(reader);

            if (HasGlowTexture)
                GlowTexture = new NiTexDesc(reader, file);

            if (TextureCount > 5)
            {
                HasBumpMapTexture = new NiBoolean(reader);
                if (!HasBumpMapTexture) goto Normal;

                BumpMapTexture = new NiTexDesc(reader, file);
                BumpMapLumaScale = reader.ReadSingle();
                BumpMapLumaOffset = reader.ReadSingle();
                BumpMapMatrix = new NiMatrix2X2(reader, file);
            }

            Normal:
            if (TextureCount > 6)
            {
                HasNormalTexture = new NiBoolean(reader);
                if (!HasNormalTexture) goto Parallax;

                NormalTexture = new NiTexDesc(reader, file);
            }

            Parallax:
            if (TextureCount > 7)
            {
                HasParallaxTexture = new NiBoolean(reader);
                if (!HasParallaxTexture) goto Shader;

                ParallaxTexture = new NiTexDesc(reader, file);
                ParallaxOffset = reader.ReadSingle();
            }

            Shader:
            ShaderTexturesCount = reader.ReadUInt32();

            for (var i = 0; i < ShaderTexturesCount; i++)
            {
                ShaderTextures[i] = new NiShaderTexDesc(reader, file);
            }
        }
    }
}