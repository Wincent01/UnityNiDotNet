using System;
using System.IO;
using UnityEngine;

namespace NiDotNet.NIF.Nodes
{
    public class NiSourceTexture : NiTexture
    {
        public byte UseExternal { get; set; }

        public NiString FilePath { get; set; }

        public NiRef<NiPixelFormat> PixelData { get; set; }

        public NiFormatPrefs FormatPrefs { get; set; }

        public byte IsStatic { get; set; }

        public NiBoolean PersistRenderData { get; set; }

        public NiRef<NiObject> UnknownLink { get; set; }

        public NiSourceTexture(BinaryReader reader, NiFile file) : base(reader, file)
        {
            UseExternal = reader.ReadByte();

            switch (UseExternal)
            {
                case 1:
                    FilePath = file.Header.Strings[reader.ReadUInt32()];
                    UnknownLink = new NiRef<NiObject>(file, reader.ReadInt32());
                    break;
                case 0:
                    FilePath = file.Header.Strings[reader.ReadUInt32()];
                    PixelData = new NiRef<NiPixelFormat>(file, reader.ReadInt32());
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"{UseExternal} is not a vaild source texture option.");
            }

            FormatPrefs = new NiFormatPrefs(reader, file);

            IsStatic = reader.ReadByte();

            PersistRenderData = new NiBoolean(reader);
        }
    }
}