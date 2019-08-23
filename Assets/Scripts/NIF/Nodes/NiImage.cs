using System;
using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiImage : NiObject
    {
        public byte UseExternal { get; set; }

        public NiString FileName { get; set; }

        public NiRef<NiRawImageData> RawImage { get; set; }

        public uint Unknown { get; set; }

        public float UnknownTwo { get; set; }

        public NiImage(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
            UseExternal = reader.ReadByte();

            switch (UseExternal)
            {
                case 0:
                    FileName = niFile.Header.Strings[reader.ReadUInt32()];
                    break;
                case 1:
                    RawImage = new NiRef<NiRawImageData>(niFile, reader.ReadInt32());
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"{UseExternal} is not a vaild image setting.");
            }

            Unknown = reader.ReadUInt32();

            UnknownTwo = reader.ReadSingle();
        }
    }
}